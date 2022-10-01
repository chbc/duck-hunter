using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace Jogo_de_tiro
{
    class CreditsScreen
    {
        private GameObject _background;
        private bool _allowPress;

        public CreditsScreen(ContentManager content, int screenWidth, int screenHeight)
        {
            Texture2D texture = content.Load<Texture2D>("credits_background");
            _background = new GameObject(texture, new Rectangle(0, 0, screenWidth, screenHeight));
        }

        public void Initialize()
        {
            _allowPress = false;
        }

        public void Update(Game1 game, double deltaTime)
        {
            TouchCollection touches = TouchPanel.GetState();
            if
            (
                _allowPress &&
                (
                    (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed) ||
                    (touches.Count > 0)
                )
            )
            {
                game.ChangeScreen(EGameScreen.Menu);
            }
            else if (touches.Count < 1)
            {
                _allowPress = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background.Texture, _background.Bounds, Color.White);
        }
    }
}
