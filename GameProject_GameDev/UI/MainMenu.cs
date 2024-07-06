using GameProject_GameDev.Button;
using GameProject_GameDev.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject_GameDev.UI
{
    internal class MainMenu : IGameObject
    {
        private StartButton startButton;
        List<Button.Button> buttons;
        private QuitButton quitButton;
        private Texture2D texture;
        private Rectangle rectangle;
        public MainMenu(Texture2D texture, SpriteFont font, Texture2D but, Texture2D but2) //but is een tijdelijke oplossing
        {
            
            this.texture = texture;
            int Xpos = ScreenSettings.ScreenWidth / 2 - 50; // nog aanpassen
            int Ypos = ScreenSettings.ScreenHeight / 2 - 15; // nog aanpassen
            startButton = new StartButton(new Vector2(Xpos, Ypos),but, font, "Start");
            quitButton = new QuitButton(new Vector2(Xpos, Ypos + 45), but2, font, "Quit");
        }
        public void Draw(SpriteBatch spriteBatch)
        {
          
            spriteBatch.Draw(texture, new Rectangle(0, 0, ScreenSettings.ScreenWidth, ScreenSettings.ScreenHeight), Color.White);
            startButton.Draw(spriteBatch);
            quitButton.Draw(spriteBatch);


        }

        public void Update(GameTime time)
        {
            startButton.Update(time);
            quitButton.Update(time);
        }
      
    }

}
