using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fighter.entity
{
    class Sprite
    {
        // position
        public Vector2 position;
        public Vector2 origin;
        public Vector2 center {
            get { return new Vector2(position.X - origin.X + srcRect.Width / 2, position.Y - origin.Y + srcRect.Height / 2); }
        }

        // texture
        public Texture2D texture;
        public Rectangle srcRect;
        public SpriteEffects spriteEffect;
        public Color color;
        public float rotation;
        public float scale;
        public float layerDepth;

        // animation
        public int currentFrame, totalFrames;
        public int interspace;
        public float timer;
        public float interval;
        public int animation;

        public Sprite() {
            Initialize(null, Vector2.Zero, new Rectangle(), Vector2.Zero, SpriteEffects.None, Color.White, 0f, 1f, 0f, 1, 0, 0f, 1);
        }
        public Sprite(Texture2D texture) {
            Initialize(texture, Vector2.Zero, new Rectangle(0, 0, texture.Width, texture.Height), Vector2.Zero, SpriteEffects.None, Color.White, 0f, 1f, 0f, 1, 0, 0f, 1);
        }
        public Sprite(Texture2D texture, Vector2 position) {
            Initialize(texture, position, new Rectangle(0, 0, texture.Width, texture.Height), Vector2.Zero, SpriteEffects.None, Color.White, 0f, 1f, 0f, 1, 0, 0f, 1);
        }
        public Sprite(Texture2D texture, Vector2 position, Rectangle srcRect) {
            Initialize(texture, position, srcRect, Vector2.Zero, SpriteEffects.None, Color.White, 0f, 1f, 0f, 1, 0, 0f, 1);
        }
        public Sprite(Texture2D texture, Vector2 position, Rectangle srcRect, Vector2 origin) {
            Initialize(texture, position, srcRect, origin, SpriteEffects.None, Color.White, 0f, 1f, 0f, 1, 0, 0f, 1);
        }
        public Sprite(Texture2D texture, Vector2 position, Rectangle srcRect, Vector2 origin, SpriteEffects spriteEffect) {
            Initialize(texture, position, srcRect, origin, spriteEffect, Color.White, 0f, 1f, 0f, 1, 0, 0f, 1);
        }
        public Sprite(Texture2D texture, Vector2 position, Rectangle srcRect, Vector2 origin, SpriteEffects spriteEffect, Color color) {
            Initialize(texture, position, srcRect, origin, spriteEffect, color, 0f, 1f, 0f, 1, 0, 0f, 1);
        }
        public Sprite(Texture2D texture, Vector2 position, Rectangle srcRect, Vector2 origin, SpriteEffects spriteEffect, Color color, 
            float rotation = 0f, float scale = 1f, float layerDepth = 0f, int totalFrames = 1, int interspace = 0, float interval = 200f, int animation = 1) 
        {
            Initialize(texture, position, srcRect, origin, spriteEffect, color, rotation, scale, layerDepth, totalFrames, interspace, interval, animation);
        }

        private void Initialize(Texture2D texture, Vector2 position, Rectangle srcRect, Vector2 origin, 
            SpriteEffects spriteEffect, Color color, float rotation, float scale, float layerDepth, int totalFrames, 
            int interspace, float interval, int animation)
        {
            this.texture = texture;
            this.position = position;
            this.srcRect = srcRect;
            this.origin = origin;
            this.spriteEffect = spriteEffect;
            this.color = color;
            this.rotation = rotation;
            this.scale = scale;
            this.layerDepth = layerDepth;
            this.currentFrame = 1;
            this.totalFrames = totalFrames;
            this.interspace = interspace;
            this.timer = 0f;
            this.interval = interval;
            this.animation = animation;
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
            srcRect.Y = (animation - 1) * (srcRect.Height + interspace);
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, srcRect, color, rotation, origin, scale, spriteEffect, layerDepth);
        }
    }
}
