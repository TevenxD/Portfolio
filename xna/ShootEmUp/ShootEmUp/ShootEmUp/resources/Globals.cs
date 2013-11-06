using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ShootEmUp.resources
{
    abstract class Globals
    {
        public static ContentManager Content;
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

    static class CheckScreen
    {
        // inside screen
        public static bool IsOnLeftScreen(this Rectangle rect) {
            return rect.X < 0;
        }
        public static bool IsOnRightScreen(this Rectangle rect) {
            return rect.X > Globals.ScreenWidth - rect.Width;
        }
        public static bool IsOnUpScreen(this Rectangle rect) {
            return rect.Y < 0;
        }
        public static bool IsOnDownScreen(this Rectangle rect) {
            return rect.Y > Globals.ScreenHeight - rect.Height;
        }
        public static bool IsInsideScreen(this Rectangle rect) {
            return rect.X > -rect.Width && rect.X < Globals.ScreenWidth &&
                   rect.Y > -rect.Height && rect.Y < Globals.ScreenHeight;
        }

        // out of screen
        public static bool IsOutLeftScreen(this Rectangle rect) {
            return rect.X < -rect.Width;
        }
        public static bool IsOutRightScreen(this Rectangle rect) {
            return rect.X > Globals.ScreenWidth;
        }
        public static bool IsOutUpScreen(this Rectangle rect) {
            return rect.Y < -rect.Height;
        }
        public static bool IsOutDownScreen(this Rectangle rect) {
            return rect.Y > Globals.ScreenHeight;
        }
    }
}
