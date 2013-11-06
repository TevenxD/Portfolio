using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;

namespace Wiskunde.entity
{
    class Punt : Sprite
    {
        MouseState mouseState, oldMouseState;
        bool drag = false;

        public Point point = new Point();

        public Punt(Vector2 position, Color color) : base(Assets.punt1, position)
        {
            this.color = color;
            this.bounds = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            this.origin = new Vector2(texture.Width / 2, texture.Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            if (mouseState.LeftButton == ButtonState.Pressed && oldMouseState.LeftButton == ButtonState.Released && bounds.Contains(mouseState.X, mouseState.Y))
                drag = true;

            if (drag && mouseState.LeftButton == ButtonState.Pressed)
            {
                position.X = mouseState.X;
                position.Y = mouseState.Y;
            }

            if (drag && mouseState.LeftButton == ButtonState.Released)
                drag = false;

            if (position.X > Globals.ScreenWidth)
                position.X = Globals.ScreenWidth;
            if (position.X < 0)
                position.X = 0;

            if (position.Y > Globals.ScreenHeight)
                position.Y = Globals.ScreenHeight;
            if (position.Y < 0)
                position.Y = 0;

            bounds.X = (int)(position.X - origin.X);
            bounds.Y = (int)(position.Y - origin.Y);

            point.X = bounds.X;
            point.Y = bounds.Y;

            if (totalFrames > 0)
                base.Update(gameTime);

            oldMouseState = mouseState;
        }

        public float X {
            get { return position.X; }
        }
        public float Y {
            get { return position.Y; }
        }
    }
}
