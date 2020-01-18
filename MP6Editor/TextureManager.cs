/*************************************
 * TexutreManager.cs   
 *
 * Handles all texture loading used
 * throughout the program.
 *************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using MonoGame.Forms.Controls;
using Microsoft.Xna.Framework.Input;

namespace MP6Editor
{
    class TextureManager : MonoGameControl
    {
        public List<Texture2D> spaceTextures = new List<Texture2D>();

        Texture2D pathIndicator;
        Texture2D highlight;

        /// <summary>
        /// Loads textures based on passed MP version.
        /// </summary>
        /// <param name="version">MP version to load.</param>
        public void LoadTextures(int version)
        {
            foreach (string name in NameRetriever.GetTextureNames(version))
            {
                spaceTextures.Add(Editor.Content.Load<Texture2D>(name));
            }

            pathIndicator = Editor.Content.Load<Texture2D>(@"BigPixel");
            highlight = Editor.Content.Load<Texture2D>(@"Selected");
        }
    }
}
