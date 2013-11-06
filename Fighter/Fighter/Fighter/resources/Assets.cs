using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Fighter.entity;

namespace Fighter.resources
{
    class Assets
    {
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
        public static Texture2D CreateRectangle(Rectangle rect)
        {
            if (rect.Width <= 0)
                rect.Width = 1;
            if (rect.Height <= 0)
                rect.Height = 1;

            Texture2D tex = new Texture2D(Globals.graphicsDevice, rect.Width, rect.Height);
            Color[] data = new Color[rect.Width * rect.Height];

            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.Black;

            tex.SetData(data);

            return tex;
        }
        public static Texture2D CreateRectangle(int Width, int Height)
        {
            if (Width <= 0)
                Width = 1;
            if (Height <= 0)
                Height = 1;

            Texture2D tex = new Texture2D(Globals.graphicsDevice, Width, Height);
            Color[] data = new Color[Width * Height];

            for (int i = 0; i < data.Length; ++i)
                data[i] = Color.Black;

            tex.SetData(data);

            return tex;
        }
        public static Texture2D CreateRectangle(int Width, int Height, Color color)
        {
            if (Width <= 0)
                Width = 1;
            if (Height <= 0)
                Height = 1;

            Texture2D tex = new Texture2D(Globals.graphicsDevice, Width, Height);
            Color[] data = new Color[Width * Height];

            for (int i = 0; i < data.Length; ++i)
                data[i] = color;

            tex.SetData(data);

            return tex;
        }
        public static Texture2D CreateRectangle(int Width, int Height, Color[] data)
        {
            if (Width <= 0)
                Width = 1;
            if (Height <= 0)
                Height = 1;

            Texture2D tex = new Texture2D(Globals.graphicsDevice, Width, Height);

            tex.SetData(data);

            return tex;
        }
        public static Texture2D CreateRectangle(Rectangle rect, Color[] data)
        {
            if (rect.Width <= 0)
                rect.Width = 1;
            if (rect.Height <= 0)
                rect.Height = 1;

            Texture2D tex = new Texture2D(Globals.graphicsDevice, rect.Width, rect.Height);

            tex.SetData(data);

            return tex;
        }
    }
}
