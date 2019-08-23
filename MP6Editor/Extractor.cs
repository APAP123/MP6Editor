using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6Editor
{
    class Extractor : MonoGameControl
    {
        const int BEGIN = 3; //Header padding length
        //string fileName = "00000000";
        string fileName = "";


        private const string S_QUICKBMS = "quickbms.exe";
        private const string S_MP6SCRIPT = "mario_party_6.bms \"";
        private const string S_LZSSSCRIPT = "LZS_decompress.bms";
        int offset;
        int amount;
        List<Space> Board = new List<Space>();

        public List<Space> readFile()
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);
            //Skip past the first three bytes of padding
            for (int i = 0; i < BEGIN; i++)
            {
                fileStream.ReadByte();
            }
            amount = fileStream.ReadByte();

            //Read in spaces from board
            for (int i = 0; i < amount; i++)
            {
                Board.Add(readSpace(fileStream));
            }


            offset = (int)fileStream.Position;

            //Debug.WriteLine("Space Count: " + spaces);
            return Board;
        }

        //Reads the next space in
        Space readSpace(FileStream fileStream)
        {
            Space space = new Space();
            //Positions
            space.X = getPosition(fileStream);
            space.Y = getPosition(fileStream);
            space.Z = getPosition(fileStream);

            //Crap
            space.crap = getCrap(fileStream);

            //Type
            space.type = fileStream.ReadByte();

            //Type padding (can probably get rid of this)
            space.typePad = (byte)fileStream.ReadByte();

            //Link count
            int links = fileStream.ReadByte();
            space.linkAmount = links;

            //Link IDs
            for (int i = 0; i < links; i++)
            {
                fileStream.ReadByte(); //padding
                int link = fileStream.ReadByte();
                space.links.Add(link);
            }

            return space;
        }//end readSpace()

        //Get the passed type's matching texture
        //TODO: Don't even remember what I was going to use this method for
        Texture2D getSpaceTexture(int type)
        {
            switch (type)
            {
                case 0: //Blank
                    return Editor.Content.Load<Texture2D>(@"Blank");
                case 1: //Blue
                    return Editor.Content.Load<Texture2D>(@"Blue");
                case 2: //Red
                    return Editor.Content.Load<Texture2D>(@"Red");
                case 3: //Happening
                    return Editor.Content.Load<Texture2D>(@"Happening");
                case 4: //Miracle
                    return Editor.Content.Load<Texture2D>(@"Miracle");
                case 5: //Duel
                    return Editor.Content.Load<Texture2D>(@"Dueling");
                case 6: //DK/Bowser
                    return Editor.Content.Load<Texture2D>(@"DK");
                case 8: //Orb
                    return Editor.Content.Load<Texture2D>(@"Orb");
                case 9: //Shop
                    return Editor.Content.Load<Texture2D>(@"Shop");
                default: //Everything else
                    return Editor.Content.Load<Texture2D>(@"Other");
            }
        }//end getSpaceTexture()

        //Converts the next 4 bytes into a float
        float getPosition(FileStream fileStream)
        {
            byte[] position = new byte[4];
            for (int i = 0; i < position.Length; i++)
            {
                position[i] = (byte)fileStream.ReadByte();
            }
            //Due to endianness, need to flip array
            Array.Reverse(position);

            return System.BitConverter.ToSingle(position, 0);
        }//end getPosition()

        //Get the information between the end of the positions and before the typing
        byte[] getCrap(FileStream fileStream)
        {
            byte[] crap = new byte[31];
            for (int i = 0; i < 31; i++)
            {
                crap[i] = (byte)fileStream.ReadByte();
            }

            return crap;
        }//end getCrap()

        //Calls cline quickbms to extract the files
        public void quickExtract(string filePath)
        {
            //TODO: cleanup; create string variables to reduce repetition and to prevent typos;
            //use a loop to reduce code redundancy?

            Process quickbms = new Process();
            //quickbms.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            quickbms.StartInfo.FileName = "quickbms.exe";
            quickbms.StartInfo.UseShellExecute = true;

            //first pass
            quickbms.StartInfo.Arguments = "mario_party_6.bms \"" + filePath + "\" w01_out";
            quickbms.Start();
            quickbms.WaitForExit();

            //second pass
            quickbms.StartInfo.Arguments = "LZS_decompress.bms w01_out\\00000000.dat 00000000_out";
            quickbms.Start();
            quickbms.WaitForExit();

            //Set global fileName
            fileName = "00000000_out\\00000000";

        }//end quickExtract()

        //Repacks the file using quickBMS's reimport feature
        public void quickReimport(string filePath)
        {
            Process quickbms = new Process();
            quickbms.StartInfo.FileName = "quickbms.exe";
            quickbms.StartInfo.UseShellExecute = true;

            //first pass
            quickbms.StartInfo.Arguments = "-r LZS_decompress.bms w01_out\\00000000.dat 00000000_out";
            quickbms.Start();
            quickbms.WaitForExit();

            //second pass
            quickbms.StartInfo.Arguments = "-r mario_party_6.bms \"" + filePath + "\" w01_out";
            quickbms.Start();
            quickbms.WaitForExit();

            //TODO: Look into consolidating this function with the one above; the code is 90% the same.
        }//end quickReimport()
    }
}
