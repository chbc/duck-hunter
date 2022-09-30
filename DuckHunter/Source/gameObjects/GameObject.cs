using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Jogo_de_tiro
{
    class GameObject
    {
        private Texture2D _texture;
        protected Rectangle _bounds;

        public Texture2D Texture
        {
            get
            {
                return _texture;
            }
        }

        public Rectangle Bounds
        { 
            get { return _bounds; }
        }

        public Point Location 
        {
            get {  return _bounds.Location; }
            set { _bounds.Location = value; }
        }

        public int Height
        {
            get
            {
                return _bounds.Height;
            }
        }

        public int Width
        {
            get
            {
                return _bounds.Width;
            }
        }

        public GameObject(Texture2D texture, Point position)
        {
            _texture = texture;
            _bounds = new Rectangle(position, new Point(_texture.Width, _texture.Height));
        }

        public GameObject(Texture2D texture, Rectangle rectangle)
        {
            _texture = texture;
            _bounds = rectangle;
        }

        public virtual void Update(double deltaTime) { }
    }
}
