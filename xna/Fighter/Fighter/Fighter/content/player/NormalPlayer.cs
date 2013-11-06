using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Fighter.resources;
using Fighter.entity;

namespace Fighter.content.player
{
    class NormalPlayer : Player
    {
        public NormalPlayer(Vector2 position) 
            : base(Assets.CreateRectangle(Globals.tileWidth, Globals.tileHeight*2, Color.White), position)
        {
            this.color = Color.Black;
        }

        public NormalPlayer(Vector2 position, Color color)
            : base(Assets.CreateRectangle(Globals.tileWidth, Globals.tileHeight*2, Color.White), position)
        {
            this.color = color;
        }

        protected override void Initialize()
        {
            velocity = new Vector2(4, 12);
            fallSpeed = 0;
            gravity = 0.65f;
            maxFallSpeed = 12;

            power = 8;
            defense = 0.4f;
            knockBack = 0;
            attackInterval = 200f;

            fist = new Rectangle(0, 0, 24, 24);
            fistTexture = Assets.CreateRectangle(fist, Color.White);

            direction = 1;
            damage = 0;

            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            Movement();
            Jump();
            Fall();
            KnockBackUpdate();

            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;

            Punch(gameTime);

            if (damage > 10)
                damage = 10;

            prevKeyState = keyState;

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            base.DrawFist(spriteBatch);
        }
    }
}
