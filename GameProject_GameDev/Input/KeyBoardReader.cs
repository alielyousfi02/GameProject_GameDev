using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GameProject_GameDev.Input
{
    internal class KeyBoardReader : IInputreader
    {
        public Vector2 ReadInput()
        {
            var direction = Vector2.Zero;
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Left))
            {
                direction.X -= 1;
                Debug.WriteLine("Left key pressed");
            }
            if (state.IsKeyDown(Keys.Right))
            {
                direction.X += 1;
                Debug.WriteLine("Right key pressed");
            }
            if (state.IsKeyDown(Keys.Up))
            {
                direction.Y -= 1;
                Debug.WriteLine("Up key pressed");
            }
            if (state.IsKeyDown(Keys.Down))
            {
                direction.Y += 1;
                Debug.WriteLine("Down key pressed");
            }

            return direction;
        }
    }
}
