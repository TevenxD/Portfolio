using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wiskunde.resources
{
    abstract class Assets
    {
        public static SpriteFont spriteFont1 = Globals.Content.Load<SpriteFont>("fonts\\SpriteFont1");

        public static Texture2D grid = Globals.Content.Load<Texture2D>("content\\backgrounds\\grid");
        public static Texture2D klok = Globals.Content.Load<Texture2D>("content\\backgrounds\\ClockBase");

        public static Texture2D punt1 = Globals.Content.Load<Texture2D>("content\\punten\\punt1");
        public static Texture2D cross = Globals.Content.Load<Texture2D>("content\\punten\\cross");
        public static Texture2D triangle = Globals.Content.Load<Texture2D>("content\\punten\\driehoek");

        public static Texture2D backButton = Globals.Content.Load<Texture2D>("content\\buttons\\backButton");

        public static Texture2D CreateRectangle(Rectangle rect, Color color)
        {
            if (rect.Width <= 0)
                rect.Width = 1;
            if (rect.Height <= 0)
                rect.Height = 1;

            Texture2D tex = new Texture2D(Globals.graphicsDevice, rect.Width, rect.Height);
            Color[] data = new Color[rect.Width * rect.Height];

            for (int i = 0; i < data.Length; ++i)
                data[i] = color;

            tex.SetData(data);

            return tex;
        }

        public static Texture2D CreateCircle(int radius)
        {
            int outerRadius = radius * 2 + 2; // So circle doesn't go out of bounds
            Texture2D texture = new Texture2D(Globals.graphicsDevice, outerRadius, outerRadius);

            Color[] data = new Color[outerRadius * outerRadius];

            // Colour the entire texture transparent first.
            for (int i = 0; i < data.Length; i++)
                data[i] = Color.Transparent;

            // Work out the minimum step necessary using trigonometry + sine approximation.
            double angleStep = 1f / radius;

            for (double angle = 0; angle < Math.PI * 2; angle += angleStep)
            {
                int x = (int)Math.Round(radius + radius * Math.Cos(angle));
                int y = (int)Math.Round(radius + radius * Math.Sin(angle));

                data[y * outerRadius + x + 1] = Color.White;
            }

            texture.SetData(data);
            return texture;
        }
    }
}
