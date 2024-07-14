using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Players.AntiHero
{
    internal class StandingEnemy : IGameObject
    {
        //Staat 
        //Doet niets
        //Bij collisie links recht Hero dood
        //Collisie van boven object weg + score

        private Texture2D texture;
        private Rectangle rectangle;
        private Rectangle nonTransparentRectangle;
        private Vector2 position;
        public StandingEnemy(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.rectangle = new Rectangle(0, 0, texture.Width, texture.Height);
            this.nonTransparentRectangle = SpriteRectangleBorder.GetNonTransparentBoundingBox(texture, rectangle);
            this.position = position;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
          
        }

        public void Update(GameTime time)
        {
            throw new NotImplementedException();
        }
    }
}
