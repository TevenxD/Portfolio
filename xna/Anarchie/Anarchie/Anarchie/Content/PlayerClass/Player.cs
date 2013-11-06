using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Anarchie.Recources;
using Anarchie.Content.Level;


namespace Anarchie.Content.PlayerClass
{
    class Player : Sprite
    {
        private KeyboardState newKeyState, oldKeyState;
        private Keys leftKey, rightKey, upKey, downKey;
        private float speed;

        public bool isOnLeft
        {
            get { return position.X < 0; }
        }

        public bool isOnRight
        {
            get { return position.X > 224; }
        }

        public bool isOnUp
        {
            get { return position.Y < 0; }
        }

        public bool isOnDown
        {
            get { return position.Y > 176; }
        }

        public Player(Vector2 position):base (Assets.player, position)
        {
            totalFrame = 2;
            interval = 200;
            interspace = 1;
            srcRect = new Rectangle(0, 0, 16, 16);
            hitTest = new Rectangle(0, 0, 16, 16);
            speed = 1;

            leftKey = Keys.Left;
            rightKey = Keys.Right;
            upKey = Keys.Up;
            downKey = Keys.Down;
        }

        public override void Update(GameTime gameTime)
        {
            newKeyState = Keyboard.GetState();

            UpdateMovement(gameTime);

            hitTest.X = (int)position.X;
            hitTest.Y = (int)position.Y;
            UpdateColission(Local.collisions);

            oldKeyState = newKeyState;
        }

        public void UpdateMovement(GameTime gameTime)
        {

            if (newKeyState.IsKeyDown(leftKey))
            {
                position.X -= speed;
                animation = 3;
                base.Update(gameTime);
            }

            if (newKeyState.IsKeyDown(rightKey))
            {
                position.X += speed;
                animation = 4;
                base.Update(gameTime);
            }

            if (newKeyState.IsKeyDown(upKey))
            {
                position.Y -= speed;
                animation = 2;
                base.Update(gameTime);
            }

            if (newKeyState.IsKeyDown(downKey))
            {
                position.Y += speed;
                animation = 1;
                base.Update(gameTime);
            }
        }

        //hier moet collision komen voor de deur
        public void UpdateColission(List<Rectangle> boundinbox)
        {
            foreach (Rectangle rect in boundinbox)
            {
                if (hitTest.isOnLeft(rect, speed))
                {
                    position.X = rect.Left - hitTest.Width;
                    hitTest.X = rect.Left - hitTest.Width;
                }

                if (hitTest.isOnRight(rect, speed))
                {
                    position.X = rect.Right;
                    hitTest.X = rect.Right;
                }
            }

            foreach (Rectangle rect in boundinbox)
            {
                if (hitTest.isOnTopOf(rect, speed))
                {
                    position.Y = rect.Top - hitTest.Width;
                    hitTest.Y = rect.Top - hitTest.Width;
                }

                if (hitTest.isUnder(rect, speed))
                {
                    position.Y = rect.Bottom;
                    hitTest.Y = rect.Bottom;
                }
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
