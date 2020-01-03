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
        public int linkAmount; // TODO: This variable is redundant (just do links.Count) and should be removed.
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

        public Space(int crapAmount)
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
            flags = new byte[crapAmount].ToList();
            type = 0;
            typePad = 0x00;
            links = new List<int>();
        }

        
        public enum Types
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
            Other = 0x0B   // Used by MP7.
        }

        /* Some data in "flags[0]" correlates to flags that
         * change how the player traverses the environment;
         * Currently just putting these here for reference.
         */
        public enum TraversalFlags
        {
            NoUnique = 0x0000,
            Jump1 = 0x0001, //Maybe a height difference between the two jumps?
            Activation = 0x0002,
            Jump3 = 0x0003,
            ClimbEnd = 0x0004,
            ClimbStart = 0x08, //For climb to work, the next space must be marked with a ClimbEnd flag
            HomeSpace = 0x8000 //(starting at flags[24])Space #63 (home) is marked with this, and when it's removed, the paths on the map screen stop being drawn.
            
        }
    }
}
