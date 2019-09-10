/*************************************
 * Extractor.cs   
 *
 * Used to extract board layout from 
 * MP6 board .bin files via QuickBMS
 *************************************/

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
        string fileName = "";

        int fileSize = 0;


        private readonly string S_QUICKBMS = "quickbms.exe";
        private readonly string S_MP6SCRIPT = "mario_party_6_alt.bms";
        private readonly string S_OUTFOLDER = "w01_out";

        int offset;
        int amount;
        List<Space> Board = new List<Space>();

        public List<Space> ReadFile()
        {
            FileStream fileStream = new FileStream(fileName, FileMode.Open);

            fileSize = (int)fileStream.Length;
            //Skip past the first three bytes of padding
            //TODO: The amount of files in the .bin is probably the initial 4 bytes,
            //so skipping the first three is going to cause issues sooner or later
            for (int i = 0; i < BEGIN; i++)
            {
                fileStream.ReadByte();
            }
            amount = fileStream.ReadByte();

            //Read in spaces from board
            for (int i = 0; i < amount; i++)
            {
                Board.Add(ReadSpace(fileStream));
            }


            offset = (int)fileStream.Position;

            //Debug.WriteLine("Space Count: " + spaces);
            return Board;
        }

        //Reads the next space in
        private Space ReadSpace(FileStream fileStream)
        {
            Space space = new Space();
            //Positions
            space.X = GetPosition(fileStream);
            space.Y = GetPosition(fileStream);
            space.Z = GetPosition(fileStream);

            //Crap
            space.crap = GetCrap(fileStream);

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
        Texture2D GetSpaceTexture(int type)
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
        private float GetPosition(FileStream fileStream)
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
        private byte[] GetCrap(FileStream fileStream)
        {
            byte[] crap = new byte[31];
            for (int i = 0; i < 31; i++)
            {
                crap[i] = (byte)fileStream.ReadByte();
            }
            return crap;
        }//end getCrap()

        //Converts current board to MP6 board format
        public void SaveBoardLayout(List<Space> nuBoard)
        {
            //TODO: Clean it up, it's a mess
            //probably should do some file verification too

            //Padding
            FileStream fileStream = new FileStream("board_out_test", FileMode.OpenOrCreate);
            for (int i = 0; i < BEGIN; i++)
            {
                fileStream.WriteByte(0x00);
            }

            fileStream.WriteByte(0x6B);

            //Spaces
            //TODO: clean up this mess
            for(int i = 0; i < nuBoard.Count; i++)
            {
                //Space X pos
                byte[] posArray = BitConverter.GetBytes(nuBoard[i].X);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);

                //Space Y pos
                posArray = BitConverter.GetBytes(nuBoard[i].Y);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);

                //Space Z pos
                posArray = BitConverter.GetBytes(nuBoard[i].Z);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);

                //"crap"
                fileStream.Write(nuBoard[i].crap, 0, nuBoard[i].crap.Length);
                //type
                fileStream.WriteByte((byte)nuBoard[i].type);
                //padding
                fileStream.WriteByte(0x00);
                //link amount
                fileStream.WriteByte((byte)nuBoard[i].linkAmount);

                //Space links
                for(int j = 0; j < nuBoard[i].linkAmount; j++)
                {
                    fileStream.WriteByte(0x00);
                    fileStream.WriteByte((byte)nuBoard[i].links[j]);
                }
            }
        }//end SaveBoardLayout()

        //Calls cline quickbms to extract/import the files
        public void QuickExtract(string filePath, bool reimport)
        {
            string args = "-Y ";
            //TODO: merge
            if (reimport)
            {
                args = args + "-r -w ";
            }

            Process quickbms = new Process();
            //quickbms.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            quickbms.StartInfo.FileName = S_QUICKBMS;
            quickbms.StartInfo.UseShellExecute = true;

            //cline args
            quickbms.StartInfo.Arguments = args + S_MP6SCRIPT + " \"" + filePath + "\" " + S_OUTFOLDER;
            quickbms.Start();
            quickbms.WaitForExit();

            //Set global fileName
            fileName = "w01_out\\00000000.dat";

        }//end QuickExtract()
    }
}
