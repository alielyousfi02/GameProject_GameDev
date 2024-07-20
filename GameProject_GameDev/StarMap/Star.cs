using GameProject_GameDev.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.StarMap
{
    internal class Star
    {
        private Texture2D texture;
        private Vector2 position;
        private bool IsCollected;
        private Rectangle rectangle;
        private Rectangle srcRec;
        public Rectangle HitBox
        {
            get { return rectangle; }
        }
        public Star(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            IsCollected = false;
            srcRec = new Rectangle(0, 0, texture.Width, texture.Height);
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public void Collect()
        {
            IsCollected = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            if (!IsCollected)
            {
                spriteBatch.Draw(texture, rectangle, SpriteRectangleBorder.GetNonTransparentBoundingBox(texture, srcRec), Color.White);
            };
        }

        public void Update(GameTime time)
        {
            if (!IsCollected)
            {

            }
        }
    }
}
