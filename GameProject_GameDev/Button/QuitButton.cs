using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Button
{
    internal class QuitButton : Button
    {
        
        public QuitButton(Vector2 position, Texture2D texture, Color color, SpriteFont font, string text) : base(position, texture, color, font, text)
        {
        }

        public void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            MouseState currentMouseState = Mouse.GetState();
            Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);

            if (button.Contains(mousePosition) && currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
            {
                System.Environment.Exit(0);
            }

            previousMouseState = currentMouseState;  

        }
    }
}
