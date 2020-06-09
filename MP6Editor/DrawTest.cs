﻿using System;
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
    class DrawTest : MonoGameControl
    {
        /* scaling factor */
        private readonly int SCALE = 32;

        /* Camera variables */
        private bool CamMouseDown = false;
        private System.Drawing.Point CamFirstMouseDownPosition;
        // X dimension for sprite
        private const int x = 8;
        // Y dimension for sprite
        private const int y = 8;

        /* For moving Spaces with mouse */
        private Point SelectFirstMouseDownPosition = new Point(0, 0);
        private bool SpaceMouseDown = false;

        /* Public board-related variables to communicate with the form */
        public List<Space> Board = new List<Space>();
        // List containing the on-screen visual positions of Spaces
        public List<Vector2> Positions = new List<Vector2>(); 
        public int SelectedSpace = -1;

        // Font drawing vars
        public bool fontDraw = false;
        private bool isLoaded = false;
        private readonly string welcomeText = "Open a Board to begin Editing!";

        List<Path> Paths = new List<Path>();

        /* Path drawing timer vars */
        private const int TIMERMAX = 120;
        int PathTimer = 0;

        Vector2 trueCenter = new Vector2();
        Rectangle rectangle;

        protected override void Initialize()
        {
            base.Initialize();
            TextureManager.Initialize(this);
            trueCenter = new Vector2((Editor.graphics.Viewport.Width / 2), (Editor.graphics.Viewport.Height / 2));
        }//end Initialize()

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            UpdatePath();

            for (int i = Paths.Count - 1; i >= 0; i--)
            {
                Paths[i].Update();
                if (!Paths[i].moving) // Remove if pixel reached destination
                {
                    Paths.RemoveAt(i);
                }
            }
        }

        // TODO: remove as much logic as possible from this function; should be in Update() instead.
        protected override void Draw()
        {
            base.Draw();
            Editor.BeginCamera2D();

            if (!isLoaded)
            {
                TextureManager.DrawText(welcomeText, trueCenter, Editor.spriteBatch);
            }

            // Path drawing
            foreach (Path path in Paths)
            {
                path.Draw(Editor.spriteBatch);
            }

            for (int i = 0; i < Board.Count; i++)
            {
                Vector2 spot = new Vector2(trueCenter.X + (Board[i].X / (SCALE/4)), trueCenter.Y + (Board[i].Z / (SCALE/4)));
                Positions[i] = spot;
                rectangle = new Rectangle((int)Positions[i].X, (int)Positions[i].Y, SCALE, SCALE);

                // draw highlight around selected Space
                if (i == SelectedSpace)
                {
                    Rectangle highRect = new Rectangle(rectangle.X - 4, rectangle.Y - 4, SCALE + 8, SCALE + 8);
                    Editor.spriteBatch.Draw(TextureManager.highlight, highRect, Color.White);
                }

                TextureManager.DrawSpace(Board[i], rectangle, Editor.spriteBatch);
                TextureManager.DrawBadges(Editor.spriteBatch, Board[i], rectangle);

                if (fontDraw)
                {
                    string text = ""+i;
                    spot = new Vector2(spot.X + (rectangle.Width / 2), spot.Y + (rectangle.Height / 2));
                    TextureManager.DrawText(text, spot, Editor.spriteBatch);
                }
            }

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
                    Mediator.CurrentSpace = SelectedSpace;
                    Mediator.ToolBox_SetSelected(Board[SelectedSpace].type);
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

            if (e.Button == MouseButtons.Left)
            {
                SpaceMouseDown = false;
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

            // To click and drag spaces
            if (e.Button == MouseButtons.Left)
            {
                int space = IsOverSpace(new Point(e.Location.X, e.Location.Y));

                if (space > -1)
                {
                    SelectedSpace = space;
                    SpaceMouseDown = true;
                    SelectFirstMouseDownPosition.X = e.Location.X;
                    SelectFirstMouseDownPosition.Y = e.Location.Y;
                }
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

            // Clicking and dragging to move a space.
            if (SpaceMouseDown)
            {
                int xFollow = (int)((SelectFirstMouseDownPosition.X - e.Location.X)*(SCALE/4) / Editor.Cam.Zoom);
                int yFollow = (int)((SelectFirstMouseDownPosition.Y - e.Location.Y)*(SCALE/4) / Editor.Cam.Zoom);

                Vector2 newPos = new Vector2(xFollow, yFollow);
                Board[SelectedSpace].X -= newPos.X;
                Board[SelectedSpace].Z -= newPos.Y;

                SelectFirstMouseDownPosition.X = e.Location.X;
                SelectFirstMouseDownPosition.Y = e.Location.Y;
            }
        }

        // Zooms in camera
        public void Board_OnMouseWheelUpwards(MouseEventArgs e)
        {
            if (Editor.Cam.Zoom < 3.0f) Editor.Cam.Zoom += 0.1f;
        }// end Board_OnMouseWheelUpwards()

        // Zooms out camera
        public void Board_OnMouseWheelDownwards(MouseEventArgs e)
        {
            if (Editor.Cam.Zoom > 0.7f) Editor.Cam.Zoom -= 0.1f;
        }// end Board_OnMouseWheelDownwards()

        #endregion

        /// <summary>
        /// Converts passed world position to relative screen position.
        /// </summary>
        /// <param name="pos">World position to be converted.</param>
        /// <returns>Relative position of passed world position.</returns>
        Vector2 ToRelativePosition(Vector2 pos)
        {
            return pos - (Editor.Cam.Position - trueCenter);
        }// end ToRelativePosition()

        // Converts passed relative screen position to world position
        Vector2 ToGlobalPosition(Vector2 pos)
        {
            return pos + (Editor.Cam.Position - trueCenter);
        }// end ToGlobalPosition()

        /// <summary>
        /// Determines if passed position is over a Space.
        /// </summary>
        /// <param name="point">Position to be checked.</param>
        /// <returns>Returns ID # of Space position is over; returns -1 if over no Space.</returns>
        int IsOverSpace(Point point)
        {
            for (int i = 0; i < Board.Count; i++)
            {
                Vector2 newPos = (new Vector2((int)Positions[i].X, (int)Positions[i].Y));
                newPos = Vector2.Transform(newPos, Editor.Cam.Transform);
                Rectangle area = new Rectangle((int)newPos.X, (int)newPos.Y, (int)(SCALE * Editor.Cam.Zoom), (int)(SCALE * Editor.Cam.Zoom));
                if (area.Contains(point))
                {
                    return i;
                }
            }
            return -1;
        }// end isOverSpace()

        /// <summary>
        /// Loads Space textures based on the current Mario Party version.
        /// </summary>
        /// /// <param name="version">Version of Mario Party being loaded.</param>
        public void LoadVersionTextures(int version)
        {
            TextureManager.LoadTextures(version);
        }

        /// <summary>
        /// Sets the initial visual space positions read from the Board.
        /// </summary>
        public void InitPositions()
        {
            isLoaded = true;
            Editor.BeginCamera2D();

            for (int i = 0; i < Board.Count; i++)
            {
                Vector2 spot = new Vector2(trueCenter.X + (Board[i].X / SCALE), trueCenter.Y + (Board[i].Z / SCALE));
                Positions.Add(spot);
                rectangle = new Rectangle((int)Positions[i].X, (int)Positions[i].Y, SCALE, SCALE);
            }

            Editor.EndCamera2D();
        }// end InitPositions()

        /// <summary>
        /// Removes the passed space from the board and updates IDs of all other spaces to reflect this.
        /// </summary>
        /// <param name="spaceNum">ID of Space to be removed.</param>
        public void RemoveSpace(int spaceNum)
        {
            //Positions.RemoveAt(spaceNum);
            Board.RemoveAt(spaceNum);

             // iterate through all Spaces.
            for(int i = 0; i < Board.Count(); i++)
            {
                // iterate through all links of an individual Space.
                for(int j = 0; j < Board[i].links.Count; j++)
                {
                    if(Board[i].links[j] == spaceNum)
                    {
                        Board[i].links.RemoveAt(j);
                    }
                    else if(Board[i].links[j] > spaceNum)
                    {
                        Board[i].links[j]--;
                    }
                }
            }
            InitPositions();
        } // end RemoveSpace()

        /// <summary>
        /// Draws a moving path between linked Spaces.
        /// </summary>
        private void UpdatePath()
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
                    foreach (int link in Board[i].links.Where(link => link < Board.Count))
                    {
                        Vector2 start = new Vector2(Positions[i].X - 2 + (SCALE / 2), Positions[i].Y - 2 + (SCALE / 2));
                        Vector2 end = new Vector2(Positions[link].X - 2 + (SCALE / 2), Positions[link].Y - 2 + (SCALE / 2));

                        Path path = new Path(start, end);
                        path.bigPixel = TextureManager.pathIndicator;
                        Paths.Add(path);
                    }// end foreach
                }// end for
            }// end if
        }// end DrawPath()
    }
}
