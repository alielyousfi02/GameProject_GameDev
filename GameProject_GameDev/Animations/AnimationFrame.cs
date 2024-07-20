using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameProject_GameDev.Players;

namespace GameProject_GameDev.Animations
{
    internal class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }
        public Rectangle NonTransparentBoundingBox { get; set; }
        public Texture2D Texture { get; set; }

        public AnimationFrame(Texture2D texture, Rectangle sourceRectangle)
        {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            NonTransparentBoundingBox = SpriteRectangleBorder.GetNonTransparentBoundingBox(texture, sourceRectangle);
        }
    }
}
