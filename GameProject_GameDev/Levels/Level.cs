using GameProject_GameDev.Levels.LevelBuilder;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject_GameDev.Levels
{
    internal abstract class Level
    {
        protected Map map;
        protected ContentManager content;

        public Level(ContentManager content)
        {
            this.content = content;
            map = new Map();
        }

        public virtual void LoadContent()
        {
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(content.Load<Texture2D>("beachbackground"), new Rectangle(0, 0, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight), Color.White);
        }
    }
}
