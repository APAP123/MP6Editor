/*************************************
 * Space.cs   
 *
 * represents an individual board space
 *************************************/

using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6Editor
{
    class Space
    {
        public static readonly int MP67_FLAGCOUNT = 7;
        public static readonly int MP45_FLAGCOUNT = 5;
        // Position values are the distance from the origin point (center).
        public float X; // X position
        public float Y; // Y position
        public float Z; // Z position

        // Rotation values
        public float rot_X;
        public float rot_Y;
        public float rot_Z;

        // Scaling values; Does not seem to affect anything visually or otherwise.
        public float scale_X;
        public float scale_Y;
        public float scale_Z;

        public List<byte> flags = new List<byte>();
        //public byte[] flags = new byte[31]; // Not sure what this info means yet, but it's probably important.
        public int type;
        public Texture2D texture;
        public byte typePad; // Padding after the type byte; This probably isn't neccessary.
        public int linkAmount;
        public List<int> links = new List<int>(); // IDs of the spaces linked to.

        public Space()
        {

        }

        public Space(float X, float Y, float Z, int crapAmount, int type, List<int> links)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            flags = new byte[crapAmount].ToList();
            this.type = type;
            typePad = 0x00;
            //this.linkAmount = linkAmount;
            this.links = links;
        }

        public Space(int flagCount)
        {
            X = 0;
            Y = 0;
            Z = 0;
            rot_X = 0;
            rot_Y = 0;
            rot_Z = 0;
            scale_X = 1f;
            scale_Y = 1f;
            scale_Z = 1f;
            flags = new byte[flagCount].ToList();
            type = 0;
            typePad = 0x00;
            links = new List<int>();
        }

        public enum MP4_Types
        {
            Blank = 0x00,
            Blue = 0x01,
            Red = 0x02,
            Bowser = 0x03,
            Item = 0x04,
            Battle = 0x05,
            Happening = 0x06, // Does not function on it's own.
            Miracle = 0x07,
            Star = 0x08, 
            Spring = 0x09,        
            //Unused = 0x0A,
            //Unused2 = 0x0B
        }

        public enum MP5_Types
        {
            Blank = 0x00,
            Blue = 0x01,
            Red = 0x02,
            Bowser = 0x03,
            Happening = 0x04, // Does not function on it's own.
            Star = 0x05, // Represents POSSIBLE star spawn locations; is a blue Space otherwise.
            Happening2 = 0x06, // Does not function on it's own. Not sure why there's two Happening entries...
            Dueling = 0x07, 
            DK = 0x08,
            Unused = 0x09,
            Unused2 = 0x0A,
            Unused3 = 0x0B
        }


        public enum MP6_Types
        {
            Blank = 0x00,
            Blue = 0x01,
            Red = 0x02,
            Happening = 0x03,   // By default, No event will occur upon landing.
            Miracle = 0x04,
            Dueling = 0x05,
            DKBowser = 0x06,
            Star = 0x07,
            Orb = 0x08,
            Shop = 0x09,        // Does not function on it's own.
            Ztar = 0x0A,        // Does not funtion on it's own.
            Other = 0x0B
        }

        public enum MP7_Types
        {
            Blank = 0x00,
            Blue = 0x01,
            Red = 0x02,
            Happening = 0x03,   // By default, No event will occur upon landing.
            Bowser = 0x04,
            Dueling = 0x05,
            DK = 0x06,
            Star = 0x07,    // Softlocks the game when hardcoded; should check flags of legit star Spaces.
            Orb = 0x08,
            Shop = 0x09,        // Does not function on it's own.
            Ztar = 0x0A,        // Does not funtion on it's own.
            Mic = 0x0B
        }

        /*
         * flags[0]
         */
        public enum PathFlags
        {
            Normal = 0x00,
            Untraversable = 0x20,
            Whomp = 0x40,
            WhompUntraversable = 0x60,
            Home = 0x80 // Marks the Space players start the game on.
        }

        /* 
         * flags[1]
         */
        public enum TraversalFlags
        {
            Walk = 0x00,
            JumpEndBig = 0x01,
            JumpBegin = 0x02,
            JumpEndSmall = 0x03,
            ClimbEnd = 0x04,
            ClimbStart = 0x08, // For climb to work, the next space must be marked with a ClimbEnd flag    
            ClimbStartAlt = 0x09,
            Shop = 0x20, // Why the developers decide to put this with flags relating to animations I really don't know.
        }



    }
}
