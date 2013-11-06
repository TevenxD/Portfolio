using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wiskunde.entity
{
    class Sprite
    {
        // Position
        public Vector2 position;
        public Vector2 origin;
        public Rectangle bounds;

        public Vector2 center
        {
            get { return new Vector2(position.X + srcRect.Width / 2, position.Y + srcRect.Height / 2); }
        }

        // Sprite
        public Texture2D texture;
        public Rectangle srcRect;
        public Color color = Color.White;
        public SpriteEffects spriteEffect;
        public float rotation = 0f;
        public float scale = 1f;
        public float layerDepth = 0f;

        // Animation
        public int currentFrame, totalFrames;
        public int interspace;
        public float timer = 0;
        public float interval;

        public int animation
        {
            get { return _animation; }
            set
            {
                _animation = value;
                srcRect.Y = (value - 1) * (srcRect.Height + interspace);
            }
        }
        private int _animation = 1;

        public Sprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            this.currentFrame = 1;

            this.srcRect = new Rectangle(0, 0, texture.Width, texture.Height);
        }

        public virtual void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                currentFrame++;
                timer = 0f;
            }
            if (currentFrame > totalFrames)
                currentFrame = 1;

            srcRect.X = (currentFrame - 1) * (srcRect.Width + interspace);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, srcRect, color, rotation, origin, scale, spriteEffect, layerDepth);
        }
    }
}
