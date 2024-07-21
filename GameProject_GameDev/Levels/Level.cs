using GameProject_GameDev.Levels.LevelBuilder;
using GameProject_GameDev.Players;
using GameProject_GameDev.Players.AntiHero;
using GameProject_GameDev.StarMap;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameProject_GameDev.Levels
{
    internal abstract class Level
    {
        internal Map map;
        protected ContentManager content;
        internal List<Enemy> enemies;
        internal List<Star> stars;
        internal Hero hero;
        public Level(ContentManager content, Hero hero)
        {
            this.content = content;
            map = new Map();

            enemies = new List<Enemy>();
            stars = new List<Star>();
            
        }

        public virtual void Load()
        {
            foreach (var item in enemies)
            {
                if (item is WalkingEnemy)
                    item.Load();
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            foreach (var item in enemies)
            {
                item.Update(gameTime);
            }
            foreach (var item in stars)
            {
                item.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(content.Load<Texture2D>("beachbackground"), new Rectangle(0, 0, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight), Color.White);
            foreach (var item in enemies)
            {
                item.Draw(spriteBatch);
            }
            foreach (var item in stars)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}
