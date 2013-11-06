using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.content.bullet;
using ShootEmUp.entity;
using ShootEmUp.resources;

namespace ShootEmUp.content.player
{
    class Player : Sprite
    {
        public List<Bullet> bullets;
        protected Texture2D bulletTexture;

        // stats
        public float speed;
        public float bulletSpeed;      

        protected KeyboardState newKeyState, oldKeyState;
        protected Keys leftKey, rightKey, shootKey;

        public Rectangle bounds;

        public Player(Texture2D texture, Vector2 position) : base (texture, position)
        {
            bullets = new List<Bullet>();
        }

        public override void Update(GameTime gameTime)
        {
            newKeyState = Keyboard.GetState();

            float elapsed = (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (newKeyState.IsKeyDown(leftKey))
                Movement(elapsed, -1);
            if (newKeyState.IsKeyDown(rightKey))
                Movement(elapsed, 1);
            if (newKeyState.IsKeyDown(shootKey) && oldKeyState.IsKeyUp(shootKey))
                Shoot();

            if (position.X < 0)
                position.X = 0;
            if (position.X > Globals.ScreenWidth - srcRect.Width)
                position.X = Globals.ScreenWidth - srcRect.Width;

            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;

            foreach (Bullet bullet in bullets)
            {
                bullet.Update(gameTime);

                if (!bullet.bounds.IsInsideScreen())
                {
                    bullets.Remove(bullet);
                    break;
                }
            }

            base.Update(gameTime);
            oldKeyState = newKeyState;            
        }

        protected virtual void Movement(float elapsed, int direction)
        {
            if (position.X >= 0 && position.X <= Globals.ScreenWidth - srcRect.Width)
            {
                position.X += (float)Math.Round(speed * elapsed * direction);
            }
        }

        protected virtual void Shoot()
        {
            bullets.Add(new Bullet(bulletTexture, center, bulletSpeed, 270));

            // the last bullet in the list
            int last = bullets.Count - 1;

            bullets[last].origin = new Vector2(bulletTexture.Width / 2, bulletTexture.Height / 2);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet bullet in bullets)
                bullet.Draw(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
