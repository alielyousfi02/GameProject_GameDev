using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Players.AntiHero
{
    internal class Enemy1 : WalkingEnemy
    {
        public Enemy1(Texture2D texture, int row, int col, int width, int height, float distancetotravel)
            : base(texture, row,  col , width, height, distancetotravel)
        {
            base.frameWidth = texture.Width / 6;
            base.frameHeight = texture.Height;
            Load();
        }


        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}