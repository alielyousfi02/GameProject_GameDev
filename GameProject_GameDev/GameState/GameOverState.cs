using GameProject_GameDev.Button;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.GameState
{
    internal class GameOverState : State
    {
        private Texture2D gameovertexture;
        
        public GameOverState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            int xpos = ScreenSettings.ScreenWidth / 2 - 50;
            buttons.Add(new StartButton(game, graphicsDevice, content, new Vector2(xpos-100, 600), "Restart"));
            buttons.Add(new QuitButton(game, graphicsDevice, content, new Vector2(xpos + 100, 600), "Quit"));
            gameovertexture = content.Load<Texture2D>("gameover");
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            Texture2D blackBackground = new Texture2D(graphicsDevice, 1, 1);
            blackBackground.SetData(new[] { Color.Black });
            spriteBatch.Draw(blackBackground, new Rectangle(0, 0, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight), Color.White);
            spriteBatch.Draw(gameovertexture, new Rectangle(0, 0, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight), Color.White);
            foreach (var item in buttons)
            {
                item.Draw(spriteBatch);
            }

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
