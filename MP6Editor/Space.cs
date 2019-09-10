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
        //Position values are the distance from the origin point (center)
        public float X; //X position
        public float Y; //Y position
        public float Z; //Z position
        public byte[] crap = new byte[31]; //Not sure what this info means yet, but it's probably important
        public int type;
        public Texture2D texture;
        public byte typePad; //Padding after the type byte; This probably isn't neccessary
        public int linkAmount; //TODO: This variable is redundant (just do links.Count) and should be removed
        public List<int> links = new List<int>(); //IDs of the spaces linked to
        
        public enum Types
        {
            Blank = 0x00,
            Blue = 0x01,
            Red = 0x02,
            Happening = 0x03, //No event occurs upon landing
            Chance = 0x04,
            Dueling = 0x05,
            DKBowser = 0x06,
            Star = 0x07,
            Orb = 0x08,
            Shop = 0x09,      //Does not function on it's own
            Ztar = 0x0A       //Does not funtion on it's own
        }
    }
}
