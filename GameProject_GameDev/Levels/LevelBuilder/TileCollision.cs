using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;

namespace GameProject_GameDev.Levels.LevelBuilder
{
    internal class TileCollision : ICollisionHandler
    {
        public void HandleCollision(ICollisionEntity entity, Rectangle newRectangle, int xOffset, int yOffset)
        {
            var rectangle = entity.Rectangle;
            var position = entity.Position;
            var velocity = entity.Velocity;

            if (rectangle.TouchTopOf(newRectangle))
            {
                position.Y = newRectangle.Y - rectangle.Height - 2;
                velocity.Y = 0f;
                entity.HasJumped = false;
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

            entity.Position = position;
            entity.Velocity = velocity;
        }
    }
}