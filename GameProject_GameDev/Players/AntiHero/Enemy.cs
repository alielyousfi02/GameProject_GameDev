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
    internal abstract class Enemy : IGameObject
    {
        protected Texture2D texture;
        protected Rectangle rectangle;
        protected Vector2 position;
        protected int Width
        {
            get;set;
        }
        protected int Height
        {
            get;  set;
        }
        public bool IsAlive { get; protected set; }

        public virtual Rectangle HitBox
        {
            get
            {
                return rectangle;
            }
        }

        protected Enemy(Texture2D texture,int row, int col, int width, int height)
        {
            IsAlive = true;
            this.texture = texture;
            this.position = CalculatePositionInMap.CalculatePosition(row, col, width, height);
            
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public abstract void Update(GameTime gameTime);

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (IsAlive)
                spriteBatch.Draw(texture, rectangle, Color.White);
        }

        public void Die()
        {
            IsAlive = false;
        }
    }
}
