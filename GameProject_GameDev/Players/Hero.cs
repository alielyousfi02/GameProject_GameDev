using GameProject_GameDev.Animations;
using GameProject_GameDev.Input;
using GameProject_GameDev.Interfaces;
using GameProject_GameDev.Levels.LevelBuilder;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameProject_GameDev.Players
{
    //https://www.youtube.com/watch?v=l0WS5SvKdY4&t=1103s
    internal class Hero
    {
        private Texture2D texture;
        private Vector2 position = new Vector2(64, 384);
        private Vector2 velocity;
        private Rectangle rectangle;
        private bool hasJumped = false;

        public Vector2 Position
        {
            get { return position; }
        }

        public Hero(Texture2D texture) { this.texture = texture; }

       

        public void Update(GameTime gameTime)
        {
            position += velocity;
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            Input(gameTime);

            if (velocity.Y < 10)
                velocity.Y += 0.4f; 
        }

        private void Input(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();

            if (keyboardState.IsKeyDown(Keys.D))
                velocity.X = (float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else if (keyboardState.IsKeyDown(Keys.A))
                velocity.X = -(float)gameTime.ElapsedGameTime.TotalMilliseconds / 3;
            else
                velocity.X = 0f;

            if (keyboardState.IsKeyDown(Keys.Space) && !hasJumped)
            {
                velocity.Y = -9f; 
                hasJumped = true;
            }
        }

        public void Collision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            if (rectangle.TouchTopOf(newRectangle))
            {
                position.Y = newRectangle.Y - rectangle.Height - 2;
                velocity.Y = 0f;
                hasJumped = false; // Reset jump
            }

            if (rectangle.TouchLeftOf(newRectangle))
            {
                position.X = newRectangle.X - rectangle.Width - 2;
            }

            if (rectangle.TouchRightOf(newRectangle))
            {
                position.X = newRectangle.X + newRectangle.Width + 2;
            }

            if (rectangle.TouchBottomOf(newRectangle))
            {
                velocity.Y = 1f;
            }

            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - rectangle.Width) position.X = xOffset - rectangle.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - rectangle.Height) position.Y = yOffset - rectangle.Height;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, rectangle, Color.White);

            Texture2D rectTexture = new Texture2D(spriteBatch.GraphicsDevice, rectangle.Width, rectangle.Height);
            Color[] data = new Color[rectangle.Width * rectangle.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Red;
            rectTexture.SetData(data);
            spriteBatch.Draw(rectTexture, rectangle, Color.White * 0.5f);
        }

    }
}
