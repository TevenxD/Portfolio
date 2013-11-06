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
    class Assets
    {
        public static Texture2D player = Globals.contentManager.Load<Texture2D>("link");
        public static Texture2D background1 = Globals.contentManager.Load<Texture2D>("background1");
        public static Texture2D background2 = Globals.contentManager.Load<Texture2D>("background2");
        public static Texture2D switches = Globals.contentManager.Load<Texture2D>("switch");
        public static Texture2D switchDoor = Globals.contentManager.Load<Texture2D>("door");
        public static Texture2D background3 = Globals.contentManager.Load<Texture2D>("background3");

        public static Texture2D CreateRectangle(Rectangle rect, Color color)
        {
            if (rect.Width <= 0)
                rect.Width = 1;
            if (rect.Height <= 0)
                rect.Height = 1;

            Texture2D tex = new Texture2D(Globals.graphicsDevice, rect.Width, rect.Height);
            Color[] data = new Color[rect.Width * rect.Height];

            for (int i = 0; i < data.Length; i++)
                data[i] = color;

                tex.SetData(data);

            return tex;
        }
    }
}
