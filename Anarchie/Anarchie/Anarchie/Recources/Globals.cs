using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Anarchie.Recources
{
    class Globals
    {
        public static ContentManager contentManager;
        public static GraphicsDevice graphicsDevice;
        public static GraphicsDeviceManager graphics;
        public static Color screenColor = Color.CornflowerBlue;

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
