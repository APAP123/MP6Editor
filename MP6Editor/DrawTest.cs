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
    class DrawTest : InvalidationControl
    {
        private string welcome = "Hello World!";

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            Rectangle rectangle = new Rectangle(0, 0, 60, 60);
            Color color = new Color(0, 0, 0);
            Texture2D texture = Editor.Content.Load<Texture2D>(@"Red");

            Editor.spriteBatch.Draw(texture, rectangle, Color.White);

            Editor.spriteBatch.DrawString(Editor.Font, welcome, new Vector2(
                    (Editor.graphics.Viewport.Width / 2) - (Editor.Font.MeasureString(welcome).X / 2),
                    (Editor.graphics.Viewport.Height / 2) - (Editor.FontHeight / 2)),
                      Color.White);

           

            Editor.spriteBatch.End();
        }
    }
}
