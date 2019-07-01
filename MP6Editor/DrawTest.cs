using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Windows.Forms;
using MonoGame.Forms.Controls;

namespace MP6Editor
{
    //class DrawTest : InvalidationControl
    class DrawTest : MonoGameControl
    {
        private string welcome = "Hello World!";
        public List<Space> Board = new List<Space>();
        Rectangle rectangle;
        Texture2D blankSpace;    //0
        Texture2D blueSpace;     //1
        Texture2D redSpace;      //2
        Texture2D happeningSpace;//3
        Texture2D miracleSpace;  //4
        Texture2D duelSpace;     //5
        Texture2D DKSpace;       //6
        Texture2D orbSpace;      //8
        Texture2D shopSpace;     //9
        Texture2D otherSpace;    //Everything else

        protected override void Initialize()
        {
            base.Initialize();
            Extractor extractor = new Extractor();
            Board = extractor.readFile();

            blankSpace = Editor.Content.Load<Texture2D>(@"Blank");         //0
            blueSpace = Editor.Content.Load<Texture2D>(@"Blue");           //1
            redSpace = Editor.Content.Load<Texture2D>(@"Red");             //2
            happeningSpace = Editor.Content.Load<Texture2D>(@"Happening"); //3
            miracleSpace = Editor.Content.Load<Texture2D>(@"Miracle");     //4
            duelSpace = Editor.Content.Load<Texture2D>(@"Dueling");        //5
            DKSpace = Editor.Content.Load<Texture2D>(@"DK");               //6
            
            orbSpace = Editor.Content.Load<Texture2D>(@"Orb");             //8
            shopSpace = Editor.Content.Load<Texture2D>(@"Shop");           //9
            otherSpace = Editor.Content.Load<Texture2D>(@"Other");         //Others
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.spriteBatch.Begin();

            Vector2 center = new Vector2((Editor.graphics.Viewport.Width / 2), (Editor.graphics.Viewport.Height / 2));

            for (int i = 0; i < Board.Count; i++)
            {
                Vector2 spot = new Vector2(center.X + (Board[i].X / 16), center.Y + (Board[i].Z / 16));
                rectangle = new Rectangle((int)spot.X, (int)spot.Y, 8, 8);
                Texture2D currSpace = getSpaceTexture(Board[i].type);

                
                //Editor.spriteBatch.Draw(currSpace, spot, Color.White);
                Editor.spriteBatch.Draw(currSpace, rectangle, Color.White);
            }

            Editor.spriteBatch.End();
        }

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);

            MessageBox.Show($"[{e.Button.ToString()}] mouse button pressed on control!", "Test_Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        //Get this type's matching texture
        Texture2D getSpaceTexture(int type)
        {
            switch (type)
            {
                case 0: //Blank
                    return blankSpace;
                case 1: //Blue
                    return blueSpace;
                case 2: //Red
                    return redSpace;
                case 3: //Happening
                    return happeningSpace;
                case 4: //Miracle
                    return miracleSpace;
                case 5: //Duel
                    return duelSpace;
                case 6: //DK/Bowser
                    return DKSpace;
                case 8: //Orb
                    return orbSpace;
                case 9: //Shop
                    return shopSpace;
                default: //Everything else
                    return otherSpace;
            }
        }//end getSpaceTexture()
    }
}
