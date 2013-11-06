using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Wiskunde.entity
{
    public delegate void ClickEvent(Object sender);

    class Button : Sprite
    {
        public event ClickEvent Click;
        private MouseState mousePress, mouseRelease;

        public Button(Texture2D texture, Vector2 position, Rectangle srcRect):base(texture, position)
        {
            this.srcRect = srcRect;
            this.bounds = new Rectangle((int)position.X, (int)position.Y, srcRect.Width, srcRect.Height);
        }

        public override void Update(GameTime gameTime)
        {
            mousePress = Mouse.GetState();
            if (bounds.Contains(mousePress.X, mousePress.Y))
            {
                animation = 2;

                if (mousePress.LeftButton == ButtonState.Pressed && mouseRelease.LeftButton == ButtonState.Released)
                    if (Click != null) Click(this);

                if (mousePress.LeftButton == ButtonState.Pressed)
                    animation = 3;
            }
            else animation = 1;

            mouseRelease = mousePress;

            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;

            if (totalFrames > 0)
                base.Update(gameTime);
        }
    }
}
