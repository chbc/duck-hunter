using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Jogo_de_tiro
{
    class Explosion : GameObject
    {
        private bool _visible;
        private double _duration; 

        public bool Visible
        {
            get
            {
                return _visible;
            }
        }

        public Explosion(Texture2D texture, Point position) : base(texture, position)
        {

        }

        public void Play()
        {
            _visible = true;
            _duration = 0.0d;
        }

        public void Stop()
        {
            _visible = false;
        }

        public override void Update(double deltaTime)
        {
            if (_visible)
            {
                _duration = _duration + deltaTime;

                if (_duration > 1.0d)
                {
                    _visible = false;
                }
            }
        }
    }
}
