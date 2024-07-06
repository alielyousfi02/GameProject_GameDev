using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameProject_GameDev.Interfaces;

namespace GameProject_GameDev.Button
{
    internal class Button : IGameObject
    {
        private int width;
        private int height;
        public Color color;
        public Vector2 position;
        public Rectangle button;

        private string text;
        private Texture2D texture;
        SpriteFont font;
        private bool isClicked = false;
        private bool isHovered = false;

        public Button(int width, int height, Vector2 position, Texture2D texture, Color color, SpriteFont font, string text)
        {
            this.width = width;
            this.height = height;
            this.position = position;
            button = new Rectangle((int)position.X, (int)position.Y, width, height);
            this.texture = texture;
            this.font = font;
            this.text = text;

        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, button, Color.White);
            Vector2 textSize = font.MeasureString(text);
            Vector2 textPos = new Vector2(
                button.X + (button.Width - textSize.X) / 2,
                button.Y + (button.Height - textSize.Y) / 2);

            spritebatch.DrawString(font, text, textPos, Color.Black);
        }
        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();
            Point mousePosition = new Point(mouseState.X, mouseState.Y);
            if (button.Contains(mousePosition))
            {
                Debug.WriteLine("hover");
            }


        }

    }
}
