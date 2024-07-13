using GameProject_GameDev.Players;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameProject_GameDev.Animations
{
    internal class Animation
    {
        public AnimationFrame CurrentFrame { get; private set; }

        public List<AnimationFrame> frames;
        private int counter;
        private double secondCounter = 0;
        private Texture2D spritetexture;

        public Animation(Texture2D texture, int widthSprite, int heightSprite)
        {
            spritetexture = texture;
            frames = new List<AnimationFrame>();
            int numberOfRows = texture.Height / heightSprite;
            frames = GetFrames(widthSprite, heightSprite, numberOfRows);

            if (frames.Count > 0)
            {
                CurrentFrame = frames[0]; // Initialize the CurrentFrame
                Debug.WriteLine($"Animation initialized with {frames.Count} frames.");
            }
            else
            {
                Debug.WriteLine("Error: No frames were created for the animation.");
            }
        }

        public void AddFrame(AnimationFrame animationFrame)
        {
            frames.Add(animationFrame);
            if (CurrentFrame == null)
            {
                CurrentFrame = frames[0];
            }
        }

        public List<AnimationFrame> GetFrames(int width, int height, int numberOfRows = 0)
        {
            List<AnimationFrame> frames = new List<AnimationFrame>();
            int columns = spritetexture.Width / width;

            for (int row = 0; row < numberOfRows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    Rectangle rec = new Rectangle(col * width, row * height, width, height);
                    frames.Add(new AnimationFrame(spritetexture, new Rectangle(col * width, row * height, width, height)));
                    Debug.WriteLine($"Frame added: Row {row}, Column {col}, SourceRectangle: {frames[frames.Count - 1].SourceRectangle}");
                }
            }

            return frames;
        }

        public void Update(GameTime gameTime)
        {
            if (frames.Count == 0) return; // Prevent out-of-range access

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int fps = 10;
            if (secondCounter >= 1d / fps)
            {
                counter++;
                secondCounter = 0;
            }

            if (counter >= frames.Count)
                counter = 0;

            CurrentFrame = frames[counter];
        }
    }
}
