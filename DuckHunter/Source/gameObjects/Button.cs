using Android.Text.Method;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Jogo_de_tiro
{
    class Button : GameObject
    {
        public Button(Texture2D texture, Point position) : base (texture, position)
        {

        }

        public bool IsPressed()
        {
#if __MOBILE__
            TouchCollection touches = TouchPanel.GetState();
            
            foreach (TouchLocation item in touches)
            {
                Vector2 touchPosition = item.Position;
                float x = touchPosition.X;
                float y = touchPosition.Y;

                if ((x > _bounds.X) && (x < _bounds.X + Width))
                {
                    if ((y > _bounds.Y) && (y < _bounds.Y + Height))
                    {
                        return true;
                    }
                }
            }
#else
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                int x = Mouse.GetState().X;
                int y = Mouse.GetState().Y;

                if ((x > Position.X) && (x < Position.X + Width))
                {
                    if ((y > Position.Y) && (y < Position.Y + Height))
                    {
                        return true;
                    }
                }
            }
#endif

            return false;
        }
    }
}
