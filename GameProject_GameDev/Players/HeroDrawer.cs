using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Players
{
    internal class HeroDrawer : Interfaces.IDrawable
    {
        private readonly Texture2D texture;
        private readonly ICollisionEntity hero;

        public HeroDrawer(Texture2D texture, ICollisionEntity hero)
        {
            this.texture = texture;
            this.hero = hero;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var rectangle = hero.Rectangle;
            spriteBatch.Draw(texture, rectangle, Color.White);

        }

    }

}
