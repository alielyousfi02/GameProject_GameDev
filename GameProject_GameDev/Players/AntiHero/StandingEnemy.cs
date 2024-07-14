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

        public Rectangle HitBox
        {
            get { return nonTransparentRectangle; }
        }
        public bool Alive
        {
            get; private set;
        }
        public StandingEnemy(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.rectangle = new Rectangle((int)position.X,(int) position.Y, texture.Width, texture.Height);
            this.nonTransparentRectangle = SpriteRectangleBorder.GetNonTransparentBoundingBox(texture, rectangle);
            this.position = position;
            Alive = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);
            
        }
        public void Die()
        {
            Alive = false;
        }
        public void Update(GameTime time)
        {

        }
    }
}
