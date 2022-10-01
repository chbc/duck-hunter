using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;

namespace Jogo_de_tiro
{
    class Bomb
    {
        AnimatedSprite _sprite;
        int _xDirection;
        int _speed;
        int _xSpeedModifier;

        const int INITIAL_SPEED = 200;
        const int INITIAL_POSITION_OFFSET = 200;

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
                new Rectangle(0, 0, 100, 100),
                new Rectangle(100, 0, 100, 100),
                new Rectangle(200, 0, 100, 100),
                new Rectangle(300, 0, 100, 100)
            };

            _sprite = new AnimatedSprite(texture, position, frames);
            _xDirection = 1;
            _xSpeedModifier = 1;
        }

        public void Initialize()
        {
            _speed = INITIAL_SPEED;
        }

        public void Update(double deltaTime)
        {
            int resultSpeed = (int)(_speed * deltaTime);
            Point newLocation = _sprite.Location;
            newLocation.Y = newLocation.Y - resultSpeed;
            newLocation.X = newLocation.X + (resultSpeed * (_xDirection * _xSpeedModifier));

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

        public void CheckSideCollision(int screenWidth)
        {
            Rectangle bounds = this.GetFrameBounds();
            if (bounds.X < 0)
            {
                _xDirection = 1;
            }
            else if  ((bounds.X + bounds.Width) > screenWidth)
            {
                _xDirection = -1;
            }
        }

        public void Restart(Random random, int screenWidth, int screenHeight)
        {
            Rectangle bounds = _sprite.GetFrameBounds();
            int y = screenHeight - INITIAL_POSITION_OFFSET;
            int x = random.Next(0, (screenWidth - bounds.Width));
            _sprite.Location = new Point(x, y);
            _speed += 10;
            _xSpeedModifier = (_xSpeedModifier == 1) ? 2 : 1;
            _xDirection = -_xDirection;
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
