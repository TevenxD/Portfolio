using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;

namespace Wiskunde.entity
{
    class Pijl
    {
        Texture2D body;
        Texture2D top;
        Color color;

        Rectangle rect;
        Vector2 origin;

        public Vector2 position;
        Vector2 trianglePos;

        public float rotation = 0f;
        private float scale = 1f;

        public Pijl(Rectangle arrow, Color color)
        {
            rect = arrow;
            origin = new Vector2(rect.Width / 2, 0);

            body = Assets.CreateRectangle(rect, color);
            top = Assets.triangle;

            position = new Vector2(rect.X, rect.Y);
            trianglePos.X = position.X;

            this.color = color;

            scale = (float)(rect.Width + 24) / (float)top.Width;
        }

        private void SetTriangle()
        {
            float angle = rotation * (float)(180 / Math.PI) + 90;
            trianglePos.X = position.X + (float)Math.Cos(angle * (Math.PI / 180)) * (rect.Height - (top.Width * scale) + 2);
            trianglePos.Y = position.Y + (float)Math.Sin(angle * (Math.PI / 180)) * (rect.Height - (top.Width * scale) + 2);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            SetTriangle();

            spriteBatch.Draw(body, position, null, Color.White, rotation, origin, 1f, SpriteEffects.None, 1f);
            spriteBatch.Draw(top, trianglePos, null, color, rotation, new Vector2(top.Width/2,0), scale, SpriteEffects.None, 1f);
        }
    }
}
