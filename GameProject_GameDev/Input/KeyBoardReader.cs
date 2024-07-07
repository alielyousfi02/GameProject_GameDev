using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GameProject_GameDev.Input
{
    internal class KeyBoardReader : IInputreader
    {
        public Vector2 ReadInput(GameTime gameTime)
        {
            var velocity = Vector2.Zero;
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.D))
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else if (keyboardState.IsKeyDown(Keys.A))
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;

            if (keyboardState.IsKeyDown(Keys.Space))
                velocity.Y = -9f;

            return velocity;

        }
    }
}
