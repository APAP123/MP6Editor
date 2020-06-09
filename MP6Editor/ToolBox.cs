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
        Texture2D separationBar;
        Rectangle testTangle = new Rectangle(0, 0, 20, 20);
        public bool drawTypes = false;
        public int highlightSpace = -1;
        public int highlightPath = -1;
        private const int rowCount = 6; // Max amount of spaces to show per row

        private readonly string pathFlags = "Path Flags";

        List<Rectangle> spaceTangles = new List<Rectangle>(); // List of Space rectangles
        List<Rectangle> pathTangles = new List<Rectangle>(); // List of path rectangles
        Rectangle rectangle = new Rectangle(4, 4, 32, 32);
        Rectangle highRect = new Rectangle(0, 0, 40, 40);
        Rectangle separationRect = new Rectangle(0, 0, 0, 0);

        protected override void Initialize()
        {
            base.Initialize();
            separationRect = new Rectangle(0, 5, this.Width, 16);
            separationBar = Editor.Content.Load<Texture2D>(@"textures/separation_bar");

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

        /// <summary>
        /// Returns index of Rectangle containing mousePosition
        /// </summary>
        /// <param name="rectangles"></param>
        /// <param name="mousePosition"></param>
        /// <returns></returns>
        private int FindSelection(List<Rectangle> rectangles, Point mousePosition)
        {
            for (int i = 0; i < rectangles.Count; i++)
            {
                if (rectangles[i].Contains(mousePosition))
                {
                    return i;
                }
            }
            return -1;
        } // end FindSelection()

        /// <summary>
        ///  Handles mouse interaction with ToolBox.
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            if (e.Button == MouseButtons.Left)
            {
                var mouseState = Mouse.GetState();
                var mousePosition = new Point(mouseState.X, mouseState.Y);

                if ((highlightSpace = FindSelection(spaceTangles, mousePosition)) > -1) // Space types
                {
                    Mediator.DrawTest_SetSpaceType(highlightSpace);
                    return;
                }
                
                if ((highlightPath = FindSelection(pathTangles, mousePosition)) > -1) // Path variables
                {
                    Mediator.DrawTest_SetPathType(highlightPath);
                }
            }
        }// end OnMouseClick()

        /// <summary>
        /// Updates the toolbox with the passed List of Rectangles.
        /// </summary>
        /// <param name="rectangleList"></param>
        /// <param name="textureList"></param>
        protected void UpdateToolset(List<Rectangle> rectangleList, List<Texture2D> textureList, Rectangle rectangle)
        {
            // Create rectangle List that Draw() simply iterates through
            if (drawTypes && !rectangleList.Any())
            {
                int spacing = EquaDistance(this.Width, rowCount, rectangle);

                for (int i = 0; i < textureList.Count; i++)
                {
                    rectangleList.Add(rectangle);

                    // Moves to next row after 7 Spaces
                    if ((i > rowCount && i % rowCount == 0) || (i == rowCount - 1))
                    {
                        rectangle = new Rectangle(4, rectangle.Y + rectangle.Height + spacing, rectangle.Width, rectangle.Height);
                    }
                    else
                    {
                        rectangle = new Rectangle(rectangle.X + rectangle.Width + spacing, rectangle.Y, rectangle.Width, rectangle.Height);
                    }
                }
            }
        } // end UpdateToolset()

        /// <summary>
        /// Draws the passed Textures onto the passed Rectangles.
        /// </summary>
        /// <param name="textures"></param>
        /// <param name="rectangles"></param>
        protected void DrawToolSet(List<Texture2D> textures, List<Rectangle> rectangles, int highlight)
        {
            highRect = new Rectangle(0, 0, 40, 40);

            if (drawTypes && rectangles.Any()) // TODO: Possibly redundant if statement?
            {
                for (int i = 0; i < rectangles.Count; i++)
                {
                    Editor.spriteBatch.Draw(textures[i], rectangles[i], Color.White);

                    // Draw highlight around selected Space Type
                    if (i == highlight)
                    {
                        highRect = new Rectangle(rectangles[i].X - 4, rectangles[i].Y - 4, highRect.Width, highRect.Height);
                        Editor.spriteBatch.Draw(TextureManager.highlight, highRect, Color.White);
                    }
                }
            }
        } // end DrawToolSet()

        protected override void Update(GameTime gameTime)
        {
            UpdateToolset(spaceTangles, TextureManager.spaceTextures, new Rectangle(4, 4, 32, 32));
            if (spaceTangles.Any())
            {
                rectangle = spaceTangles[spaceTangles.Count - 1];
            }
            UpdateToolset(pathTangles, TextureManager.PathTextures, new Rectangle(4, rectangle.Y + rectangle.Height + separationRect.Height + 10, 32, 32));
        }

        protected override void Draw()
        {
            base.Draw();
            GraphicsDevice.Clear(Color.IndianRed);
            Editor.spriteBatch.Begin();

            DrawToolSet(TextureManager.spaceTextures, spaceTangles, highlightSpace); // Space types
            DrawToolSet(TextureManager.PathTextures, pathTangles, highlightPath); // Path variables

            if (spaceTangles.Any())
            {
                separationRect = new Rectangle(0, spaceTangles[spaceTangles.Count - 1].Y + rectangle.Height + 5, separationRect.Width, separationRect.Height);
            }
            Editor.spriteBatch.Draw(TextureManager.separationBar, separationRect, Color.White);
            TextureManager.DrawText2(pathFlags, new Vector2(separationRect.X, separationRect.Y), Editor.spriteBatch);

            Editor.spriteBatch.End();
        }
    }
}
