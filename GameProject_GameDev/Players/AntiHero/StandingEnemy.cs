using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace GameProject_GameDev.Players.AntiHero
{
    internal class StandingEnemy : Enemy
    {
       

        public StandingEnemy(Texture2D texture, int row, int col, int width, int height)
            : base(texture, row, col, width, height)
        {
            base.Score = 250;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
          

        }

        public override void Load()
        {
        }
    }
}
