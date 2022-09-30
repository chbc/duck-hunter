using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Jogo_de_tiro
{
    class AnimatedSprite : GameObject
    {
        private ArrayList _frames;
        private int _index;
        private double _duration;

        public AnimatedSprite(Texture2D texture, Point position, ArrayList frames) : base(texture, position)
        {
            _frames = frames;
            _index = 0;
            _duration = 0;
        }

        public override void Update(double deltaTime)
        {
            _duration = _duration + deltaTime;
            if (_duration > 0.25)
            {
                _duration = 0;

                _index++;
                if (_index > _frames.Count - 1)
                {
                    _index = 0;
                }
            }
        }

        public Rectangle GetDrawArea()
        {
            Rectangle result = (Rectangle)_frames[_index];
            return result;
        }

        public Rectangle GetFrameBounds()
        {
            Rectangle result = (Rectangle)_frames[_index];
            result.Location = Location;
            return result;
        }
    }
}
