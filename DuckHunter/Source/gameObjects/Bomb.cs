using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

namespace Jogo_de_tiro
{
    class Bomb
    {
        AnimatedSprite _sprite;

        public Rectangle Bounds
        {
            get { return _sprite.Bounds; }
        }

        public Texture2D Texture
        {
            get { return _sprite.Texture; }
        }

        public Bomb(Texture2D texture, Point position)
        {
            ArrayList frames = new ArrayList()
            {
                new Rectangle(0, 0, 60, 100),
                new Rectangle(60, 0, 60, 100),
                new Rectangle(120, 0, 60, 100),
                new Rectangle(180, 0, 60, 100)
            };
            _sprite = new AnimatedSprite(texture, position, frames);
        }

        public void Update(double deltaTime)
        {
            const double SPEED = 300.0f;
            int resultSpeed = (int)(SPEED * deltaTime);
            Point newLocation = _sprite.Location;
            newLocation.Y = newLocation.Y + resultSpeed;

            _sprite.Location = newLocation;
            _sprite.Update(deltaTime);
        }

        public bool CheckCollision(Point targetPosition)
        {
            bool result = false;

            Rectangle bounds = this.GetFrameBounds();

            if ((targetPosition.X > bounds.X) && (targetPosition.X < bounds.X + bounds.Width))
            {
                if ((targetPosition.Y > bounds.Y) && (targetPosition.Y < bounds.Y + bounds.Height))
                {
                    result = true;                 
                }    
            }

            return result;
        }

        public void Restart(Random random, int ViewportWidth)
        {
            Rectangle drawArea = _sprite.GetDrawArea();
            int y = -_sprite.Height;
            int x = random.Next(0, (ViewportWidth - drawArea.Width));
            _sprite.Location = new Point(x, y);
        }

        public Rectangle GetDrawArea()
        {
            return _sprite.GetDrawArea();
        }

        public Rectangle GetFrameBounds()
        {
            return _sprite.GetFrameBounds();
        }
    }
}
