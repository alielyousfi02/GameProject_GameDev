using GameProject_GameDev.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.GameState
{
    internal class LevelState : State
    {
        private Level1 level1;
        private Level curLevel;

        public LevelState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            level1 = new Level1(content);
            curLevel = level1;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            curLevel.Draw(spriteBatch);
        }

        public override void LoadContent()
        {
            curLevel.LoadContent();
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
            curLevel.Update(gameTime);
            if (level1.hero.IsAttacking)
            {
                Debug.WriteLine("attack");
            }
            else
            {
                Debug.WriteLine("stop");
            }

        }
    }
}
