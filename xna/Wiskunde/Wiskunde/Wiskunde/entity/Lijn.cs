using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;

namespace Wiskunde.entity
{
    class Lijn
    {
        public Vector2 begin, end;
        public Color color;
        public float thick;
        public float a, b, c;

        public Lijn(Vector2 beginPosition, Vector2 endPosition, Color color, float thick = 1f)
        {
            this.begin = beginPosition;
            this.end = endPosition;
            this.color = color;
            this.thick = thick;
        }

        public virtual float BerekenX(float Y)
        {
            return (c - b * Y) / a;
        }

        public virtual float BerekenY(float X)
        {
            return (c - a * X) / b;
        }

        public virtual void BerekenC(Vector2 P)
        {
            c = a * P.X + b * P.Y;
        }


        public virtual void MoveTo(Vector2 position)
        {
            begin = position;
        }

        public virtual void DrawTo(Vector2 position)
        {
            end = position;
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            float angle = (float)Math.Atan2(end.Y - begin.Y, end.X - begin.X);
            float length = Vector2.Distance(begin, end);

            Texture2D blank = new Texture2D(Globals.graphicsDevice, 1, 1, false, SurfaceFormat.Color);
            blank.SetData(new[] { Color.White });

            spriteBatch.Draw(blank, begin, null, color, angle, Vector2.Zero, new Vector2(length, thick), SpriteEffects.None, 0);
        }
    }
}
