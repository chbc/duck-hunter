using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input.Touch;

namespace Jogo_de_tiro
{
    class GameOverScreen
    {
        private GameObject _background;

        public GameOverScreen(ContentManager content, int screenWidth, int screenHeight)
        {
            Texture2D texture = content.Load<Texture2D>("end_background");
            _background = new GameObject(texture, new Rectangle(0, 0, screenWidth, screenHeight));
        }

        public void Initialize() { }

        public void Update(Game1 game, double deltaTime)
        {
#if __MOBILE__
            if (TouchPanel.GetState().Count > 0)
#else
            if (Mouse.GetState().LeftButton == ButtonState.Pressed)
#endif
            {
                game.ChangeScreen(EGameScreen.Game);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background.Texture, _background.Bounds, Color.White);
        }
    }
}
