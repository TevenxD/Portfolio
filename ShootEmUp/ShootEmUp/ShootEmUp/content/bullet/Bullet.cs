using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.resources;
using ShootEmUp.entity;

namespace ShootEmUp.content.bullet
{
    class Bullet : Sprite
    {
        public float speed;
        public float direction;

        public Rectangle bounds;

        public Bullet(Texture2D texture, Vector2 position, float speed, float direction) : base (texture, position)
        {
            this.speed = speed;
            this.direction = direction;

            this.bounds = new Rectangle((int)position.X, (int)position.Y, srcRect.Width, srcRect.Height);

            interval = 100f;
        }

        public override void Update(GameTime gameTime)
        {
            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            position.X += (float)Math.Round(Math.Cos(direction * (Math.PI / 180)) * speed * elapsed);
            position.Y += (float)Math.Round(Math.Sin(direction * (Math.PI / 180)) * speed * elapsed);

            bounds.X = (int)(position.X - origin.X);
            bounds.Y = (int)(position.Y - origin.Y);

            base.Update(gameTime);
        }
    }
}
