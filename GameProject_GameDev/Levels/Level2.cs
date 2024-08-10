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
using GameProject_GameDev.LevelBuilder;

namespace GameProject_GameDev.Levels
{
    internal class Level2 : Level
    {

        private Hero hero;
        public StandingEnemy standingEnemy;
        public Level2(ContentManager content, Hero hero) : base(content, hero)
        {

           
            this.hero = hero;
            enemies.Add(new WalkingEnemy(axe, 8, 15, 48, 48, 160));
            enemies.Add(new WalkingEnemy(goblin, 5, 15, 96, 96, 160));
            enemies.Add(new StandingEnemy(trap, 12, 23, 70, 70));
            stars.Add(new Star(star, new Vector2(1200, 90)));
            stars.Add(new Star(star, new Vector2(1300, 457)));

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
