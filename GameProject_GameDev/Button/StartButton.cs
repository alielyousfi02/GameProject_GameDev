using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Button
{
    internal class StartButton : Button
    {
        public StartButton(Vector2 position, Texture2D texture, Color color, SpriteFont font, string text) : base(position, texture, color, font, text)
        {
        }
    }
}
