using GameProject_GameDev.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject_GameDev.Button
{
    internal class StartButton : Button
    {
        public StartButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, Vector2 position, string text) : base(game, graphicsDevice, content, position, text)
        {
        }
        public override void Update(GameTime gameTime)
        {



            MouseState currentMouseState = Mouse.GetState();
            Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);
            //System.Diagnostics.Debug.WriteLine(mousePosition.X + " " + mousePosition.Y + " " + base.button.X + " " + (base.button.X + base.button.Width) + ":" + base.button.Y + " " + (base.button.Y + base.button.Height));
            if (button.Contains(mousePosition) && currentMouseState.LeftButton == ButtonState.Released && previousMouseState.LeftButton == ButtonState.Pressed)
            {
                game.ChangeState(new LevelState(game, graphicsDevice, content));
            }


            previousMouseState = currentMouseState;
            base.Update(gameTime);

            
        }
    }
}
