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
        private int width = 100;
        private int height = 30;
        private Color btncolor;
        private Vector2 position;
        protected Rectangle button;
        protected MouseState previousMouseState;

        private string text;
        protected Texture2D texture;
        SpriteFont font;


        public Button(Vector2 position, Texture2D texture, Color color, SpriteFont font, string text)
        {
            
            this.position = position;
            button = new Rectangle((int)position.X, (int)position.Y, width, height);
            this.texture = texture;
            this.font = font;
            this.text = text;
            btncolor = color;
        }
        public void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, button, btncolor);
            Vector2 textSize = font.MeasureString(text);
            Vector2 textPos = new Vector2(
                button.X + (button.Width - textSize.X) / 2,
                button.Y + (button.Height - textSize.Y) / 2);

            spritebatch.DrawString(font, text, textPos, Color.Black);
        }
        public void Update(GameTime gameTime)
        {
           


            MouseState currentMouseState = Mouse.GetState();


            Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);

            if (button.Contains(mousePosition))
            {
                texture.SetData(new[] { Color.Red });               
            }
            else
            {
                texture.SetData(new[] { Color.White });
            }
           // previousMouseState = currentMouseState; 


        }

    }
}
