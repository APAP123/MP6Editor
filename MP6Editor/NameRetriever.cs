using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Forms.Controls;

namespace MP6Editor
{
    static class NameRetriever
    {
        private static readonly string Spaces_Directory = @"textures/spaces/";


        /// <summary>
        /// Get this type's matching texture.
        /// </summary>
        /// <param name="type">Type of Space.</param>
        /// <returns>Appropriate Texture for passed type; "X" Texture if unrecognized type.</returns>
        static public List<string> GetTextureNames(int version)
        {
            switch (version)
            {
                case 4: // Mario Party 4
                    return MP4_GetSpaceTexture(Spaces_Directory);
                case 5: // Mario Party 5
                    return MP5_GetSpaceTexture(Spaces_Directory);
                case 6: // Mario Party 6
                    return MP6_GetSpaceTexture(Spaces_Directory);
                case 7: // Mario Party 7
                    return MP7_GetSpaceTexture(Spaces_Directory);
                default:
                    return MP7_GetSpaceTexture(Spaces_Directory);
            }

        }// end getTextureNames()

        static public List<string> GetSpaceNames(int version)
        {
            switch (version)
            {
                case 4: // Mario Party 4
                    return MP4_GetSpaceTexture("");
                case 5: // Mario Party 5
                    return MP5_GetSpaceTexture("");
                case 6: // Mario Party 6
                    return MP6_GetSpaceTexture("");
                case 7: // Mario Party 7
                    return MP7_GetSpaceTexture("");
                default:
                    return MP7_GetSpaceTexture("");
            }

        }// end getTextureNames()

        static private List<string> MP4_GetSpaceTexture(string directory)
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.MP4_Types)))
            {
                names.Add(directory + name);
            }
            return names;
        }

        static private List<string> MP5_GetSpaceTexture(string directory)
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.MP5_Types)))
            {
                names.Add(directory + name);
            }
            return names;
        }

        static private List<string> MP6_GetSpaceTexture(string directory)
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.MP6_Types)))
            {
                names.Add(directory + name);
            }
            return names;
        }

        static private List<string> MP7_GetSpaceTexture(string directory)
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.MP7_Types)))
            {
                names.Add(directory + name);
            }
            return names;
        }
    }
}
