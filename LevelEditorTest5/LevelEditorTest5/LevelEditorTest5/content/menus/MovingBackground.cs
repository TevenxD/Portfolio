using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditorTest5.content.menus
{
    class MovingBackground
    {
        private Texture2D texture;
        private int tileWidth, tileHeight;
        private int Width, Height;
        public bool move = true;

        private int currentFrame = 0, frames;
        private float interval = 100f;
        private float timer = 0f;

        public Vector2 position;

        public MovingBackground(Vector2 position, Texture2D texture, int tileWidth, int tileHeight, int frames, int Width, int Height)
        {
            this.texture = texture;
            this.tileWidth = tileWidth;
            this.tileHeight = tileHeight;
            this.frames = frames;

            this.Width = Width;
            this.Height = Height;
            this.position = position;
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                if (move)
                {
                    currentFrame++;
                    if (currentFrame > frames) currentFrame = 0;
                }
                timer = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = 0; y < Height / tileHeight; y++)
                for (int x = 0; x < Width / tileWidth; x++)
                {
                    spriteBatch.Begin();
                    spriteBatch.Draw(texture, new Vector2(position.X + x * tileWidth, position.Y + y * tileHeight), new Rectangle(currentFrame * tileWidth, 0, tileWidth, tileHeight), Color.White);
                    spriteBatch.End();
                }
        }
    }
}
