using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Players.AntiHero
{
    internal class WalkingEnemy : IGameObject
    {


        private Texture2D texture;
        Animations.Animation animation;
        private int width;
        private int height;
        private Rectangle rectangle;


        public WalkingEnemy(Texture2D texture, Rectangle rectangle)
        {
            this.texture = texture;
            animation = new Animations.Animation();
            this.rectangle = rectangle;
        }
        public void Update(GameTime time)
        {
            rectangle = new Rectangle(rectangle.X, rectangle.Y, texture.Width, texture.Height); 
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

        }

        
    }
}
