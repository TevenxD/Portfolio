using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;
using Wiskunde.entity;

namespace Wiskunde.content.opdrachten.verhoudingen
{
    class BeeldFormaat : Opdracht
    {
        Texture2D rectTex;
        Rectangle rect;

        Punt sleepPunt;

        float surface;

        public BeeldFormaat()
        {
            name = "Beeld formaten";
            nameColor = Color.Black;
        }

        public override void Init()
        {
            rect = new Rectangle(0, Globals.ScreenHeight, 400, 400);
            surface = rect.Width * rect.Height;

            sleepPunt = new Punt(new Vector2(rect.Width, Globals.ScreenHeight), Color.Black);
            rectTex = Assets.CreateRectangle(rect, Color.CornflowerBlue);
        }

        public override void Update(GameTime gameTime)
        {
            sleepPunt.Update(gameTime);
            sleepPunt.position.Y = Globals.ScreenHeight - sleepPunt.texture.Height / 2;

            if (sleepPunt.X < 100)
                sleepPunt.position.X = 100;

            rect.Width = (int)sleepPunt.X;
            rect.Height = (int)surface / rect.Width;

            rectTex = Assets.CreateRectangle(rect, Color.CornflowerBlue);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(rectTex, rect, null, Color.White, 0f, new Vector2(0, rect.Height), SpriteEffects.None, 1f);
            sleepPunt.Draw(spriteBatch);

            spriteBatch.DrawString(font, "" + rect.Width, new Vector2(400, 100), Color.Black);
            spriteBatch.DrawString(font, "" + rect.Height, new Vector2(400, 120), Color.Black);            

            base.Draw(spriteBatch);
        }
    }
}
