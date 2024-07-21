using GameProject_GameDev.Button;
using GameProject_GameDev.UI;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace GameProject_GameDev.GameState
{
    internal class MenuState : State
    {


        private StartButton startButton;
        private QuitButton quitButton;

        private Texture2D backgroundtexture;
        //List<Button.Button> buttons;
        public MenuState(Game1 game, GraphicsDevice graphicsDevice, ContentManager content) : base(game, graphicsDevice, content)
        {
             int Xpos = ScreenSettings.ScreenWidth / 2 - 50; // nog aanpassen
             int Ypos = ScreenSettings.ScreenHeight / 2 - 15; // nog aanpassen
            startButton = new StartButton(game, graphicsDevice, content, new Vector2(Xpos, Ypos), "Start");
            quitButton = new QuitButton(game, graphicsDevice, content, new Vector2(Xpos, Ypos + 45),  "Quit");
            buttons.Add(startButton);
            buttons.Add(quitButton);
            backgroundtexture = content.Load<Texture2D>("background"); 
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundtexture, new Rectangle(0, 0, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight), Color.White);

            foreach (Button.Button item in buttons)
            {
                item.Draw(spriteBatch);
            }
        }

        public override void LoadContent()
        {

            
        }

        public override void PostUpdate(GameTime gameTime)
        {
        }

        public override void Update(GameTime gameTime)
        {
            //startButton.Update(gameTime);
            foreach (Button.Button item in buttons)
            {
                item.Update(gameTime);
                
            }
        }
    }
}
