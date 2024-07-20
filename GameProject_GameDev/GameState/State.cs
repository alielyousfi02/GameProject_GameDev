using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.GameState
{
    //bron: https://www.youtube.com/watch?v=L3US4AmPuG4
    public abstract class State
    {
        protected ContentManager content;
        protected GraphicsDevice graphicsDevice;
        protected Game1 game;
        internal List<Button.Button> buttons;
        public abstract void LoadContent();

        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void PostUpdate(GameTime gameTime);

        public State(Game1 game, GraphicsDevice graphicsDevice, ContentManager content)
        {
            this.game = game;

            this.graphicsDevice = graphicsDevice;
            buttons = new List<Button.Button>();
            this.content = content;
        }
        public abstract void Update(GameTime gameTime);
    }
}
