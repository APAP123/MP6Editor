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
        /* Camera variables */
        private bool CamMouseDown = false;
        private System.Drawing.Point CamFirstMouseDownPosition;
        // X dimension for sprite
        private const int x = 8;
        // Y dimension for sprite
        private const int y = 8; 

        /* Public board-related variables to communicate with the form */
        public List<Space> Board = new List<Space>();
        // List of the visual positions on screen
        public List<Vector2> Positions = new List<Vector2>(); 
        public int SelectedSpace = -1;

        // Font drawing vars
        private SpriteFont font;
        public bool fontDraw = false;

        List<Path> Paths = new List<Path>();

        /* Path drawing timer vars */
        private const int TIMERMAX = 120;
        int PathTimer = 0;

        Vector2 trueCenter = new Vector2();

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

        Texture2D bigPixel;      //Path sprite placeholder

        protected override void Initialize()
        {
            base.Initialize();
            //Extractor extractor = new Extractor();
            //Board = extractor.readFile();

            //InitPositions();

            blankSpace = Editor.Content.Load<Texture2D>(@"Blank");         //0
            blueSpace = Editor.Content.Load<Texture2D>(@"Blue");           //1
            redSpace = Editor.Content.Load<Texture2D>(@"Red");             //2
            happeningSpace = Editor.Content.Load<Texture2D>(@"Happening"); //3
            miracleSpace = Editor.Content.Load<Texture2D>(@"Miracle");     //4
            duelSpace = Editor.Content.Load<Texture2D>(@"Dueling");        //5
            DKSpace = Editor.Content.Load<Texture2D>(@"DK");               //6
                                                                           //7
            orbSpace = Editor.Content.Load<Texture2D>(@"Orb");             //8
            shopSpace = Editor.Content.Load<Texture2D>(@"Shop");           //9
            otherSpace = Editor.Content.Load<Texture2D>(@"Other");         //Others

            font = Editor.Content.Load<SpriteFont>(@"SpaceIDs");
            bigPixel = Editor.Content.Load<Texture2D>(@"BigPixel");        //Path sprite placeholder
        }//end Initialize()

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            UpdatePath();

            for (int i = Paths.Count - 1; i >= 0; i--)
            {
                Paths[i].Update();
                if (!Paths[i].moving) //Remove if pixel reached destination
                {
                    Paths.RemoveAt(i);
                }
            }
        }

        protected override void Draw()
        {
            base.Draw();

            Editor.BeginCamera2D();
            //Editor.spriteBatch.Begin();

            Vector2 center = new Vector2((Editor.graphics.Viewport.Width / 2), (Editor.graphics.Viewport.Height / 2));
            trueCenter = center;

            // Path drawing
            foreach (Path path in Paths)
            {
                path.Draw(Editor.spriteBatch);
            }

            for (int i = 0; i < Board.Count; i++)
            {
                Vector2 spot = new Vector2(center.X + (Board[i].X / 16), center.Y + (Board[i].Z / 16));
                //Positions.Add(spot);
                Positions[i] = spot;
                rectangle = new Rectangle((int)Positions[i].X, (int)Positions[i].Y, 8, 8);
                Board[i].texture = getSpaceTexture(Board[i].type);

                Editor.spriteBatch.Draw(Board[i].texture, rectangle, Color.White);

                if (fontDraw)
                {
                    string text = ""+i;
                    //Editor.spriteBatch.DrawString(font, text, spot + new Vector2(-1f, -1f), Color.White);
                    //Editor.spriteBatch.DrawString(font, text, spot + new Vector2(1f, -1f), Color.White);
                    Editor.spriteBatch.DrawString(font, text, spot + new Vector2(-10, 0), Color.Black);
                }
            }

            //Editor.spriteBatch.End();
            Editor.EndCamera2D();
        }// end Draw()

        #region Mouse Input Events

        public void Board_OnMouseClick(MouseEventArgs e)
        {
            //base.OnMouseClick(e);
            if (e.Button == MouseButtons.Left)
            {
                var mouseState = Mouse.GetState();
                var mousePosition = new Point(mouseState.X, mouseState.Y);

                int space = IsOverSpace(mousePosition);

                if (space > -1)
                {
                    SelectedSpace = space;
                }
            }
        }// end Board_OnMouseClick()

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.Button == MouseButtons.Right)
            {
                CamMouseDown = false;
            }
        }// end OnMouseUp()

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

                CamFirstMouseDownPosition.X = e.Location.X;
                CamFirstMouseDownPosition.Y = e.Location.Y;
            }
        }

        // Zooms in camera
        public void Board_OnMouseWheelUpwards(MouseEventArgs e)
        {
            Editor.Cam.Zoom += 0.1f;
        }// end Board_OnMouseWheelUpwards()

        // Zooms out camera
        public void Board_OnMouseWheelDownwards(MouseEventArgs e)
        {
            if (Editor.Cam.Zoom > 0.7f) Editor.Cam.Zoom -= 0.1f;
        }// end Board_OnMouseWheelDownwards()

        #endregion

        // Converts passed world position to relative screen position
        Vector2 ToRelativePosition(Vector2 pos)
        {
            return pos - (Editor.Cam.Position - trueCenter);
        }// end To Relative Position

        // Determines if passed position is over a space
        int IsOverSpace(Point point)
        {
            for (int i = 0; i < Board.Count; i++)
            {
                Vector2 newPos = ToRelativePosition(new Vector2((int)Positions[i].X, (int)Positions[i].Y));
                Rectangle area = new Rectangle((int)newPos.X, (int)newPos.Y, 8, 8);
                if (area.Contains(point))
                {
                    return i;
                }
            }
            return -1;
        }// end isOverSpace()

        // Get this type's matching texture
        // TODO: can possibly move to Space.cs; could also do this with enums (see Form1 constructor)
        Texture2D getSpaceTexture(int type)
        {
            switch (type)
            {
                case 0: // Blank
                    return blankSpace;
                case 1: // Blue
                    return blueSpace;
                case 2: // Red
                    return redSpace;
                case 3: // Happening
                    return happeningSpace;
                case 4: // Miracle
                    return miracleSpace;
                case 5: // Duel
                    return duelSpace;
                case 6: // DK/Bowser
                    return DKSpace;
                case 8: // Orb
                    return orbSpace;
                case 9: // Shop
                    return shopSpace;
                default: // Everything else
                    return otherSpace;
            }
        }// end getSpaceTexture()

        // Sets the initial visual space positions read from the Board
        public void InitPositions()
        {
            Editor.BeginCamera2D();
            // Editor.spriteBatch.Begin();

            Vector2 center = new Vector2((Editor.graphics.Viewport.Width / 2), (Editor.graphics.Viewport.Height / 2));
            trueCenter = center;

            for (int i = 0; i < Board.Count; i++)
            {
                Vector2 spot = new Vector2(center.X + (Board[i].X / 16), center.Y + (Board[i].Z / 16));
                Positions.Add(spot);
                rectangle = new Rectangle((int)Positions[i].X, (int)Positions[i].Y, 8, 8);
                Board[i].texture = getSpaceTexture(Board[i].type);
                // Editor.spriteBatch.Draw(Board[i].texture, rectangle, Color.White);
            }

            Editor.EndCamera2D();
        }// end InitPositions()

        // Draws a moving path between linked spaces
        public void UpdatePath()
        {
            PathTimer++;
            if (PathTimer >= TIMERMAX)
            {
                PathTimer = 0;
            }
            if (PathTimer == 20 || PathTimer == 40 || PathTimer == 60)
            {
                for (int i = 0; i < Board.Count; i++)
                {
                    foreach (int link in Board[i].links)
                    {
                        Vector2 center = new Vector2((Editor.graphics.Viewport.Width / 2), (Editor.graphics.Viewport.Height / 2));

                        Vector2 start = new Vector2(center.X + (Board[i].X / 16), center.Y + (Board[i].Z / 16));
                        Vector2 end = new Vector2(center.X + (Board[link].X / 16), center.Y + (Board[link].Z / 16));

                        Path path = new Path(start, end);

                        path.bigPixel = bigPixel;
                        Paths.Add(path);
                    }// end foreach
                }// end for
            }// end if
        }// end DrawPath()
    }
}
