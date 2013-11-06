using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.content.bullet;
using ShootEmUp.entity;
using ShootEmUp.resources;

namespace ShootEmUp.content.enemy
{
    class Enemy : Sprite
    {
        // stats
        public float bulletSpeed;
        public float speed;
        public int health;

        protected float direction;
        public float waitTimer;

        protected Texture2D bulletTexture;

        public Rectangle bounds;

        public Enemy(Texture2D texture, Vector2 position) : base(texture, position)
        {
            Locals.enemyBullets = new List<Bullet>();
        }

        public override void Update(GameTime gameTime)
        {
            Movement((float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        public virtual void LoseHealth(int damage)
        {
            health -= damage;

            if (health <= 0)
                Dead();
        }

        public float CountDown(GameTime gameTime)
        {
            if (waitTimer > 0)
                waitTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            return waitTimer;
        }

        protected virtual void Shoot(Vector2 bulletPos, float shootDirection = 90)
        {
            Locals.enemyBullets.Add(new Bullet(Assets.redBullet, bulletPos, bulletSpeed, shootDirection));
        }

        protected virtual void Dead()
        {
            Locals.enemys.Remove(this);
            Locals.gameScore += 100;
        }

        protected virtual void Movement(float elapsed)
        {
            position.X += (float)Math.Round(Math.Cos(direction * (Math.PI / 180)) * speed * elapsed);
            position.Y += (float)Math.Round(Math.Sin(direction * (Math.PI / 180)) * speed * elapsed);

            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;
        }
    }
}
