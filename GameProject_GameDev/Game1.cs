using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject_GameDev
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        MainMenu main;
        Texture2D texture;
        Texture2D texture3;

        Texture2D texture2;
        SpriteFont font;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            _graphics.IsFullScreen = false;
            _graphics.PreferredBackBufferWidth = ScreenSettings.ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenSettings.ScreenHeight;
            _graphics.ApplyChanges();
            font = Content.Load<SpriteFont>("Text");
            texture2= new Texture2D(GraphicsDevice, 1, 1);
            texture3 = new Texture2D(GraphicsDevice, 1, 1);

            texture2.SetData(new[] { Color.White });
            texture3.SetData(new[] { Color.White });


            texture = Content.Load<Texture2D>("background");
            main = new MainMenu(texture, font, texture2, texture3);
            base.Initialize();


        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
            main.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            main.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}