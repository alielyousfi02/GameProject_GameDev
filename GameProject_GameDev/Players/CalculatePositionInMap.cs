using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using GameProject_GameDev.UI;

namespace GameProject_GameDev.Players
{
    public static class CalculatePositionInMap
    {
        public static Vector2 CalculatePosition(int row, int col,int width, int height)
        {
            Vector2 pos = new Vector2(0, 0);
            

            int x = (col) * 48;
            int y = ScreenSettings.ScreenHeight - ((row) * 48) - height;

            return new Vector2(x, y);
            

        }
    }
}
