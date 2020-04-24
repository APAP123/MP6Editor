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
    class ToolBox : MonoGameControl
    {
        Texture2D bigPixel;
        Rectangle testTangle = new Rectangle(0, 0, 20, 20);
        public bool drawTypes = false;
        public int highlightSpace = -1;
        private const int rowCount = 6;

        List<Rectangle> rectangles = new List<Rectangle>();
        Rectangle rectangle = new Rectangle(4, 4, 32, 32);
        Rectangle highRect = new Rectangle(0, 0, 40, 40);

        protected override void Initialize()
        {
            base.Initialize();

            bigPixel = Editor.Content.Load<Texture2D>(@"BigPixel");
        }//end Initialize()

        /// <summary>
        /// Finds how far out to space the rectangles given a width, the amount of rectangles, and the rectangle itself.
        /// </summary>
        /// <param name="width">Width of area to fit rectangles in.</param>
        /// <param name="rectCount">Amount of rectangles to fit in area</param>
        /// <param name="rect">Rectangle base being fit.</param>
        private int EquaDistance(int width, int rectCount, Rectangle rect)
        {
            if(rectCount * rect.Width >= width)
            {
                return 0;
            }
            int spacing = width - (rectCount * rect.Width);
            spacing = spacing / rectCount;
            return spacing;
        }// end EquaDistance()

        protected override void Update(GameTime gameTime)
        {
            /******TESTING******/
            //SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            //Rectangle testTangle = new Rectangle(0, 0, 400, 400);
            //spriteBatch.Begin();
            //spriteBatch.Draw(bigPixel, testTangle, Color.White);
            //spriteBatch.End();
            /******END******/

            // Create rectangle List that Draw() simply iterates through
            if (drawTypes && !rectangles.Any())
            {
                rectangle = new Rectangle(4, 4, 32, 32);

                int spacing = EquaDistance(this.Width, rowCount, rectangle);

                for (int i = 0; i < TextureManager.spaceTextures.Count; i++)
                {
                    rectangles.Add(rectangle);

                    // Moves to next row after 7 Spaces
                    if (i > 0 && i % (rowCount - 1) == 0)
                    {
                        rectangle = new Rectangle(4, rectangle.Y + rectangle.Height + spacing, rectangle.Width, rectangle.Height);
                    }
                    else
                    {
                        rectangle = new Rectangle(rectangle.X + rectangle.Width + spacing, rectangle.Y, rectangle.Width, rectangle.Height);
                    }
                }
            }
        }

        protected override void Draw()
        {
            base.Draw();
            GraphicsDevice.Clear(Color.IndianRed);
            Editor.spriteBatch.Begin();
            //Editor.spriteBatch.Draw(bigPixel, testTangle, Color.White);

            //rectangle = new Rectangle(4, 4, 32, 32);

            highRect = new Rectangle(0, 0, 40, 40);

            if (drawTypes && rectangles.Any())
            {

                for (int i = 0; i < rectangles.Count; i++)
                {
                    Editor.spriteBatch.Draw(TextureManager.spaceTextures[i], rectangles[i], Color.White);

                    // Draw highlight around selected Space Type
                    if (i == highlightSpace)
                    {
                        highRect = new Rectangle(rectangles[i].X - 4, rectangles[i].Y - 4, highRect.Width, highRect.Height);
                        Editor.spriteBatch.Draw(TextureManager.highlight, highRect, Color.White);
                    }
                }
            }

            Editor.spriteBatch.End();
        }
    }
}
