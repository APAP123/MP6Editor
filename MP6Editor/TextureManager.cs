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
    static class TextureManager
    {
        private static SpriteFont font;
        private static SpriteFont font2;

        public static List<Texture2D> spaceTextures = new List<Texture2D>();
        public static List<Texture2D> PathTextures = new List<Texture2D>();
        public static List<Texture2D> TraversalTextures = new List<Texture2D>();

        public static Texture2D pathIndicator;
        public static Texture2D highlight;
        public static Texture2D separationBar;
        private static Texture2D starBadge;
        
        private static MonoGameControl mono;

        public static void Initialize(MonoGameControl gameControl)
        {
            mono = gameControl;
            pathIndicator = gameControl.Editor.Content.Load<Texture2D>(@"BigPixel");
            highlight = gameControl.Editor.Content.Load<Texture2D>(@"Selected");
            starBadge = gameControl.Editor.Content.Load<Texture2D>(@"textures/badges/Star");
            separationBar = gameControl.Editor.Content.Load<Texture2D>(@"textures/separation_bar");
            font = gameControl.Editor.Content.Load<SpriteFont>(@"SpaceIDs");
            font2 = gameControl.Editor.Content.Load<SpriteFont>(@"DelineationHeadlines");
        }


        /// <summary>
        /// Loads textures based on passed MP version.
        /// </summary>
        /// <param name="version">MP version to load.</param>
        /// 
        public static void LoadTextures(int version)
        {
            spaceTextures.Clear();
            PathTextures.Clear();
            TraversalTextures.Clear();

            // Space textures
            foreach (string name in NameRetriever.GetTextureNames(version))
            {
                spaceTextures.Add(mono.Editor.Content.Load<Texture2D>(name));
            }

            // Path flag badge textures
            foreach (string name in NameRetriever.GetPathTextureNames())
            {
                PathTextures.Add(mono.Editor.Content.Load<Texture2D>(name));
            }

            // Traversal flag badge textures
            foreach (string name in NameRetriever.GetTraversalTextureNames())
            {
                TraversalTextures.Add(mono.Editor.Content.Load<Texture2D>(name));
            }
        }

        public static void DrawSpace(Space space, Rectangle rectangle, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(spaceTextures[space.type], rectangle, Color.White);
        }

        /// <summary>
        /// Draws badges near Spaces to represent flag values.
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="space">Space to be drawn.</param>
        /// <param name="rectangle">Area where space will be drawn at.</param>
        public static void DrawBadges(SpriteBatch spriteBatch, Space space, Rectangle rectangle)
        {
            //Rectangle badgeTangle = new Rectangle(rectangle.X + 24, rectangle.Y + 20, SCALE / 2, SCALE / 2);
            Rectangle badgeTangle = new Rectangle(rectangle.X + 24, rectangle.Y + 20, rectangle.Width / 2, rectangle.Height / 2);

            Space.PathFlags path = (Space.PathFlags)space.flags[0];
            Space.TraversalFlags traversal = (Space.TraversalFlags)space.flags[1];

            // Path badge
            int index = Array.IndexOf(Enum.GetValues(path.GetType()), path);

            if (index > 0)
            {
                spriteBatch.Draw(PathTextures[index], badgeTangle, Color.White);
                badgeTangle = new Rectangle(badgeTangle.X, badgeTangle.Y - 16, badgeTangle.Width, badgeTangle.Height);
            }

            // Travel badge
            index = Array.IndexOf(Enum.GetValues(traversal.GetType()), traversal);
            if (index > 0)
            {
                spriteBatch.Draw(TraversalTextures[index], badgeTangle, Color.White);
            }

            // Star-hosting badge
            if (space.flags[5] == 0x80)
            {
                badgeTangle = new Rectangle(rectangle.X - 8, rectangle.Y + 20, badgeTangle.Width, badgeTangle.Height);
                spriteBatch.Draw(starBadge, badgeTangle, Color.White);
            }
        }// end DrawBadges()

        public static void DrawText(string text, Vector2 position, SpriteBatch spriteBatch)
        {
            Vector2 stringSize = font.MeasureString(text);
            Vector2 newPos = new Vector2(position.X - (stringSize.X / 2), position.Y - (stringSize.Y / 2));
            spriteBatch.DrawString(font, text, position + new Vector2(-1, -1), Color.Black, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, text, position + new Vector2(1, -1), Color.Black, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font, text, position, Color.White);
        }

        public static void DrawText2(string text, Vector2 position, SpriteBatch spriteBatch)
        {
            Vector2 stringSize = font2.MeasureString(text);
            Vector2 newPos = new Vector2(position.X - (stringSize.X / 2), position.Y - (stringSize.Y / 2));
            spriteBatch.DrawString(font2, text, position + new Vector2(-1, -1), Color.Black, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font2, text, position + new Vector2(1, -1), Color.Black, 0, Vector2.Zero, 1f, SpriteEffects.None, 0f);
            spriteBatch.DrawString(font2, text, position, Color.White);
        }
    }
}
