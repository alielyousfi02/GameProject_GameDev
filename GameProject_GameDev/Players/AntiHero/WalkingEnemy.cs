using GameProject_GameDev.Animations;
using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Data;
using System.Diagnostics;

namespace GameProject_GameDev.Players.AntiHero
{
    internal class WalkingEnemy : Enemy
    {
        private float distanceToTravel;
        private float speed;
        private int direction;
        private Animation animation;
        internal int frameWidth;
        internal int frameHeight;
        private Vector2 startPosition;
        

        

        public WalkingEnemy(Texture2D texture,int row, int col ,int width, int height, float distanceToTravel,float speed = 2.0f)
            : base(texture, row, col, width, height)
        {
            //frameWidth = width;
            //frameHeight = height;
            this.distanceToTravel = distanceToTravel;
            this.speed = speed;
            this.direction = 1;
            this.startPosition = position;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Load()
        {
            animation = new Animation(texture, frameWidth, frameHeight);
        }
        public override Rectangle HitBox
        {
            get { return GetAdjustedRectangle(); }
        }
        public override void Update(GameTime gameTime)
        {
            //rectangle = GetAdjustedRectangle();
            if (IsAlive)
            {
                animation.Update(gameTime);
                rectangle.X += (int)(direction * speed);
                if (rectangle.X > startPosition.X + distanceToTravel || rectangle.X < startPosition.X)
                {
                    direction *= -1;
                    rectangle.X = MathHelper.Clamp(rectangle.X, (int)startPosition.X, (int)(startPosition.X + distanceToTravel));
                }
            }
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            Debug.WriteLine(animation.CurrentFrame.SourceRectangle.Width + " " + animation.CurrentFrame.SourceRectangle.Height + " -> " + animation.CurrentFrame.NonTransparentBoundingBox.Width + " " + animation.CurrentFrame.NonTransparentBoundingBox.Height);

            SpriteEffects spriteEffects = direction >= 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            if(IsAlive)
            spriteBatch.Draw(animation.CurrentFrame.Texture, new Vector2(rectangle.X, rectangle.Y), animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, spriteEffects, 0f);

           //debug
            var adjustedRectangle = GetAdjustedRectangle();
            Texture2D rectTexture = new Texture2D(spriteBatch.GraphicsDevice, animation.CurrentFrame.NonTransparentBoundingBox.Width, animation.CurrentFrame.NonTransparentBoundingBox.Height);
            Color[] data = new Color[animation.CurrentFrame.NonTransparentBoundingBox.Width * animation.CurrentFrame.NonTransparentBoundingBox.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Red;
            rectTexture.SetData(data);
            //base.Draw(spriteBatch);
            //spriteBatch.Draw(rectTexture, adjustedRectangle, Color.White*0.5f);
        }

        private Rectangle GetAdjustedRectangle()
        {
            //Debug.WriteLine(animation.CurrentFrame.NonTransparentBoundingBox.X + " " + animation.CurrentFrame.NonTransparentBoundingBox.Y);
            return new Rectangle(
                rectangle.X + animation.CurrentFrame.NonTransparentBoundingBox.X + 1,
                rectangle.Y + animation.CurrentFrame.NonTransparentBoundingBox.Y + 1,
                animation.CurrentFrame.NonTransparentBoundingBox.Width,
                animation.CurrentFrame.NonTransparentBoundingBox.Height
            );
        }
    }
}
