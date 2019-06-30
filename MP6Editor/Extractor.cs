using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6Editor
{
    class Extractor
    {
        const int BEGIN = 3; //Header padding length
        string fileName = "00000000";
        int offset;
        int amount;
        List<Space> Board = new List<Space>();

        public void readFile()
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
    }
}
