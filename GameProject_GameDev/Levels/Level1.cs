using GameProject_GameDev.LevelBuilder;
using GameProject_GameDev.Players;
using GameProject_GameDev.Players.AntiHero;
using GameProject_GameDev.StarMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Diagnostics;

namespace GameProject_GameDev.Levels
{
    internal class Level1 : Level
    {

        private Hero hero;
        public Level1(ContentManager content, Hero hero) : base(content, hero)
        {
            //Texture2D enemy1, enemy2, enemy3, startexture, ghost;

            /*
             
              axe = content.Load<Texture2D>("enemy_run");
            goblin = content.Load<Texture2D>("enemy_attack");
            ghost = content.Load<Texture2D>("ghost");
            trap = content.Load<Texture2D>("standing");
            star = content.Load<Texture2D>("star");

             */
           

            this.hero = hero;
            enemies.Add(new GhostEnemy(ghost, 1, 1, 96, 96, 100, hero));
            enemies.Add(new WalkingEnemy(goblin, 8, 3, 96, 96, 60));
            enemies.Add(new WalkingEnemy(axe, 12, 7, 48, 48, 150));
            enemies.Add(new WalkingEnemy(goblin, 4, 24, 96, 96, 120));
            enemies.Add(new WalkingEnemy(axe, 1, 23, 48, 48, 100));
            enemies.Add(new StandingEnemy(trap, 4, 5, 70, 70));

            stars.Add(new Star(star, new Vector2(220, 30)));
            stars.Add(new Star(star, new Vector2(1300, 601)));
            foreach (var item in enemies)
            {
                if (item is WalkingEnemy)
                    item.Load();
            }
        }

        public override void Load()
        {
            base.Load();
            CollisionTiles.Content = content;
            //hero.Load(content);

            int[,] mapArray = new int[,]
               {
                { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
                { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
                { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,1,2 },
                { 2,0,0,0,0,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,2 },
                { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,1,0,2 },
                { 2,0,0,0,0,0,0,1,1,1,0,0,0,1,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,2 },
                { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,1,2 },
                { 2,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,0,2 },
                { 2,1,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,1,0,1,0,0,0,1,0,2 },
                { 2,0,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,1,0,1,0,0,0,0,0,2 },
                { 2,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,0,0,0,0,1,2 },
                { 2,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,1,1,1,1,1,1,2 },
                { 2,0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,2 },
                { 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,2 },
                { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2 }
                      };

            map.Generate(mapArray, 48);
        }

        public override void Update(GameTime gameTime)
        {
            //hero.Update(gameTime);
            //enemy1.Update(gameTime);
            /*foreach (CollisionTiles item in map.CollisionTiles)
            {
                hero.ResolveCollisions(item.Rectangle, map.Width, map.Height);
            }*/
            //enemy2.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            map.Draw(spriteBatch);
            //standingEnemy.Draw(spriteBatch);
            //if(enemy1.IsAlive)
            //enemy1.Draw(spriteBatch);
            //enemy2.Draw(spriteBatch);
           // hero.Draw(spriteBatch);
        }
    }
}
