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
    internal class Hero
    {
        private Vector2 position;
        private Vector2 velocity;
        private Rectangle rectangle;
        private Animation currentAnimation;
        private bool isAttacking;
        private bool hasLanded;
        private Dictionary<string, Animation> animations;
        private bool facingRight = true;

        private readonly IInputreader inputReader;
        public Rectangle HitBox
        {
            get { return GetAdjustedRectangle(); }
        }
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
      
        public bool IsAttacking
        {
            get
            {
                if (currentAnimation == animations["Attack"])
                    return true;
                else 
                    return false;
            }
        }
        public bool IsAlive
        {
            get;private set;
        }
        public Hero(Vector2 startPosition)
        {
            this.position = startPosition;
            this.velocity = Vector2.Zero;
            this.isAttacking = false;
            this.hasLanded = true;
            this.inputReader = new KeyBoardReader();
            animations = new Dictionary<string, Animation>();
            IsAlive = true;
        }

        public void Load(ContentManager content)
        {
            animations.Add("Idle", new Animation(content.Load<Texture2D>("Hero/Idle"), 96, 96));
            animations.Add("Attack", new Animation(content.Load<Texture2D>("Hero/Attack_3"), 96, 96));
            animations.Add("Run", new Animation(content.Load<Texture2D>("Hero/Run"), 96, 96));

            currentAnimation = animations["Idle"];
            Texture2D idleTexture = content.Load<Texture2D>("Hero/Idle");
            rectangle = new Rectangle((int)position.X, (int)position.Y, 96, 96);
        }

        private void HandleInput(GameTime gameTime)
        {
            Vector2 input = inputReader.ReadInput(gameTime);
            velocity.X = input.X;

            if (input.X > 0)
            {
                facingRight = true;
            }
            else if (input.X < 0)
            {
                facingRight = false;
            }

            if (input.Y < 0)
            {
                if (hasLanded)
                {
                    Jump();
                    hasLanded = false; 
                }
            }

          
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Attack();
            }
        }

        private void Jump()
        {
            velocity.Y = -9f;
            

        }

        private void Attack()
        {
            if (!isAttacking)
            {
                isAttacking = true;
                currentAnimation = animations["Attack"];
            }
        }
        public void Die()
        {
            IsAlive = false;
        }

        public void ResolveCollisions(Rectangle newRectangle, int xOffset, int yOffset)
        {
            Rectangle adjustedRectangle = GetAdjustedRectangle();

            if (adjustedRectangle.Intersects(newRectangle))
            {
                Rectangle intersection = Rectangle.Intersect(adjustedRectangle, newRectangle);

                if (intersection.Width < intersection.Height)
                {
                    // Horizontale collisie checkere
                    if (adjustedRectangle.Center.X < newRectangle.Center.X)
                    {
                        position.X = newRectangle.Left - currentAnimation.CurrentFrame.NonTransparentBoundingBox.Width - currentAnimation.CurrentFrame.NonTransparentBoundingBox.X;
                    }
                    else
                    {
                        position.X = newRectangle.Right - currentAnimation.CurrentFrame.NonTransparentBoundingBox.X;
                    }
                    velocity.X = 0f;
                }
                else
                {
                    if (adjustedRectangle.Center.Y < newRectangle.Center.Y && velocity.Y > 0)
                    {
                        position.Y = newRectangle.Top - currentAnimation.CurrentFrame.NonTransparentBoundingBox.Height - currentAnimation.CurrentFrame.NonTransparentBoundingBox.Y;

                        velocity.Y = 0f;
                        hasLanded = true; 
                        if (!isAttacking && velocity.X == 0)
                        {
                            currentAnimation = animations["Idle"];
                        }
                    }
                    else if (adjustedRectangle.Center.Y > newRectangle.Center.Y && velocity.Y < 0)
                    {
                        position.Y = newRectangle.Bottom - currentAnimation.CurrentFrame.NonTransparentBoundingBox.Y;
                        velocity.Y = 0f;
                    }
                }
            }

            //EnsureWithinBounds(xOffset, yOffset);
        }

        private Rectangle GetAdjustedRectangle()
        {
            return new Rectangle(
                (int)position.X + currentAnimation.CurrentFrame.NonTransparentBoundingBox.X + 1,
                (int)position.Y + currentAnimation.CurrentFrame.NonTransparentBoundingBox.Y + 1,
                currentAnimation.CurrentFrame.NonTransparentBoundingBox.Width,
                currentAnimation.CurrentFrame.NonTransparentBoundingBox.Height
            );
        }

        private void EnsureWithinBounds(int xOffset, int yOffset)
        {
            if (position.X < 0) position.X = 0;
            if (position.X > xOffset - currentAnimation.CurrentFrame.NonTransparentBoundingBox.Width) position.X = xOffset - currentAnimation.CurrentFrame.NonTransparentBoundingBox.Width;
            if (position.Y < 0) velocity.Y = 1f;
            if (position.Y > yOffset - currentAnimation.CurrentFrame.NonTransparentBoundingBox.Height) position.Y = yOffset - currentAnimation.CurrentFrame.NonTransparentBoundingBox.Height;
        }

        public void Update(GameTime gameTime)
        {
            HandleInput(gameTime);

    
            if (velocity.Y < 10)
            {
                velocity.Y += 0.4f;
            }
            position += velocity;

            if (!isAttacking)
            {
                if (velocity.X != 0)
                {
                    currentAnimation = animations["Run"];
                }
                else
                {
                    currentAnimation = animations["Idle"];
                }
            }

            currentAnimation.Update(gameTime);

            rectangle = new Rectangle((int)position.X, (int)position.Y, currentAnimation.CurrentFrame.SourceRectangle.Width, currentAnimation.CurrentFrame.SourceRectangle.Height);

            if (isAttacking && currentAnimation == animations["Attack"])
            {
                if (currentAnimation.CurrentFrame == animations["Attack"].frames[animations["Attack"].frames.Count - 1])
                {
                    isAttacking = false;
                    if (velocity.X != 0)
                    {
                        currentAnimation = animations["Run"];
                    }
                    else
                    {
                        currentAnimation = animations["Idle"];
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = facingRight ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if(IsAlive)
            spriteBatch.Draw(currentAnimation.CurrentFrame.Texture, position, currentAnimation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, spriteEffects, 0f);
            
            //DEBUG
            /*
            Texture2D rectTexture = new Texture2D(spriteBatch.GraphicsDevice, rectangle.Width, rectangle.Height);
            Color[] data = new Color[rectangle.Width * rectangle.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Red;
            rectTexture.SetData(data);
            spriteBatch.Draw(rectTexture, HitBox, Color.White * 0.5f);
            */
        }
    }
}
