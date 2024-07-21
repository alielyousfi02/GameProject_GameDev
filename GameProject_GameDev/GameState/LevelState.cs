using GameProject_GameDev.Levels;
using GameProject_GameDev.Levels.LevelBuilder;
using GameProject_GameDev.Players;
using GameProject_GameDev.Players.AntiHero;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;


namespace GameProject_GameDev.GameState
{
    internal class LevelState : State
    {
        private int starCount = 0;
        private int LevelWon = 0;
        private int Score = 0;

        private Level1 level1;
        private Level curLevel;
        private Level2 level2;
        Hero hero;


        public LevelState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
            hero = new Hero(new Vector2(500, 600));
            level1 = new Level1(content, hero);
            level2 = new Level2(content, hero);
            curLevel = level1;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            curLevel.Draw(spriteBatch);
            hero.Draw(spriteBatch);

        }

        public override void LoadContent()
        {
            curLevel.Load();
            hero.Load(content);
        }

        public override void PostUpdate(GameTime gameTime)
        {

        }

        public override void Update(GameTime gameTime)
        {

            //game.ChangeState(new GameWonState(game, graphicsDevice, content));
            //Debug.WriteLine("Score: "+  Score);
            curLevel.Update(gameTime);
            hero.Update(gameTime);
            foreach (CollisionTiles item in curLevel.map.CollisionTiles)
            {
                hero.ResolveCollisions(item.Rectangle, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight);
            }
            //Collect Star
            foreach (var item in curLevel.stars)
            {
                if (hero.HitBox.Intersects(item.HitBox) && !item.IsCollected)
                {
                    item.Collect();
                    starCount+=1;
                }
            }
            //Attack Hero Enemy
            foreach (Enemy item in curLevel.enemies)
            {
                if (item.IsAlive && hero.HitBox.Intersects(item.HitBox))
                {
                    if (hero.HitBox.TouchTopOf(item.HitBox))
                    {
                        Score += item.Score;
                        item.Die();
                    }
                    else if (hero.IsAttacking)
                    {
                        Score += item.Score;
                        item.Die();
                    }
                    else
                    {
                        hero.Die();
                    }
                }
            }
            if (starCount == curLevel.stars.Count)
            {
                Debug.WriteLine(starCount);
                if(curLevel == level1)
                {
                    curLevel = level2;
                    starCount = 0;
                    curLevel.Load();
                }
                starCount = 0;
                LevelWon++;
            }
            if (!hero.IsAlive)
                game.ChangeState(new GameOverState(game, graphicsDevice, content));
            if(LevelWon == 2)
            {
                game.ChangeState(new GameWonState(game, graphicsDevice, content, Score));
            }

        }
    }
}
