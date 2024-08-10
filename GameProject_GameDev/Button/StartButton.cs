using GameProject_GameDev.GameState;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace GameProject_GameDev.Button
{
    internal class StartButton : Button
    {
        public StartButton(Game1 game, GraphicsDevice graphicsDevice, ContentManager content, Vector2 position, string text) : base(game, graphicsDevice, content, position, text)
        {
        }
        protected override void OnClick()
        {
            game.ChangeState(new LevelState(game, graphicsDevice, content));
        }
        
    }
}
