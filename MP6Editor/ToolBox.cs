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
        protected override void Initialize()
        {
            base.Initialize();

            bigPixel = Editor.Content.Load<Texture2D>(@"BigPixel");
        }//end Initialize()

        protected override void Update(GameTime gameTime)
        {
            /******TESTING******/
            //SpriteBatch spriteBatch = new SpriteBatch(GraphicsDevice);
            //Rectangle testTangle = new Rectangle(0, 0, 400, 400);
            //spriteBatch.Begin();
            //spriteBatch.Draw(bigPixel, testTangle, Color.White);
            //spriteBatch.End();
            /******END******/
        }

        protected override void Draw()
        {
            base.Draw();
            GraphicsDevice.Clear(Color.IndianRed);
            Editor.spriteBatch.Begin();
            Editor.spriteBatch.Draw(bigPixel, testTangle, Color.White);
            Editor.spriteBatch.End();
        }
    }
}
