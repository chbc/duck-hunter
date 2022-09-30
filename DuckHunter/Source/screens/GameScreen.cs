using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;

namespace Jogo_de_tiro
{
    class GameScreen
    {
        private GameObject _defenseSpot;
        private Bomb _bomb;
        private Explosion _explosion;
        private Crosshair _sparks;
        private Score _hitScore;
        private Score _failScore;
        private GameObject _background;
        private Random _random;
        private double _duration;
        private bool _endTrasition;
        int _screenWidth;
        int _screenHeight;
        bool _isTouchEnabled;

        public GameScreen(ContentManager content, int screenWidth, int screenHeight)
        {
            _screenWidth = screenWidth;
            _screenHeight = screenHeight;
            SpriteFont gameFont = content.Load<SpriteFont>("arial24");
            _background = new GameObject(content.Load<Texture2D>("game_background"), new Rectangle(0, 0, screenWidth, screenHeight));
            _failScore = new Score(gameFont, 3, "Falhas:", new Vector2(10.0f, 50.0f));
            _hitScore = new Score(gameFont, 10, "Acertos:", new Vector2(10.0f, 10.0f));
            Texture2D texture = content.Load<Texture2D>("defense_spot");
            int yPositionDefense = (screenHeight - texture.Height);
            _defenseSpot = new GameObject(texture, new Point(0, yPositionDefense));

            texture = content.Load<Texture2D>("target_item");
            _bomb = new Bomb(texture, Point.Zero);

            texture = content.Load<Texture2D>("explosion");
            _explosion = new Explosion(texture, Point.Zero);

            texture = content.Load<Texture2D>("sparks");
            _sparks = new Crosshair(texture, Point.Zero);

            _random = new Random();
            _isTouchEnabled = true;
        }

        public void Initialize()
        {
            SetupValues();
        }

        public void Update(Game1 game, double deltaTime)
        {
            if (_endTrasition)
            {
                _duration = _duration + deltaTime;

                if (_duration > 2.0d)
                {
                    game.ChangeScreen(EGameScreen.GameOver);
                }
                return;
            }

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Q))
            {
                game.ChangeScreen(EGameScreen.Menu);
            }

            _bomb.Update(deltaTime);
            _sparks.Update(deltaTime);

            bool bombHit = false;

            TouchCollection touches = TouchPanel.GetState();
            if (touches.Count > 0)
            {
                if (_isTouchEnabled)
                {
                    _sparks.Stop();
                    _sparks.OnTouch(touches);
                    if (_bomb.CheckCollision(_sparks.Bounds.Location))
                    {
                        bombHit = true;
                        _hitScore.Increment();
                    }

                    _isTouchEnabled = false;
                }
            }
            else
            {
                _isTouchEnabled = true;
            }

            Rectangle bombBounds = _bomb.GetFrameBounds();

            if (bombHit || bombBounds.Y > _screenHeight - bombBounds.Height)
            {
                _explosion.Location = bombBounds.Location;
                _bomb.Restart(_random, _screenWidth);

                _explosion.Play();

                if (!bombHit)
                {
                    _failScore.Increment();
                }
            }

            _explosion.Update(deltaTime);

           
            if (_failScore.CheckMax())
            {
                _endTrasition = true;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_background.Texture, _background.Bounds, Color.White);
            spriteBatch.Draw(_defenseSpot.Texture, _defenseSpot.Bounds, Color.White);
            spriteBatch.Draw(_bomb.Texture, _bomb.GetFrameBounds(), _bomb.GetDrawArea(), Color.White);
            if (_explosion.Visible)
            {
                spriteBatch.Draw(_explosion.Texture, _explosion.Bounds, Color.White);
            }

            if (_sparks.Visible)
            {
                spriteBatch.Draw(_sparks.Texture, _sparks.Bounds, Color.White);
            }

            spriteBatch.DrawString(_hitScore.GameFont, _hitScore.Message, _hitScore.Position, Color.White);
            spriteBatch.DrawString(_failScore.GameFont, _failScore.Message, _failScore.Position, Color.White);
        }

        private void SetupValues()
        {
            _explosion.Stop();
            _sparks.Stop();
            _hitScore.Reset();
            _failScore.Reset();
            _duration = 0;
            _endTrasition = false;
        }
    }
}
