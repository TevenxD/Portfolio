using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditorTest5.content.objects
{
    public delegate void ClickEvent(Object sender);

    class Button
    {
        public event ClickEvent Click;
        private MouseState mousePress, mouseRelease;

        public Vector2 position;
        public Texture2D texture;
        public Rectangle srcRect;
        public Rectangle bounds;

        public Button(Texture2D texture, Vector2 position, Rectangle srcRect)
        {
            this.position = position;
            this.texture = texture;
            this.srcRect = srcRect;

            bounds = new Rectangle((int)position.X, (int)position.Y, srcRect.Width, srcRect.Height);
        }

        public void Update()
        {
            mousePress = Mouse.GetState();
            if (bounds.Contains(mousePress.X, mousePress.Y))
            {
                srcRect.Y = srcRect.Height;

                if (mousePress.LeftButton == ButtonState.Pressed && mouseRelease.LeftButton == ButtonState.Released)
                    if (Click != null) Click(this);

                if (mousePress.LeftButton == ButtonState.Pressed)
                    srcRect.Y = srcRect.Height * 2;
            }
            else srcRect.Y = 0;

            mouseRelease = mousePress;

            bounds.X = (int)position.X;
            bounds.Y = (int)position.Y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, position, srcRect, Color.White);
            spriteBatch.End();
        }
    }
}
