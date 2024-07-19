using GameProject_GameDev.Levels;
using GameProject_GameDev.Levels.LevelBuilder;
using GameProject_GameDev.Players;
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
        public LevelState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) :  base(game, graphicsDevice, content)
        {
            level1 = new Level1(content);
            curLevel = level1;
            hero = new Hero(new Vector2(500, 100));
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
            foreach (var item in curLevel.walkingEnemies)
            {
                if (hero.HitBox.Intersects(item.HitBox))
                {
                    if(hero.IsAttacking)
                        item.Die();
                    else
                        game.ChangeState(new GameOverState(game, graphicsDevice, content));

                    
                }
              
            }
            foreach (var item in curLevel.standingEnemies)
            {
                if (hero.HitBox.Intersects(item.HitBox))
                {
                    item.Die();
                }
            }

        }
    }
}
