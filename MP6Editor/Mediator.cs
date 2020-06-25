/*************************************
 * Mediator.cs   
 *
 * Used for easier communication
 * between DrawTest and ToolBox.
 *************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MP6Editor
{
    static class Mediator
    {
        public static DrawTest DrawTest { get; set; }
        public static ToolBox ToolBox { get; set; }
        public static int CurrentSpace { get; set; }

        public static void ToolBox_SetSelected(int selected)
        {
            ToolBox.highlightSpace = selected;
            ToolBox.highlightPath =  Array.IndexOf((Enum.GetValues(typeof(Space.PathFlags)) as int[]), DrawTest.Board[CurrentSpace].flags[0]);
            ToolBox.highlightTravel = Array.IndexOf((Enum.GetValues(typeof(Space.TraversalFlags)) as int[]), DrawTest.Board[CurrentSpace].flags[1]);
        }

        public static void DrawTest_SetSpaceType(int type)
        {
            DrawTest.Board[DrawTest.SelectedSpace].type = type;
        }

        public static void DrawTest_SetPathType(int path)
        {
            DrawTest.Board[CurrentSpace].flags[0] = (byte)(Enum.GetValues(typeof(Space.PathFlags)) as int[])[path];
            //DrawTest.Board[CurrentSpace].flags[0] = (byte)path;
        }

        public static void DrawTest_SetTravelType(int travel)
        {
            DrawTest.Board[CurrentSpace].flags[1] = (byte)(Enum.GetValues(typeof(Space.TraversalFlags)) as int[])[travel];
        }
    }
}
