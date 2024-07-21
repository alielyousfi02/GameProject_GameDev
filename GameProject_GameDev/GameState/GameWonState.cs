using GameProject_GameDev.Button;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject_GameDev.GameState
{
    internal class GameWonState : State
    {
        private Texture2D gamewontexture;
        private SpriteFont font;
        private int score;
        public GameWonState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, int score = 0) : base(game, graphicsDevice, content)
        {
            gamewontexture = content.Load<Texture2D>("won");
            int xpos = ScreenSettings.ScreenWidth / 2 - 50;
            this.score = score;
            buttons.Add(new StartButton(game, graphicsDevice, content, new Vector2(xpos - 100, 600), "Play Again"));
            buttons.Add(new QuitButton(game, graphicsDevice, content, new Vector2(xpos + 100, 600), "Quit"));
            font = content.Load<SpriteFont>("Text");

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

           
            spriteBatch.Draw(gamewontexture, new Rectangle(0, 0, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight), Color.White);
            foreach (var item in buttons)
            {
                item.Draw(spriteBatch);
            }
            string scoreText = "Score: " + score;
            Vector2 scorePosition = new Vector2(ScreenSettings.ScreenWidth / 2-25, ScreenSettings.ScreenHeight - 200);
            spriteBatch.DrawString(font, scoreText, scorePosition, Color.White);

        }

        public override void LoadContent()
        {
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var item in buttons)
            {
                item.Update(gameTime);
            }
        }
    }
}
