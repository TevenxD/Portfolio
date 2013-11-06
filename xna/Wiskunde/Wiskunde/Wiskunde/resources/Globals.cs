using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Wiskunde.resources
{
    abstract class Globals
    {
        public static ContentManager Content;
        public static GraphicsDevice graphicsDevice;
        public static GraphicsDeviceManager graphics;
        public static Color screenColor;

        public static Vector2 ScreenCenter {
            get { return new Vector2(ScreenWidth / 2, ScreenHeight / 2); }
        }

        public static int ScreenWidth
        {
            get { return graphics.PreferredBackBufferWidth; }
            set
            {
                graphics.PreferredBackBufferWidth = value;
                graphics.ApplyChanges();
            }
        }
        public static int ScreenHeight
        {
            get { return graphics.PreferredBackBufferHeight; }
            set
            {
                graphics.PreferredBackBufferHeight = value;
                graphics.ApplyChanges();
            }
        }
    }
}
