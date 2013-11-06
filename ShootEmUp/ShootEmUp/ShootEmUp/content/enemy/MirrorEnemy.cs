using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.resources;

namespace ShootEmUp.content.enemy
{
    class MirrorEnemy : Enemy
    {
        public float shootRate;
        private float shootTimer = 0f;

        bool canShoot;

        public MirrorEnemy(Vector2 position, float speed, float direction, int health, float waitTimer, float shootRate = 0f, int bulletSpeed = 6*60)
            : base(Assets.enemy, position)
        {
            this.waitTimer = waitTimer;

            this.speed = speed;
            this.direction = direction;

            this.health = health;

            this.srcRect = new Rectangle(0, 0, 32, 32);
            this.bounds = new Rectangle((int)position.X, (int)position.Y, srcRect.Width, srcRect.Height);

            this.totalFrames = 14;

            this.bulletTexture = Assets.redBullet;
            this.bulletSpeed = bulletSpeed;

            this.interval = 50f;

            this.canShoot = shootRate > 0f;
            this.shootRate = shootRate;

            if (canShoot)
            {
                texture = Assets.shootEnemy;
                totalFrames = 10;
            }
        }

        public override void Update(GameTime gameTime)
        {
            animation = health;

            base.Update(gameTime);

            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;

            if (bounds.IsOutLeftScreen())
            {
                position.X = Globals.ScreenWidth;
                bounds.X = (int)position.X;
            }
            if (bounds.IsOutRightScreen())
            {
                position.X = -bounds.Width;
                bounds.X = (int)position.X;
            }
            if (bounds.IsOutDownScreen())
            {
                Locals.enemys.Remove(this);
            }

            shootTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            if (shootTimer > shootRate)
            {
                shootTimer = 0;

                if (canShoot)
                    Shoot(center, 90);
            }
        }
    }
}
