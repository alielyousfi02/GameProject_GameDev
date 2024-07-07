using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Interfaces
{
    internal interface ICollisionEntity
    {
        Vector2 Position { get; set; }
        Vector2 Velocity { get; set; }
        Rectangle Rectangle { get; }
        bool HasJumped { get; set; }
        void HandleCollision(Rectangle newRectangle, int xOffset, int yOffset);

    }
}
