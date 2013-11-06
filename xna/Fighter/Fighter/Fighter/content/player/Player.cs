using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Fighter.game_properties;
using Fighter.resources;
using Fighter.entity;

namespace Fighter.content.player
{
    class Player : Sprite
    {
        public enum Attack
        {
            None,
            Punch,
            Uppercut,
            Kick,
        }
        public Attack attack;

        public Rectangle bounds;
        public Vector2 velocity;
        public int direction;

        // fist
        protected Texture2D fistTexture;
        public Rectangle fist;
        public float attackTimer;
        public float attackInterval;

        // fight
        public float knockBack;
        public float power;
        public float defense;
        public float damage;

        // keys
        protected KeyboardState keyState, prevKeyState;
        protected Keys leftKey, upKey, rightKey, punchKey, kickKey, uppercutKey;

        // falling
        public float gravity;
        public float maxFallSpeed;
        public float fallSpeed = 0;
        protected bool onGround;

        public Player(Texture2D texture) : base(texture) {
            Initialize();
        }
        public Player(Texture2D texture, Vector2 position) : base(texture, position) {
            Initialize();
        }
        public Player(Sprite sprite) : base(sprite.texture, sprite.position, sprite.srcRect, 
            sprite.origin, sprite.spriteEffect, sprite.color, sprite.rotation, sprite.scale, 
            sprite.layerDepth, sprite.totalFrames, sprite.interspace, sprite.interval, sprite.animation) 
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            attack = Attack.None;
        }

        public virtual void SetKeys(Keys leftKey, Keys upKey, Keys rightKey, Keys punchKey, Keys kickKey, Keys uppercutKey)
        {
            this.leftKey = leftKey;
            this.rightKey = rightKey;
            this.upKey = upKey;            
            this.punchKey = punchKey;
            this.kickKey = kickKey;
            this.uppercutKey = uppercutKey;
        }

        public virtual void Movement()
        {
            if (keyState.IsKeyDown(leftKey))
            {
                position.X -= velocity.X;
                direction = -1;
            }
            if (keyState.IsKeyDown(rightKey))
            {
                position.X += velocity.X;
                direction = 1;
            }
        }

        public virtual void Jump()
        {
            if (keyState.IsKeyDown(upKey) && prevKeyState.IsKeyUp(upKey) && onGround)
            {
                fallSpeed = -velocity.Y;
                onGround = false;
            }
        }

        public virtual void Fall()
        {
            if (fallSpeed < maxFallSpeed)
                fallSpeed += gravity;
            else
                fallSpeed = maxFallSpeed;

            position.Y += fallSpeed;
        }

        public virtual void Punch(GameTime gameTime)
        {
            if (attackTimer > 0)
            {
                attackTimer -= (float)gameTime.ElapsedGameTime.TotalMilliseconds;
                SetFist();
            }
            else if (keyState.IsKeyDown(punchKey) && prevKeyState.IsKeyUp(punchKey))
            {
                attack = Attack.Punch;
                attackTimer = attackInterval;
                SetFist();
            }
            else if (keyState.IsKeyDown(kickKey) && prevKeyState.IsKeyUp(kickKey))
            {
                attack = Attack.Kick;
                attackTimer = attackInterval;
                SetFist();
            }
            else if (keyState.IsKeyDown(uppercutKey) && prevKeyState.IsKeyUp(uppercutKey))
            {
                attack = Attack.Uppercut;
                attackTimer = attackInterval;
                SetFist();
            }
            else if (attackTimer <= 0)
                attack = Attack.None;
        }

        protected virtual void SetFist()
        {
            switch (attack)
            {
                case Attack.Punch:
                    if (direction == 1)
                    {
                        fist.X = (int)position.X + bounds.Width;
                        fist.Y = (int)position.Y;
                    }
                    if (direction == -1)
                    {
                        fist.X = (int)position.X - fist.Width;
                        fist.Y = (int)position.Y;
                    }
                    break;
                case Attack.Kick:
                    if (direction == 1)
                    {
                        fist.X = (int)position.X + bounds.Width - fist.Width;
                        fist.Y = (int)position.Y + bounds.Height;
                    }
                    if (direction == -1)
                    {
                        fist.X = (int)position.X;
                        fist.Y = (int)position.Y + bounds.Height;
                    }
                    break;
                case Attack.Uppercut:
                    if (direction == 1)
                    {
                        fist.X = (int)position.X + bounds.Width - fist.Width;
                        fist.Y = (int)position.Y - fist.Height;
                    }
                    if (direction == -1)
                    {
                        fist.X = (int)position.X;
                        fist.Y = (int)position.Y - fist.Height;
                    }
                    break;
            }
        }

        public virtual void KnockBackUpdate()
        {
            position.X += knockBack;

            if (knockBack < -defense)
                knockBack += defense;
            else if (knockBack > defense)
                knockBack -= defense;
            else
                knockBack = 0;
        }

        public virtual void PlatformCollision(Rectangle collision)
        {
            if (bounds.isOnTopOf(collision, fallSpeed))
            {
                position.Y = collision.Top - bounds.Height;
                fallSpeed = 0;
                onGround = true;
            }
        }

        public virtual void DrawFist(SpriteBatch spriteBatch)
        {
            if (attack != Attack.None)
                spriteBatch.Draw(fistTexture, fist, Color.White);
        }
    }
}
