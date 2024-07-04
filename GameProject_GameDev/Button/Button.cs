using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace GameProject_GameDev.Button
{
    internal class Button
    {
        private int width;
        private int height;
        public Color color;
        public Vector2 position;
        public Rectangle button;

        private Texture2D texture;
        SpriteFont font;

        public Button(int width, int height, Vector2 position, Texture2D texture)
        {
            this.width = width;
            this.height = height;
            this.position = position;
            button = new Rectangle(0, 0, width, height);
            this.texture = texture;

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, button, Color.White);
        }
        public void Update()
        {

        }

    }
}
