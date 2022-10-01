using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Jogo_de_tiro
{
    class MenuScreen
    {
        private Button _startButton;
        private Button _exitButton;
        private Button _creditsButton;
        private GameObject _background;

        public MenuScreen(ContentManager content, int screenWidth, int screenHeight)
        {
            Texture2D texture = content.Load<Texture2D>("start_button");
            int xPosition = (screenWidth - texture.Width) / 2;
            _startButton = new Button(texture, new Point(xPosition, 200));

            texture = content.Load<Texture2D>("credits_button");
            _creditsButton = new Button(texture, new Point(xPosition, 300));

            texture = content.Load<Texture2D>("exit_button");
            _exitButton = new Button(texture, new Point(xPosition, 400));

            texture = content.Load<Texture2D>("menu_background");
            _background = new GameObject(texture, new Rectangle(0, 0, screenWidth, screenHeight));
        }

        public void Initialize() { }

        public void Update(Game1 game, double deltaTime)
        {
#if !__MOBILE__
            if (!_isEscDown && (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Q)))
                game.Exit();
            else if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Space))
                game.ChangeScreen(EGameScreen.Game);
            if (_isEscDown && (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Released || Keyboard.GetState().IsKeyUp(Keys.Q)))
                _isEscDown = false;
#endif

            if (_startButton.IsPressed())
            {
                game.ChangeScreen(EGameScreen.Game);
            }
            else if (_creditsButton.IsPressed())
            {
                game.ChangeScreen(EGameScreen.Credits);
            }
            else if (_exitButton.IsPressed())
            {
                game.Exit();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background.Texture, _background.Bounds, Color.White);

            spriteBatch.Draw(_startButton.Texture, _startButton.Bounds, Color.White);
            spriteBatch.Draw(_creditsButton.Texture, _creditsButton.Bounds, Color.White);
            spriteBatch.Draw(_exitButton.Texture, _exitButton.Bounds, Color.White);
        }
    }
}
