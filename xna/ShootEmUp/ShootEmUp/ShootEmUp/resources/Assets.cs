using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootEmUp.resources
{
    class Assets
    {
        public static Texture2D player = Globals.Content.Load<Texture2D>("sprites\\player\\player");
        public static Texture2D powerUp = Globals.Content.Load<Texture2D>("sprites\\player\\powerUp");
        public static Texture2D grayBullet = Globals.Content.Load<Texture2D>("sprites\\player\\bullet");

        public static Texture2D redBullet = Globals.Content.Load<Texture2D>("sprites\\enemys\\bullet");
        public static Texture2D enemy = Globals.Content.Load<Texture2D>("sprites\\enemys\\enemy");
        public static Texture2D itemEnemy = Globals.Content.Load<Texture2D>("sprites\\enemys\\ItemEnemy");
        public static Texture2D shootEnemy = Globals.Content.Load<Texture2D>("sprites\\enemys\\ShootEnemy");

        public static Texture2D hud = Globals.Content.Load<Texture2D>("sprites\\menu\\hud");
        public static Texture2D scoreScreen = Globals.Content.Load<Texture2D>("sprites\\menu\\ScoreScreen");
        public static Texture2D background = Globals.Content.Load<Texture2D>("sprites\\menu\\background");

        public static SpriteFont font = Globals.Content.Load<SpriteFont>("SpriteFont");

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
    }
}
