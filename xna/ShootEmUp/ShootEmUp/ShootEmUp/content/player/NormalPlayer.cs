using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.entity;
using ShootEmUp.resources;
using ShootEmUp.content.bullet;

namespace ShootEmUp.content.player
{
    class NormalPlayer : Player
    {
        private enum ShootPower
        {
            Single,
            Double,
            Triple,
        }

        ShootPower power = ShootPower.Single;

        float powerInterval = 9000f;
        float powerTimer = 0f;

        public NormalPlayer(Vector2 position, float speed, float bulletSpeed) : base(Assets.player, position)
        {
            this.speed = speed;
            this.bulletSpeed = bulletSpeed;

            this.srcRect = new Rectangle(0, 0, 32, 32);
            this.bounds = new Rectangle((int)position.X, (int)position.Y, srcRect.Width, srcRect.Height);

            bulletTexture = Assets.grayBullet;

            leftKey = Keys.Left;
            rightKey = Keys.Right;
            shootKey = Locals.playKey;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (powerTimer > powerInterval)
            {
                power = ShootPower.Single;
            }
            else
                powerTimer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            foreach (PowerUp powerUp in Locals.powerUps)
            {
                if (bounds.Intersects(powerUp.bounds))
                {
                    powerTimer = 0;
                    power = (ShootPower)powerUp.animation;
                    Locals.powerUps.Remove(powerUp);
                    break;
                }
            }

            srcRect.Y = (int)power * srcRect.Height;
        }

        protected override void Shoot()
        {
            switch (power)
            {
                case ShootPower.Single:
                    base.Shoot();
                    break;
                case ShootPower.Double:
                    bullets.Add(new Bullet(bulletTexture, new Vector2(center.X - 10, center.Y), bulletSpeed, 270));
                    bullets.Add(new Bullet(bulletTexture, new Vector2(center.X + 10, center.Y), bulletSpeed, 270));

                    // set origin for the last added bullets
                    for (int i = 1; i <= 2; i++)
                        bullets[bullets.Count - i].origin = new Vector2(bulletTexture.Width / 2, bulletTexture.Height / 2);
                    break;
                case ShootPower.Triple:
                    bullets.Add(new Bullet(bulletTexture, center, bulletSpeed, 270));
                    bullets.Add(new Bullet(bulletTexture, new Vector2(center.X - 6, center.Y), bulletSpeed, 260));
                    bullets.Add(new Bullet(bulletTexture, new Vector2(center.X + 6, center.Y), bulletSpeed, 280));

                    // set origin for the last added bullets
                    for (int i = 1; i <= 3; i++)
                        bullets[bullets.Count - i].origin = new Vector2(bulletTexture.Width / 2, bulletTexture.Height / 2);
                    break;
            }
        }
    }
}
