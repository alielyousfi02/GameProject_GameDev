using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Interfaces
{
    internal interface IGameObject
    {
        void Update(GameTime time);
        void Draw(SpriteBatch spriteBatch);

    }
}
