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
using System.Diagnostics;

namespace GameProject_GameDev.Players
{
    internal class Hero
    {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private Rectangle rectangle;
        private Rectangle nonTransparentBoundingBox;
        private bool hasJumped;

        private float jumpVelocity = -9f;
        private float gravity = 0.4f;

        private readonly IInputreader inputReader;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Velocity 
        {
            get { return velocity; } 
            set { velocity = value; } 
        }
        public bool HasJumped
        {
            get { return hasJumped; }
            set { hasJumped = value; }
        }

        public Hero(Texture2D texture, Vector2 startPosition)
        {
            this.texture = texture;
            this.position = startPosition;
            this.velocity = Vector2.Zero;
            this.hasJumped = false;
            this.inputReader = new KeyBoardReader(); 
        }

        public void Load(ContentManager content)
        {
            nonTransparentBoundingBox = GetNonTransparentBoundingBox(texture);
            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        private Rectangle GetNonTransparentBoundingBox(Texture2D texture)
        {
            Color[] textureData = new Color[texture.Width * texture.Height];
            texture.GetData(textureData);

            int left = texture.Width;
            int right = 0;
            int top = texture.Height;
            int bottom = 0;

            for (int y = 0; y < texture.Height; y++)
            {
                for (int x = 0; x < texture.Width; x++)
                {
                    Color pixel = textureData[y * texture.Width + x];
                    if (pixel.A != 0)
                    {
                        left = Math.Min(left, x);
                        right = Math.Max(right, x);
                        top = Math.Min(top, y);
                        bottom = Math.Max(bottom, y);
                    }
                }
            }

            if (left > right || top > bottom)
            {
                return new Rectangle(0, 0, 0, 0);
            }

            return new Rectangle(left, top, right - left + 1, bottom - top + 1);
        }

       
        private void HandleInput(GameTime gameTime)
        {
            Vector2 input = inputReader.ReadInput(gameTime);
            velocity.X = input.X;

            if (input.Y < 0 && !hasJumped)
            {
                Jump();
            }
        }

        private void Jump()
        {
            velocity.Y = jumpVelocity;
            hasJumped = true;
        }

        private void ApplyGravity()
        {
            if (hasJumped || position.Y < ScreenSettings.ScreenHeight - rectangle.Height)
            {
                velocity.Y += gravity;
                if (velocity.Y > 10)
                {
                    velocity.Y = 10;
                }
            }
        }

        public void ResolveCollisions(Rectangle newRectangle, int xOffset, int yOffset)
        {
            Rectangle adjustedRectangle = GetAdjustedRectangle();

            if (adjustedRectangle.Intersects(newRectangle))
            {
                Rectangle intersection = Rectangle.Intersect(adjustedRectangle, newRectangle);

                if (intersection.Width < intersection.Height)
                {
                    if (adjustedRectangle.Center.X < newRectangle.Center.X)
                    {
                        position.X = newRectangle.Left - nonTransparentBoundingBox.Width - nonTransparentBoundingBox.X;
                        Debug.WriteLine("left");
                    }
                    else
                    {
                        position.X = newRectangle.Right - nonTransparentBoundingBox.X;
                        Debug.WriteLine("right");
                    }
                    velocity.X = 0f;
                }
                else
                {
                    if (adjustedRectangle.Center.Y < newRectangle.Center.Y && velocity.Y > 0)
                    {
                        position.Y = newRectangle.Top - nonTransparentBoundingBox.Height - nonTransparentBoundingBox.Y;
                        velocity.Y = 0f;
                        hasJumped = false;
                        Debug.WriteLine("top");
                    }
                    else if (adjustedRectangle.Center.Y > newRectangle.Center.Y && velocity.Y < 0)
                    {
                        position.Y = newRectangle.Bottom - nonTransparentBoundingBox.Y;
                        velocity.Y = 0f;
                        Debug.WriteLine("bottom");
                    }
                }
            }

            EnsureWithInterval(xOffset, yOffset);
        }

        private Rectangle GetAdjustedRectangle()
        {
            return new Rectangle(
                (int)position.X + nonTransparentBoundingBox.X,
                (int)position.Y + nonTransparentBoundingBox.Y,
                nonTransparentBoundingBox.Width,
                nonTransparentBoundingBox.Height
            );
        }

        private void EnsureWithInterval(int xOffset, int yOffset)
        {
            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - nonTransparentBoundingBox.Width) position.X = xOffset - nonTransparentBoundingBox.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - nonTransparentBoundingBox.Height) position.Y = yOffset - nonTransparentBoundingBox.Height;
        }




        public void Update(GameTime gameTime)
        {
            HandleInput(gameTime);

            ApplyGravity();

            position += velocity;

            //if (Math.Abs(velocity.X) < 0.01f) velocity.X = 0f;
            //if (Math.Abs(velocity.Y) < 0.01f) velocity.Y = 0f;

            rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Texture2D redTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            redTexture.SetData(new[] { Color.Red });

            Rectangle adjustedRectangle = GetAdjustedRectangle();

            // Uncomment the following line for debugging purposes
            // spriteBatch.Draw(redTexture, adjustedRectangle, Color.White);

            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
