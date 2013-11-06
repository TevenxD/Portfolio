using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.entity;
using ShootEmUp.resources;

namespace ShootEmUp.content.player
{
    class PowerUp : Sprite
    {
        public int speed;
        public Rectangle bounds;

        public PowerUp(Vector2 position, int speed, int power) : base (Globals.Content.Load<Texture2D>("sprites\\player\\powerUp"), position)
        {
            this.srcRect = new Rectangle(0, 0, 32, 32);
            this.bounds = new Rectangle((int)position.X, (int)position.Y, 32, 32);

            this.animation = power;
            this.speed = speed;
        }

        public override void Update(GameTime gameTime)
        {
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
            bounds.Y = (int)position.Y;

            base.Update(gameTime);

            if (position.Y > Globals.ScreenHeight)
                Locals.powerUps.Remove(this);
        }
    }
}
