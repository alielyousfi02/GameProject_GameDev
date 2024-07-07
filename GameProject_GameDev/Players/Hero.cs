using GameProject_GameDev.Animations;
using GameProject_GameDev.Input;
using GameProject_GameDev.Interfaces;
using GameProject_GameDev.Levels.LevelBuilder;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameProject_GameDev.Players
{
    internal class Hero : ICollisionEntity
    {
        private readonly IInputreader inputHandler;
        private readonly ICollisionHandler collisionHandler;
        private readonly Interfaces.IDrawable drawable;

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get { return velocity; } set { velocity = value; } }
        public Rectangle Rectangle { get; private set; }
        public bool HasJumped { get; set; }

        private Vector2 velocity;
        private KeyboardState previousKeyboardState;

        private const float gravity = 0.8f; 
        private const float jumpVelocity = -15f; 

        public Hero(Texture2D texture)
        {
            inputHandler = new KeyBoardReader();
            collisionHandler = new TileCollision();
            drawable = new HeroDrawer(texture, this);

            Position = new Vector2(64, 384);
            Velocity = Vector2.Zero;
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            HasJumped = false;
            previousKeyboardState = Keyboard.GetState();
        }

        public void Update(GameTime gameTime)
        {
            velocity = Velocity;

            var inputVelocity = inputHandler.ReadInput(gameTime);
            Position += new Vector2(inputVelocity.X, 0);
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Rectangle.Width, Rectangle.Height);

            Jump();


            Position += new Vector2(0, Velocity.Y);
            Rectangle = new Rectangle((int)Position.X, (int)Position.Y, Rectangle.Width, Rectangle.Height);
        }

        private void Jump()
        {
            var currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.Up) && previousKeyboardState.IsKeyUp(Keys.Up) && !HasJumped)
            {
                Velocity = new Vector2(Velocity.X, jumpVelocity);
                HasJumped = true;
            }
            previousKeyboardState = currentKeyboardState;

            // Apply gravity
            if (Velocity.Y < 10)
            {
                velocity.Y += gravity;
                Velocity = velocity;
            }
        }

        public void HandleCollision(Rectangle newRectangle, int xOffset, int yOffset)
        {
            collisionHandler.HandleCollision(this, newRectangle, xOffset, yOffset);
            if (Rectangle.TouchTopOf(newRectangle))
            {
                HasJumped = false; 
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            drawable.Draw(spriteBatch);
        }
    }
}
