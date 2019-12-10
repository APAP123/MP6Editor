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
        // Position values are the distance from the origin point (center).
        public float X; // X position
        public float Y; // Y position
        public float Z; // Z position
        public byte[] crap = new byte[31]; // Not sure what this info means yet, but it's probably important.
        public int type;
        public Texture2D texture;
        public byte typePad; // Padding after the type byte; This probably isn't neccessary.
        public int linkAmount; // TODO: This variable is redundant (just do links.Count) and should be removed.
        public List<int> links = new List<int>(); // IDs of the spaces linked to.

        public Space()
        {

        }

        public Space(float X, float Y, float Z, int type, List<int> links)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
            crap = new byte[31];
            this.type = type;
            typePad = 0x00;
            //this.linkAmount = linkAmount;
            this.links = links;
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

        /* Some data in "crap[25]" correlates to flags that
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
            HomeSpace = 0x8000 //(starting at crap[24])Space #63 (home) is marked with this, and when it's removed, the paths on the map screen stop being drawn.
            
        }
    }
}
