using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Jogo_de_tiro
{
    class Crosshair : Explosion
    {
       public Crosshair(Texture2D texture, Point position) : base(texture, position)
        {
        
        }

        public void OnTouch(TouchCollection touches)
        {
            if (!base.Visible && (touches.Count == 1))
            {
                _bounds.X = (int) (touches[0].Position.X - (Width / 2.0f));
                _bounds.Y = (int) (touches[0].Position.Y - (Height / 2.0f));

                base.Play();
            }
        }
    }
}
