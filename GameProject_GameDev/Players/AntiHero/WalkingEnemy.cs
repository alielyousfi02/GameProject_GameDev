using GameProject_GameDev.Animations;
using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace GameProject_GameDev.Players.AntiHero
{
    internal class WalkingEnemy : IGameObject
    {
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 startPosition;
        private float distanceToTravel;
        private float speed;
        private int direction;
        Animation animation;
        internal int frameWidth;
        internal int frameHeigth;
        public bool IsAlive
        {
            get; private set;
        }
        public void Die()
        {
            IsAlive = false;
        }
        public Rectangle HitBox
        {
            get
            {
                return GetAdjustedRectangle();
            }
        }
        public WalkingEnemy(Texture2D texture, Vector2 position, float distanceToTravel, float speed = 2.0f)
        {
            IsAlive = true;
            this.texture = texture;
            this.rectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width / 6, texture.Height);
            this.startPosition = position;
            this.distanceToTravel = distanceToTravel;
            this.speed = speed;
            this.direction = 1;
        }
        public void Load()
        {
            animation = new Animation(texture, frameWidth, frameHeigth);
        }
        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
            rectangle.X += (int)(direction * speed);
            if (rectangle.X > startPosition.X + distanceToTravel || rectangle.X < startPosition.X)
            {
                direction *= -1;
                rectangle.X = MathHelper.Clamp(rectangle.X, (int)startPosition.X, (int)(startPosition.X + distanceToTravel));
            }
        }
        private Rectangle GetAdjustedRectangle()
        {
            return new Rectangle(
                (int)rectangle.X + animation.CurrentFrame.NonTransparentBoundingBox.X + 1,
                (int)rectangle.Y + animation.CurrentFrame.NonTransparentBoundingBox.Y + 1,
                animation.CurrentFrame.NonTransparentBoundingBox.Width,
                animation.CurrentFrame.NonTransparentBoundingBox.Height
            );
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SpriteEffects spriteEffects = direction >= 0 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            spriteBatch.Draw(animation.CurrentFrame.Texture, new Vector2(rectangle.X, rectangle.Y), animation.CurrentFrame.SourceRectangle, Color.White, 0f, Vector2.Zero, 1f, spriteEffects, 0f);

            var test = GetAdjustedRectangle();
            Debug.WriteLine(animation.CurrentFrame.SourceRectangle.X + " " + animation.CurrentFrame.SourceRectangle.Y + " " + animation.frames.Count);

            Texture2D rectTexture = new Texture2D(spriteBatch.GraphicsDevice, test.Width, test.Height);

            Color[] data = new Color[test.Width * test.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Red;
            rectTexture.SetData(data);










            //spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
