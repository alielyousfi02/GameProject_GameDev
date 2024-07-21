using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace GameProject_GameDev.Input
{
    internal class KeyBoardReader : IInputreader
    {
        public Vector2 ReadInput(GameTime gameTime)
        {
            var velocity = Vector2.Zero ;
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.Right))
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else if (keyboardState.IsKeyDown(Keys.Left))
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

            if (keyboardState.IsKeyDown(Keys.Up))
                velocity.Y = -9f;

            return velocity;

        }
    }
}
