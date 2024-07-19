using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Players.AntiHero
{
    internal class Enemy1 : WalkingEnemy
    {
        public Enemy1(Texture2D texture, Vector2 position, float distancetotravel) : base(texture, position ,distancetotravel)
        {
            base.frameWidth = texture.Width / 6;
            base.frameHeigth = texture.Height;
            
        }

        public void Update(GameTime time)
        {

            base.Update(time);
        }

        public void Draw(SpriteBatch spriteBatch)
        {

            base.Draw(spriteBatch);

        }
    }
}