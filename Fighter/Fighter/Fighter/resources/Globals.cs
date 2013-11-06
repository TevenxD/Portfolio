using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Fighter.resources
{
    class Globals
    {
        public static ContentManager Content;
        public static GraphicsDevice graphicsDevice;
        public static GraphicsDeviceManager graphics;
        public static Color screenColor = Color.CornflowerBlue;

        public static int tileWidth = 32;
        public static int tileHeight = 32;

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
