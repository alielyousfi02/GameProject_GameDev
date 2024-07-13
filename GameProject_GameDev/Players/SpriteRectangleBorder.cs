using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.Players
{
    public static class SpriteRectangleBorder
    {
        public static Rectangle GetNonTransparentBoundingBox(Texture2D texture)
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
    }

}
