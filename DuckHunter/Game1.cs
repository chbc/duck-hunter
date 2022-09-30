using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Jogo_de_tiro;

public class Game1 : Game
{
    private MenuScreen _menuScreen;
    private GameScreen _gameScreen;
    private GameOverScreen _gameOverScreen;

    private SpriteBatch _spriteBatch;
    private EGameScreen _gameScreenType;

    GraphicsDeviceManager _graphics;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.IsFullScreen = true;
        Content.RootDirectory = "Assets";
        IsMouseVisible = false;
    }

    public void ChangeScreen(EGameScreen newGameScreenType)
    {
        _gameScreenType = newGameScreenType;

        switch (_gameScreenType)
        {
            case EGameScreen.Menu:
                _menuScreen.Initialize();
                break;
            case EGameScreen.Game:
                _gameScreen.Initialize();
                break;
            case EGameScreen.GameOver:
                _gameOverScreen.Initialize();
                break;
            default: break;
        }

        _menuScreen.Initialize();
    }

    protected override void Initialize()
    {
        base.Initialize();
    }

    protected override void LoadContent()
    {
        DisplayMode displayMode = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode;
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        _menuScreen = new MenuScreen(Content, displayMode.Width, displayMode.Height);
        _gameScreen = new GameScreen(Content, displayMode.Width, displayMode.Height);
        _gameOverScreen = new GameOverScreen(Content, displayMode.Width, displayMode.Height);

        _gameScreenType = EGameScreen.Menu;
    }

    protected override void Update(GameTime gameTime)
    {
        switch (_gameScreenType)
        {
            case EGameScreen.Menu:
                _menuScreen.Update(this, gameTime.ElapsedGameTime.TotalSeconds);
                break;
            case EGameScreen.Game:
                _gameScreen.Update(this, gameTime.ElapsedGameTime.TotalSeconds);
                break;
            case EGameScreen.GameOver:
                _gameOverScreen.Update(this, gameTime.ElapsedGameTime.TotalSeconds);
                break;
            default: break;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        switch (_gameScreenType)
        {
            case EGameScreen.Menu:
                _menuScreen.Draw(_spriteBatch);
                break;
            case EGameScreen.Game:
                _gameScreen.Draw(_spriteBatch);
                break;
            case EGameScreen.GameOver:
                _gameOverScreen.Draw(_spriteBatch);
                break;
            default: break;
        }

        _spriteBatch.End();
        base.Draw(gameTime);
    }
}
