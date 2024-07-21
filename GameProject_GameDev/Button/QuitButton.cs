using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameProject_GameDev.Button    
{
    internal class QuitButton : Button
    {
        
        public QuitButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, Vector2 position, string text) : base(game,graphicsDevice,content, position, text)
        {
        }

        public override void Update(GameTime gameTime)
        {
            
            MouseState currentMouseState = Mouse.GetState();
            Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);
            
            if (button.Contains(mousePosition) && currentMouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
            {

                game.Exit();
                Environment.Exit(0);
            }              
            

            previousMouseState = currentMouseState;
            base.Update(gameTime);

        }
    }
}
