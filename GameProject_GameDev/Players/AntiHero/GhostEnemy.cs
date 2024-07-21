using GameProject_GameDev.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Diagnostics;

namespace GameProject_GameDev.Players.AntiHero
{
    internal class GhostEnemy : Enemy
    {
        private Vector2 heroPosition;
        private float speed;
        private Hero hero;
        private Animation animatie;
        private Rectangle srcRec;

        public override Rectangle HitBox
        {
            get
            {
                return GetAdjustedRectangle();
            }
        }

        public GhostEnemy(Texture2D texture, int row, int col, int width, int height, float speed, Hero hero)
            : base(texture, row, col, width, height)
        {
            int dim = 96;
            this.speed = speed;
            this.hero = hero;
            animatie = new Animation(base.texture, dim, dim);
            srcRec = new Rectangle(0, 0, texture.Width, texture.Height);

            base.rectangle = new Rectangle((int)position.X, (int)position.Y, dim, dim);
        }

        public override void Update(GameTime gameTime)
        {
            heroPosition = new Vector2(hero.HitBox.Center.X-hero.HitBox.Width, hero.HitBox.Y - hero.HitBox.Height);

            if (IsAlive)
            {
                Vector2 direction = heroPosition - position;
                if (direction.Length() > 0)
                {
                    direction.Normalize();
                    position += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                    rectangle.Location = position.ToPoint();
                }
                animatie.Update(gameTime);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if(IsAlive)
            spriteBatch.Draw(animatie.CurrentFrame.Texture, new Vector2(rectangle.X, rectangle.Y), animatie.CurrentFrame.SourceRectangle, Color.White);

            Texture2D rectTexture = new Texture2D(spriteBatch.GraphicsDevice, HitBox.Width, HitBox.Height);
            Color[] data = new Color[HitBox.Width * HitBox.Height];
            for (int i = 0; i < data.Length; ++i) data[i] = Color.Red;
            rectTexture.SetData(data);

        }

        private Rectangle GetAdjustedRectangle()
        {
            var nonTransparentBoundingBox = SpriteRectangleBorder.GetNonTransparentBoundingBox(animatie.CurrentFrame.Texture, animatie.CurrentFrame.SourceRectangle);
            return new Rectangle(
                rectangle.X + nonTransparentBoundingBox.X,
                rectangle.Y + nonTransparentBoundingBox.Y,
                nonTransparentBoundingBox.Width,
                nonTransparentBoundingBox.Height
            );
        }

        public override void Load()
        {
        
        }
    }
}
