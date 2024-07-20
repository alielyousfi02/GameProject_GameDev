using GameProject_GameDev.Levels;
using GameProject_GameDev.Levels.LevelBuilder;
using GameProject_GameDev.Players;
using GameProject_GameDev.Players.AntiHero;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
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
        Hero hero;
        public LevelState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            level1 = new Level1(content);
            curLevel = level1;
            hero = new Hero(new Vector2(500, 600));
            //Debug.WriteLine(curLevel.enemies.Count + " " + curLevel.enemies[0].GetType() + " " + curLevel.enemies[1].GetType());
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            curLevel.Draw(spriteBatch);
            hero.Draw(spriteBatch);

        }

        public override void LoadContent()
        {
            curLevel.LoadContent();
            hero.Load(content);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {
         

            curLevel.Update(gameTime);
            hero.Update(gameTime);
            foreach (CollisionTiles item in curLevel.map.CollisionTiles)
            {
                hero.ResolveCollisions(item.Rectangle, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight);
            }
            //Collect Star
            foreach (var item in curLevel.stars)
            {
                if (hero.HitBox.Intersects(item.HitBox))
                {
                    item.Collect();
                }
            }
            //Attack Hero Enemy
            foreach (Enemy item in curLevel.enemies)
            {
                if (item.IsAlive)
                {
                    if (hero.HitBox.Intersects(item.HitBox) && item.GetType() == typeof(StandingEnemy))
                    {
                        if (hero.HitBox.TouchTopOf(item.HitBox))
                        {
                            //Debug.WriteLine("kill");
                            item.Die();
                        }
                        else
                        {
                            hero.Die();
                        }

                    }
                    if (item is WalkingEnemy && hero.HitBox.Intersects(item.HitBox))
                    {
                        //Debug.WriteLine("test");
                        if (hero.IsAttacking)
                            item.Die();
                        else
                            hero.Die();
                    }
                }
            }
            if (!hero.IsAlive)
                game.ChangeState(new GameOverState(game, graphicsDevice, content));

        }
    }
}
