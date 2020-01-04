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
    class TextureRetriever : MonoGameControl
    {
        private static readonly string Spaces_Directory = @"textures/spaces/";

        Texture2D bigPixel;      //Path sprite placeholder


        /// <summary>
        /// Get this type's matching texture.
        /// </summary>
        /// <param name="type">Type of Space.</param>
        /// <returns>Appropriate Texture for passed type; "X" Texture if unrecognized type.</returns>
        public List<Texture2D> GetSpaceTexture(int version)
        {
            switch (version)
            {
                case 4: // Mario Party 4
                    return MP4_GetSpaceTexture();
                case 5: // Mario Party 5
                    return MP5_GetSpaceTexture();
                case 6: // Mario Party 6
                    return MP6_GetSpaceTexture();
                case 7: // Mario Party 7
                    return MP7_GetSpaceTexture();
                default:
                    return MP7_GetSpaceTexture();
            }

        }// end getSpaceTexture()

        private List<Texture2D> MP4_GetSpaceTexture()
        {
            List <Texture2D> textures = new List<Texture2D>();
            foreach(string name in Enum.GetNames(typeof(Space.MP4_Types)))
            {
                textures.Add(Editor.Content.Load<Texture2D>(Spaces_Directory + name));
            }
            return textures;
        }

        private List<Texture2D> MP5_GetSpaceTexture()
        {
            List<Texture2D> textures = new List<Texture2D>();
            foreach (string name in Enum.GetNames(typeof(Space.MP5_Types)))
            {
                textures.Add(Editor.Content.Load<Texture2D>(Spaces_Directory + name));
            }
            return textures;
        }

        private List<Texture2D> MP6_GetSpaceTexture()
        {
            List<Texture2D> textures = new List<Texture2D>();
            foreach (string name in Enum.GetNames(typeof(Space.MP6_Types)))
            {
                textures.Add(Editor.Content.Load<Texture2D>(Spaces_Directory + name));
            }
            return textures;
        }

        private List<Texture2D> MP7_GetSpaceTexture()
        {
            List<Texture2D> textures = new List<Texture2D>();
            foreach (string name in Enum.GetNames(typeof(Space.MP7_Types)))
            {
                textures.Add(Editor.Content.Load<Texture2D>(Spaces_Directory + name));
            }
            return textures;
        }
    }
}
