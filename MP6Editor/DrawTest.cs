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
    //class DrawTest : InvalidationControl
    class DrawTest : MonoGameControl
    {
        //Camera variables
        private bool CamMouseDown = false;
        private System.Drawing.Point CamFirstMouseDownPosition;
        private const int x = 8; //X dimension for sprite
        private const int y = 8; //Y dimension for sprite

        public List<Space> Board = new List<Space>();
        public List<Vector2> Positions = new List<Vector2>(); //List of the visual positions on screen

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

            Editor.BeginCamera2D();
            //Editor.spriteBatch.Begin();

            Vector2 center = new Vector2((Editor.graphics.Viewport.Width / 2), (Editor.graphics.Viewport.Height / 2));

            for (int i = 0; i < Board.Count; i++)
            {
                Vector2 spot = new Vector2(center.X + (Board[i].X / 16), center.Y + (Board[i].Z / 16));
                Positions.Add(spot);
                rectangle = new Rectangle((int)Positions[i].X, (int)Positions[i].Y, 8, 8);
                //Texture2D currSpace = getSpaceTexture(Board[i].type);
                Board[i].texture = getSpaceTexture(Board[i].type);

                //Editor.spriteBatch.Draw(currSpace, spot, Color.White);
                Editor.spriteBatch.Draw(Board[i].texture, rectangle, Color.White);
            }

            //Editor.spriteBatch.End();
            Editor.EndCamera2D();
        }

        #region Mouse Input Events

        protected override void OnMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                var mouseState = Mouse.GetState();
                var mousePosition = new Point(mouseState.X, mouseState.Y);

                Vector2 newpos = GetWorldPosition(new Vector2(mouseState.X, mouseState.Y));

                int space = isOverSpace(mousePosition);
                //int space = isOverSpace(newpos);
                if (space > -1)
                {
                    Board[space].type = 10;
                }
            }
            //MessageBox.Show($"[{e.Button.ToString()}] mouse button pressed on control!", "Test_Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Right)
            {
                CamMouseDown = false;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.Button == MouseButtons.Right)
            {
                CamFirstMouseDownPosition = e.Location;
                CamMouseDown = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (CamMouseDown)
            {
                int xDiff = CamFirstMouseDownPosition.X - e.Location.X;
                int yDiff = CamFirstMouseDownPosition.Y - e.Location.Y;

                Editor.MoveCam(new Vector2(xDiff, yDiff));
                //Editor.MoveCam(new Vector2(2000, 2000));

                CamFirstMouseDownPosition.X = e.Location.X;
                CamFirstMouseDownPosition.Y = e.Location.Y;
            }
        }

        public void Board_OnMouseWheelUpwards(MouseEventArgs e)
        {
            Editor.Cam.Zoom += 0.1f;
        }

        public void Board_OnMouseWheelDownwards(MouseEventArgs e)
        {
            if (Editor.Cam.Zoom > 0.7f) Editor.Cam.Zoom -= 0.1f;
        }

        #endregion
        //Get point converted to world position
        public Vector2 GetWorldPosition(Vector2 position)
        {
            return position + Editor.Cam.Position;
        }//end GetWorldPosition()

        //Determines if passed position is over a space
        int isOverSpace(Point point)
        {
            for (int i = 0; i < Board.Count; i++)
            {
                Rectangle area = new Rectangle((int)Positions[i].X, (int)Positions[i].Y, 8, 8);
                if (area.Contains(point))
                {
                    return i;
                }
            }
            return -1;
        }//end isOverSpace()

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
