﻿/*************************************
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

        public int mpVersion = 0; // 4 == MP4, 5 == MP5, etc.
        private int flag_Count = 0; // MP4 and MP5 have 5 flags per space, MP6 and MP7 have 7 flags per space.

        private readonly string S_QUICKBMS = "quickbms.exe";
        private readonly string S_MP6SCRIPT = "mario_party_6_alt.bms";
        private readonly string S_LZSSCOMP = "lzss_comp.bms";
        private readonly string S_OUTFOLDER = "w01_out";
        private readonly string S_RECOMPRESS_OUT_FOLDER = "recompress_out";
        private readonly string S_0_COMPRESSED_OUT = "0_compressed.dat";
        private readonly string S_BOARD_LAYOUT = "board_layout_raw";

        private readonly byte[] BIN_FLAGS = { 0x00, 0x00, 0x00, 0x01 };

        int offset;
        List<Space> Board = new List<Space>();

        /// <summary>
        /// Reads decompressed board file.
        /// </summary>
        /// <returns>List of Spaces read from file.</returns>
        public List<Space> ReadFile()
        {
            if(mpVersion == 4 || mpVersion == 5)
            {
                flag_Count = 5;
            }
            else
            {
                flag_Count = 7;
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

        /// <summary>
        /// Reads the next Space in the board file.
        /// </summary>
        /// <param name="fileStream">Stream of file currently being read.</param>
        /// <returns>Next space in the board file.</returns>
        private Space ReadSpace(FileStream fileStream)
        {
            Space space = new Space();
            // Positions
            space.X = GetPosition(fileStream);
            space.Y = GetPosition(fileStream);
            space.Z = GetPosition(fileStream);

            // Rotation
            space.rot_X = GetPosition(fileStream);
            space.rot_Y = GetPosition(fileStream);
            space.rot_Z = GetPosition(fileStream);

            // Scaling
            space.scale_X = GetPosition(fileStream);
            space.scale_Y = GetPosition(fileStream);
            space.scale_Z = GetPosition(fileStream);

            // Flags
            space.flags = GetCrap(fileStream, flag_Count).ToList();

            // Type
            space.type = fileStream.ReadByte();

            // Type padding (TODO: consider removing this var and just skipping this byte)
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

        /// <summary>
        /// Converts the next 4 bytes into a float.
        /// </summary>
        /// <param name="fileStream">Stream of file currently being read.</param>
        /// <returns>Float conversion of a 4-byte position value.</returns>
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

        /// <summary>
        /// Get flags of Space being currently read.
        /// </summary>
        /// <param name="fileStream">Stream of file currently being read.</param>
        /// <param name="crapAmount">Amount of flags in Space (differs from game-to-game).</param>
        /// <returns></returns>
        private byte[] GetCrap(FileStream fileStream, int crapAmount)
        {
            byte[] crap = new byte[crapAmount];
            for (int i = 0; i < crapAmount; i++)
            {
                crap[i] = (byte)fileStream.ReadByte();
            }
            return crap;
        }// end getCrap()

        /// <summary>
        /// Converts current board to MP6 board format.
        /// </summary>
        /// <param name="nuBoard">Board to be saved to file.</param>
        public void SaveBoardLayout(List<Space> nuBoard)
        {
            // TODO: Clean it up, it's a mess
            // probably should do some file verification too
            FileStream fileStream = new FileStream(S_BOARD_LAYOUT, FileMode.OpenOrCreate);

            // Amount of spaces
            byte[] spaceCount = BitConverter.GetBytes(nuBoard.Count);
            Array.Reverse(spaceCount);
            fileStream.Write(spaceCount, 0, 4);

            // Spaces
            // TODO TODO TODO: SERIOUSLY clean up this mess
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

                // Space rot_X pos
                posArray = BitConverter.GetBytes(nuBoard[i].rot_X);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);
                // Space rot_Y pos
                posArray = BitConverter.GetBytes(nuBoard[i].rot_Y);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);
                // Space rot_Z pos
                posArray = BitConverter.GetBytes(nuBoard[i].rot_Z);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);

                // Space scale_X pos
                posArray = BitConverter.GetBytes(nuBoard[i].scale_X);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);
                // Space scale_Y pos
                posArray = BitConverter.GetBytes(nuBoard[i].scale_Y);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);
                // Space scale_Z pos
                posArray = BitConverter.GetBytes(nuBoard[i].scale_Z);
                Array.Reverse(posArray);
                fileStream.Write(posArray, 0, 4);

                // "flags"
                fileStream.Write(nuBoard[i].flags.ToArray(), 0, nuBoard[i].flags.Count);
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

        /// <summary>
        /// Calls cline quickbms to extract/import the files.
        /// </summary>
        /// <param name="filePath">Path to file to be extracted/imported.</param>
        /// <param name="reimport">True if reimporting; false if not.</param>
        public void QuickExtract(string filePath, bool reimport)
        {
            string args = "-Y ";
            if (reimport)
            {
                args = args + "-r -w ";
            }

            Process quickbms = new Process();
            //quickbms.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            quickbms.StartInfo.FileName = S_QUICKBMS;
            quickbms.StartInfo.UseShellExecute = true;

            // cline args
            quickbms.StartInfo.Arguments = args + S_MP6SCRIPT + " \"" + filePath + "\" " + S_OUTFOLDER;
            quickbms.Start();
            quickbms.WaitForExit();

            // Set global fileName
            fileName = "w01_out\\00000000.dat";

        }//end QuickExtract()

        /// <summary>
        /// Repacks the files into the .bin and inserts the modified layout file.
        /// </summary>
        /// <param name="newFileName">New file name.</param>
        /// <param name="packedFileName">Old file name.</param>
        /// <param name="oldOffsets">Offsets of .bin before inserting new layout file.</param>
        public void RepackFile(string newFileName, string packedFileName, List<byte[]> oldOffsets)
        {
            // TODO: replace hardcoded filenames with variables

            // Get 0.dat's uncompressed size in bytes (SIZE)
            FileStream layoutFileStream = new FileStream(S_BOARD_LAYOUT, FileMode.Open);
            byte[] SIZE = BitConverter.GetBytes((int)layoutFileStream.Length);
            Array.Reverse(SIZE);
            layoutFileStream.Dispose();

            // Call QBMS lzss_comp script to compress 0.dat
            Process quickbms = new Process();
            //quickbms.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            quickbms.StartInfo.FileName = S_QUICKBMS;
            quickbms.StartInfo.UseShellExecute = true;
            string args = "-Y ";
            quickbms.StartInfo.Arguments = args + S_LZSSCOMP + " \"" + S_BOARD_LAYOUT + "\" " + S_RECOMPRESS_OUT_FOLDER;
            quickbms.Start();
            quickbms.WaitForExit();

            // File stuff
            File.Copy(packedFileName, newFileName + ".TEMP", true);
            File.Copy(newFileName + ".TEMP", newFileName, true);
            
            FileStream packedFileStream = new FileStream(newFileName, FileMode.Open);
            byte[] OFFSET = oldOffsets[0];

            packedFileStream.Seek(BitConverter.ToInt32(oldOffsets[0], 0), 0);


            // Write w01.bin with uncomp size (4 bytes long), then flags (00 00 00 01)
            packedFileStream.Write(SIZE, 0, SIZE.Length);
            packedFileStream.Write(BIN_FLAGS, 0, BIN_FLAGS.Length);

            // Write compressed 0.dat to w01.bin
            layoutFileStream = new FileStream(S_RECOMPRESS_OUT_FOLDER + "\\" + S_0_COMPRESSED_OUT, FileMode.Open);
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

        /// <summary>
        /// Gets file header (data offsets) from board file.
        /// </summary>
        /// <param name="fileName">Path to file.</param>
        /// <returns>Byte List of offsets.</returns>
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

        /// <summary>
        /// Changes offsets to match new file layout.
        /// </summary>
        /// <param name="offsets">Old offsets before inserting new layout file.</param>
        /// <param name="newSize">New size of the file.</param>
        /// <returns></returns>
        public List<int> AdjustFileHeader(List<byte[]> offsets, int newSize)
        {
            List<int> intList = ByteListToInt(offsets);
            int adjustmentAmount = (newSize + 8) - (intList[1] - intList[0]);

            for (int i = 1; i < intList.Count; i++)
            {
                intList[i] = intList[i] + adjustmentAmount;
            }

            return intList;
        }// end AdjustFileHeader()

        /// <summary>
        /// Converts a List of bytes to a List of ints.
        /// </summary>
        /// <param name="byteList">Byte List to be converted.</param>
        /// <returns>Converted List of ints.</returns>
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
