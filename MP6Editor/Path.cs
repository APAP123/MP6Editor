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
    public class Path
    {
        private Vector2 position;
        private Vector2 start;
        private Vector2 end;
        private float speed = 20;
        private float elapsed = 0.01f;

        private float distance;
        private Vector2 direction;
        public bool moving;

        public Texture2D bigPixel;
        private Rectangle rect;

        public Path(Vector2 start, Vector2 end)
        {
            this.start = start;
            this.end = end;
            //bigPixel = Editor.Content.Load<Texture2D>(@"BigPixel");
            rect = new Rectangle((int)start.X, (int)start.Y, 4, 4);

            distance = Vector2.Distance(this.start, this.end);
            direction = Vector2.Normalize(this.end - this.start);
            position = this.start;
            moving = true;
        }

        public void Update()
        {
            MovePath();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bigPixel, new Vector2(rect.X, rect.Y), Color.White);
        }

        //Moves the Path marker
        public void MovePath()
        {
            position += direction * speed * elapsed;
            rect.X = (int)position.X;
            rect.Y = (int)position.Y;
            if(Vector2.Distance(start, position) >= distance)
            {
                position = end;
                moving = false;
            }
        }//end Move()
    }
}
