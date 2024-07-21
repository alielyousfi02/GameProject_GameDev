using GameProject_GameDev.Levels.LevelBuilder;
using GameProject_GameDev.Players.AntiHero;
using GameProject_GameDev.Players;
using GameProject_GameDev.StarMap;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject_GameDev.Levels
{
    internal class Level2 : Level
    {

        private Hero hero;
        private Enemy1 enemy1;
        private Enemy2 enemy2;
        public StandingEnemy standingEnemy;
        public Level2(ContentManager content) : base(content)
        {
            //enemies.Clear();  
            Texture2D enemy1, enemy2, enemy3, startexture;
            enemy1 = content.Load<Texture2D>("enemy_run");
            enemy2 = content.Load<Texture2D>("enemy_attack");
            enemy3 = content.Load<Texture2D>("standing");
            startexture = content.Load<Texture2D>("star");


            enemies.Add(new WalkingEnemy(enemy1, 8, 15, 48, 48, 160));

            enemies.Add(new WalkingEnemy(enemy2, 5, 15, 96, 96, 160));
            
            
            enemies.Add(new StandingEnemy(enemy3, 12, 23, 70, 70));


            stars.Add(new Star(startexture, new Vector2(220, 30)));
            stars.Add(new Star(startexture, new Vector2(1300, 457)));

            //stars.Add(new Star(startexture, new Vector2(220, 30)));
            //stars.Add(new Star(startexture, new Vector2(1300, 601)));
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
            int[,] mapArray = new int[,]
                {
{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
{ 2,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
{ 2,0,0,1,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
{ 2,2,0,0,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,0,2 },
{ 2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
{ 2,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
{ 2,2,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,2 },
{ 2,0,0,0,0,0,0,0,0,0,0,0,0,2,2,2,2,2,2,2,2,2,2,0,0,0,0,0,0,2 },
{ 2,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2 },
{ 2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,2 },
{ 2,2,0,0,0,0,0,0,0,0,2,0,0,0,2,2,2,2,2,2,2,2,0,0,0,2,0,0,0,2 },
{ 2,0,0,0,0,2,2,2,2,2,0,0,0,2,0,0,0,0,0,0,0,0,2,0,0,0,2,2,2,2 },
{ 2,0,2,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,2 },
{ 2,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,0,0,0,0,0,0,0,0,2,0,0,0,0,2 },
{ 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2 }
                       };

            map.Generate(mapArray, 48);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            map.Draw(spriteBatch);
        }
    }
}
