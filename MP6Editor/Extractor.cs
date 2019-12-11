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
        // Header padding length
        const int BEGIN = 3; 
        string fileName = "";

        int fileSize = 0;

        public int mpVersion = 0; // 4 == MP4, 5 == MP5, all else == MP6
        private int crapCount = 0;

        private readonly string S_QUICKBMS = "quickbms.exe";
        private readonly string S_MP6SCRIPT = "mario_party_6_alt.bms";
        private readonly string S_LZSSCOMP = "lzss_comp.bms";
        private readonly string S_OUTFOLDER = "w01_out";

        private readonly byte[] FLAGS = { 0x00, 0x00, 0x00, 0x01 };

        int offset;
        List<Space> Board = new List<Space>();

        // Reads decompressed board file
        public List<Space> ReadFile()
        {
            if(mpVersion == 4 || mpVersion == 5)
            {
                crapCount = 29;
            }
            else
            {
                crapCount = 31;
            }
            FileStream fileStream = new FileStream(fileName, FileMode.Open);

            fileSize = (int)fileStream.Length;

            // Get amount of spaces on board
            byte[] spaceCount = new byte[4];
            fileStream.Read(spaceCount, 0, spaceCount.Length);
            Array.Reverse(spaceCount);

            // Read in spaces from board
            for (int i = 0; i < BitConverter.ToInt32(spaceCount, 0); i++)
            {
                Board.Add(ReadSpace(fileStream));
            }


            offset = (int)fileStream.Position;

            //Debug.WriteLine("Space Count: " + spaces);
            return Board;
        }// end ReadFile()

        // Reads the next space in
        private Space ReadSpace(FileStream fileStream)
        {
            Space space = new Space();
            // Positions
            space.X = GetPosition(fileStream);
            space.Y = GetPosition(fileStream);
            space.Z = GetPosition(fileStream);

            // Crap
            space.crap = GetCrap(fileStream, crapCount).ToList();

            // Type
            space.type = fileStream.ReadByte();

            // Type padding (can probably get rid of this)
            space.typePad = (byte)fileStream.ReadByte();

            // Link count
            int links = fileStream.ReadByte();
            space.linkAmount = links;

            // Link IDs
            for (int i = 0; i < links; i++)
            {
                fileStream.ReadByte(); //padding
                int link = fileStream.ReadByte();
                space.links.Add(link);
            }

            return space;
        }// end readSpace()

        // Get the passed type's matching texture
        // TODO: Don't even remember what I was going to use this method for
        Texture2D GetSpaceTexture(int type)
        {
            switch (type)
            {
                case 0: // Blank
                    return Editor.Content.Load<Texture2D>(@"Blank");
                case 1: // Blue
                    return Editor.Content.Load<Texture2D>(@"Blue");
                case 2: // Red
                    return Editor.Content.Load<Texture2D>(@"Red");
                case 3: // Happening
                    return Editor.Content.Load<Texture2D>(@"Happening");
                case 4: // Miracle
                    return Editor.Content.Load<Texture2D>(@"Miracle");
                case 5: // Duel
                    return Editor.Content.Load<Texture2D>(@"Dueling");
                case 6: // DK/Bowser
                    return Editor.Content.Load<Texture2D>(@"DK");
                case 8: // Orb
                    return Editor.Content.Load<Texture2D>(@"Orb");
                case 9: // Shop
                    return Editor.Content.Load<Texture2D>(@"Shop");
                default: // Everything else
                    return Editor.Content.Load<Texture2D>(@"Other");
            }
        }// end getSpaceTexture()

        // Converts the next 4 bytes into a float
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
        }// end getPosition()

        // Get the information between the end of the positions and before the typing
        private byte[] GetCrap(FileStream fileStream, int crapAmount)
        {
            byte[] crap = new byte[crapAmount];
            for (int i = 0; i < crapAmount; i++)
            {
                crap[i] = (byte)fileStream.ReadByte();
            }
            return crap;
        }// end getCrap()

        // Converts current board to MP6 board format
        public void SaveBoardLayout(List<Space> nuBoard)
        {
            // TODO: Clean it up, it's a mess
            // probably should do some file verification too
            FileStream fileStream = new FileStream("board_out_test", FileMode.OpenOrCreate);

            // Amount of spaces
            byte[] spaceCount = BitConverter.GetBytes(nuBoard.Count);
            Array.Reverse(spaceCount);
            fileStream.Write(spaceCount, 0, 4);

            // Spaces
            // TODO: clean up this mess
            for(int i = 0; i < nuBoard.Count; i++)
            {
                // Space X pos
                byte[] posArray = BitConverter.GetBytes(nuBoard[i].X);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);

                // Space Y pos
                posArray = BitConverter.GetBytes(nuBoard[i].Y);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);

                // Space Z pos
                posArray = BitConverter.GetBytes(nuBoard[i].Z);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);

                // "crap"
                fileStream.Write(nuBoard[i].crap.ToArray(), 0, nuBoard[i].crap.Count);
                // type
                fileStream.WriteByte((byte)nuBoard[i].type);
                // padding
                fileStream.WriteByte(0x00);
                // link amount
                fileStream.WriteByte((byte)nuBoard[i].linkAmount);

                // Space links
                for(int j = 0; j < nuBoard[i].linkAmount; j++)
                {
                    fileStream.WriteByte(0x00);
                    fileStream.WriteByte((byte)nuBoard[i].links[j]);
                }
            }
            fileStream.Dispose();
        }// end SaveBoardLayout()

        // Calls cline quickbms to extract/import the files
        public void QuickExtract(string filePath, bool reimport)
        {
            string args = "-Y ";
            if (reimport)
            {
                args = args + "-r -w ";
            }

            Process quickbms = new Process();
            // quickbms.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            quickbms.StartInfo.FileName = S_QUICKBMS;
            quickbms.StartInfo.UseShellExecute = true;

            // cline args
            quickbms.StartInfo.Arguments = args + S_MP6SCRIPT + " \"" + filePath + "\" " + S_OUTFOLDER;
            quickbms.Start();
            quickbms.WaitForExit();

            // Set global fileName
            fileName = "w01_out\\00000000.dat";

        }//end QuickExtract()

        // Repacks the files into the .bin and appends the modified 0.dat to the end
        public void RepackFile(string newFileName, string packedFileName, List<byte[]> oldOffsets)
        {
            // TODO: replace hardcoded filenames with variables

            // Get 0.dat's uncompressed size in bytes (SIZE)
            FileStream layoutFileStream = new FileStream("board_out_test", FileMode.Open);
            byte[] SIZE = BitConverter.GetBytes((int)layoutFileStream.Length);
            Array.Reverse(SIZE);
            layoutFileStream.Dispose();

            // Call QBMS lzss_comp script to compress 0.dat
            Process quickbms = new Process();
            //quickbms.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            quickbms.StartInfo.FileName = S_QUICKBMS;
            quickbms.StartInfo.UseShellExecute = true;
            string args = "-Y ";
            quickbms.StartInfo.Arguments = args + S_LZSSCOMP + " \"" + "board_out_test" + "\" " + "recompress_out";
            quickbms.Start();
            quickbms.WaitForExit();

            // File stuff
            //File.Copy("w01.bin", newFileName, true);
            //File.Copy("w01.bin", newFileName + ".TEMP", true);
            File.Copy(packedFileName, newFileName + ".TEMP", true);
            File.Copy(newFileName + ".TEMP", newFileName, true);
            
            FileStream packedFileStream = new FileStream(newFileName, FileMode.Open);
            byte[] OFFSET = oldOffsets[0];

            packedFileStream.Seek(BitConverter.ToInt32(oldOffsets[0], 0), 0);


            // Write w01.bin with uncomp size (4 bytes long), then flags (00 00 00 01)
            packedFileStream.Write(SIZE, 0, SIZE.Length);
            packedFileStream.Write(FLAGS, 0, FLAGS.Length);

            // Write compressed 0.dat to w01.bin
            layoutFileStream = new FileStream("recompress_out\\0_compressed.dat", FileMode.Open);
            int compLength = (int)layoutFileStream.Length;
            layoutFileStream.CopyTo(packedFileStream);
            layoutFileStream.Dispose();
            packedFileStream.Dispose();

            // copy remaining compressed files to new file
            FileStream tempStream = new FileStream(newFileName + ".TEMP", FileMode.Open);
            tempStream.Seek(BitConverter.ToInt32(oldOffsets[1], 0), 0);

            List<int> newOffsets = new List<int>();
            newOffsets = AdjustFileHeader(oldOffsets, compLength);

            packedFileStream = new FileStream(newFileName, FileMode.Open);
            packedFileStream.Seek(newOffsets[1], 0);
            tempStream.CopyTo(packedFileStream);

            tempStream.Dispose();
            packedFileStream.Dispose();
            File.Delete(newFileName + ".TEMP");

            // write new file header
            packedFileStream = new FileStream(newFileName, FileMode.Open);
            byte[] FILECOUNT = BitConverter.GetBytes(newOffsets.Count);
            Array.Reverse(FILECOUNT);
            packedFileStream.Write(FILECOUNT, 0, 4);

            for (int i = 0; i < newOffsets.Count; i++)
            {
                OFFSET = BitConverter.GetBytes(newOffsets[i]);
                Array.Reverse(OFFSET);
                packedFileStream.Write(OFFSET, 0, 4);
            }

            packedFileStream.Dispose();
        }// end RepackFile()

        // Gets file header (data offsets) from board file
        public List<byte[]> GetFileHeader(string fileName)
        {
            FileStream boardFileStream = new FileStream(fileName, FileMode.Open);
            byte[] COUNT = new byte[4]; //amount of packed files

            boardFileStream.Read(COUNT, 0, 4);
            Array.Reverse(COUNT);

            List<byte[]> offsets = new List<byte[]>();

            for(int i = 0; i < BitConverter.ToInt32(COUNT, 0); i++)
            {
                byte[] offset = new byte[4];
                boardFileStream.Read(offset, 0, 4);
                Array.Reverse(offset);
                offsets.Add(offset);
            }

            return offsets;
        }// end GetFileHeader()

        // Changes offsets to match new file layout
        public List<int> AdjustFileHeader(List<byte[]> offsets, int newSize)
        {
            // TODO
            List<int> intList = ByteListToInt(offsets);
            int adjustmentAmount = (newSize + 8) - (intList[1] - intList[0]);

            for (int i = 1; i < intList.Count; i++)
            {
                intList[i] = intList[i] + adjustmentAmount;
            }

            return intList;
        }// end AdjustFileHeader()

        // Does exactly what it says on the can
        List<int> ByteListToInt(List<byte[]> byteList)
        {
            List<int> intList = new List<int>();

            for(int i = 0; i < byteList.Count; i++)
            {
                intList.Add(BitConverter.ToInt32(byteList[i], 0));
            }

            return intList;
        }// end ByteListToInt()
    }
}
