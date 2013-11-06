using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditorTest5.content.objects
{
    public delegate void SwitchEvent(Object sender);

    class Switch
    {
        public event SwitchEvent Click;
        private MouseState mousePress, mouseRelease;

        public Vector2 position;
        private Texture2D texture;
        public Rectangle srcRect, bounds;
        private int width, height;
        public bool pressed = false;

        public Switch(Texture2D tex, Vector2 position, int width, int height)
        {
            this.position = position;
            texture = tex;

            this.width = width;
            this.height = height;

            srcRect = new Rectangle(0, 0, width, height);
            bounds = new Rectangle((int)position.X, (int)position.Y, width, height);
        }

        public void Update()
        {
            mousePress = Mouse.GetState();
            if (bounds.Contains(mousePress.X, mousePress.Y))
            {
                if (mousePress.LeftButton == ButtonState.Pressed && mouseRelease.LeftButton == ButtonState.Released)
                {
                    if (Click != null) Click(this);

                    if (pressed)
                        pressed = false;
                    else
                        pressed = true;
                }
            }
            mouseRelease = mousePress;

            if (pressed)
                srcRect.Y = height;
            else
                srcRect.Y = 0;

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
