using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.resources;

namespace ShootEmUp.content.enemy
{
    class NormalEnemy : Enemy
    {
        public NormalEnemy(Vector2 position, float speed, float direction, int health = 2, float waitTimer = 1000f) : base(Assets.enemy, position)
        {
            this.waitTimer = waitTimer;

            this.speed = speed;
            this.direction = direction;

            this.health = health;

            this.srcRect = new Rectangle(0, 0, 32, 32);
            this.bounds = new Rectangle((int)position.X, (int)position.Y, srcRect.Width, srcRect.Height);

            this.totalFrames = 14;

            this.bulletTexture = Assets.redBullet;

            this.interval = 50f;
        }

        public override void Update(GameTime gameTime)
        {
            animation = health;

            base.Update(gameTime);

            if (bounds.IsOnLeftScreen())
            {
                direction -= 90;                
                position.X = 0;
            }
            if (bounds.IsOnRightScreen())
            {
                direction += 90;
                position.X = Globals.ScreenWidth - bounds.Width;
            }

            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;

            if (bounds.IsOutDownScreen())
            {
                Locals.enemys.Remove(this);
            }
        }
    }
}
