using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.resources;

namespace ShootEmUp.content.enemy
{
    class ShootEnemy : Enemy
    {
        public float shootRate;
        private float shootTimer = 0f;

        private bool start = false;

        public ShootEnemy(Vector2 position, float speed, float direction, int health = 2, float waitTimer = 1000f, float shootRate = 1000f, int bulletSpeed = 6*60) : base(Assets.shootEnemy, position)
        {
            this.waitTimer = waitTimer;

            this.speed = speed;
            this.direction = direction;

            this.health = health;
            this.shootRate = shootRate;
            this.bulletSpeed = bulletSpeed;

            this.srcRect = new Rectangle(0, 0, 32, 32);
            this.bounds = new Rectangle((int)position.X, (int)position.Y, srcRect.Width, srcRect.Height);

            this.totalFrames = 10;

            bulletTexture = Assets.redBullet;
        }

        public override void Update(GameTime gameTime)
        {
            if (!start && bounds.IsInsideScreen())
            {
                if (bounds.IsOnLeftScreen())
                    position.X = 0;
                if (bounds.IsOnRightScreen())
                    position.X = Globals.ScreenWidth - bounds.Width;

                start = true;
            }

            shootTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (shootTimer > shootRate)
            {
                shootTimer = 0;
                Shoot(center, 90);
            }

            animation = health;
            base.Update(gameTime);

            if (bounds.IsOnLeftScreen() && start)
            {
                direction -= 180;
                position.X = 0;
            }
            if (bounds.IsOnRightScreen() && start)
            {
                direction += 180;
                position.X = Globals.ScreenWidth - bounds.Width;
            }

            if (bounds.IsOutDownScreen())
                Locals.enemys.Remove(this);
        }

        protected override void Dead()
        {
            Locals.enemys.Remove(this);
            Locals.gameScore += 200;
        }
    }
}
