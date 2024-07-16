﻿using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using GameProject_GameDev.Interfaces;
using System.ComponentModel.DataAnnotations;
using Microsoft.Xna.Framework.Content;

namespace GameProject_GameDev.Button
{
    internal class Button : IGameObject
    {
        private int width = 100;
        private int height = 30;
        private Vector2 position;
        protected Rectangle button;
        protected MouseState previousMouseState;
        protected Game1 game;
        protected GraphicsDevice graphicsDevice;
        protected ContentManager content;

        private string text;
        protected Texture2D texture;
        SpriteFont font;

        public int Width
        {
            get { return 100; }
        }
        public int Height
        {
            get { return 30; }
        }
      
        public void ChangeX(int x)
        {
            position.X = x;
        }
        public void ChangeY(int x)
        {
            position.X = x;
        }
        public Button(Game1 game, GraphicsDevice graphicsDevice, ContentManager content,  Vector2 position, string text)
        {

            this.game = game;
            this.graphicsDevice = graphicsDevice;
            this.content = content;
            //this.position = position;
            button = new Rectangle((int)position.X, (int)position.Y, width, height);

            this.texture = new Texture2D(graphicsDevice, 1, 1);
            this.texture.SetData(new[] { Color.White });

            this.font = content.Load<SpriteFont>("Text");
            this.text = text; 

        }
        public virtual void Draw(SpriteBatch spritebatch)
        {
            spritebatch.Draw(texture, button, Color.White);
            Vector2 textSize = font.MeasureString(text);
            Vector2 textPos = new Vector2(
                button.X + (button.Width - textSize.X) / 2,
                button.Y + (button.Height - textSize.Y) / 2);

            spritebatch.DrawString(font, text, textPos, Color.Black);
        }
        public virtual void Update(GameTime gameTime)
        {



            MouseState currentMouseState = Mouse.GetState();


            Point mousePosition = new Point(currentMouseState.X, currentMouseState.Y);

            if (button.Contains(mousePosition))
            {

                texture.SetData(new[] { Color.LightBlue });               
            }
            else
            {
                texture.SetData(new[] { Color.White });
            }
            previousMouseState = currentMouseState; 


        }

    }
}
