/*************************************
 * NameRetriever.cs   
 *
 * Retrieves list of valid Space types
 * or textures for passed MP version.
 *************************************/
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
        /// Gets texture locations for passed game version.
        /// </summary>
        /// <param name="version">Version of Mario Party.</param>
        /// <returns>String list of each texture's location.</returns>
        static public List<string> GetTextureNames(int version)
        {
            switch (version)
            {
                case 4: // Mario Party 4
                    return MP4_GetSpaceTypes(Spaces_Directory);
                case 5: // Mario Party 5
                    return MP5_GetSpaceTypes(Spaces_Directory);
                case 6: // Mario Party 6
                    return MP6_GetSpaceTypes(Spaces_Directory);
                case 7: // Mario Party 7
                    return MP7_GetSpaceTypes(Spaces_Directory);
                default:
                    return MP7_GetSpaceTypes(Spaces_Directory);
            }

        }// end getTextureNames()

        /// <summary>
        /// Gets names of valid Space types for the passed Mario Party version.
        /// </summary>
        /// <param name="version">Version of Mario Party.</param>
        /// <returns>String list of each valid type.</returns>
        static public List<string> GetSpaceNames(int version)
        {
            switch (version)
            {
                case 4: // Mario Party 4
                    return MP4_GetSpaceTypes("");
                case 5: // Mario Party 5
                    return MP5_GetSpaceTypes("");
                case 6: // Mario Party 6
                    return MP6_GetSpaceTypes("");
                case 7: // Mario Party 7
                    return MP7_GetSpaceTypes("");
                default:
                    return MP7_GetSpaceTypes("");
            }

        }// end getSpaceNames()

        static private List<string> MP4_GetSpaceTypes(string prepend)
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.MP4_Types)))
            {
                names.Add(prepend + name);
            }
            return names;
        }

        static private List<string> MP5_GetSpaceTypes(string prepend)
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.MP5_Types)))
            {
                names.Add(prepend + name);
            }
            return names;
        }

        static private List<string> MP6_GetSpaceTypes(string prepend)
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.MP6_Types)))
            {
                names.Add(prepend + name);
            }
            return names;
        }

        static private List<string> MP7_GetSpaceTypes(string prepend)
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.MP7_Types)))
            {
                names.Add(prepend + name);
            }
            return names;
        }

        static public List<string> MP6_GetPathFlags()
        {
            List<string> names = new List<string>();
            foreach(string name in Enum.GetNames(typeof(Space.PathFlags)))
            {
                names.Add(name);
            }
            return names;
        }

        static public List<string> MP6_GetTraversalFlags()
        {
            List<string> names = new List<string>();
            foreach (string name in Enum.GetNames(typeof(Space.TraversalFlags)))
            {
                names.Add(name);
            }
            return names;
        }
    }
}
