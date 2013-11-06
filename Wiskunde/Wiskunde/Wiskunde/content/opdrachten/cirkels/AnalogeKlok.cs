using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;
using Wiskunde.entity;

namespace Wiskunde.content.opdrachten.cirkels
{
    class AnalogeKlok : Opdracht
    {
        Texture2D clockBase;
        DateTime time;

        Pijl secWijzer;
        Pijl minWijzer;
        Pijl uurWijzer;

        float straal;

        public AnalogeKlok()
        {
            name = "Analoge klok";
            nameColor = Color.Black;
        }

        public override void Init()
        {
            clockBase = Assets.klok;
            straal = clockBase.Width / 2;

            secWijzer = new Pijl(new Rectangle((int)Globals.ScreenCenter.X, (int)Globals.ScreenCenter.Y, 2, (int)(straal / 2)), Color.Black);
            minWijzer = new Pijl(new Rectangle((int)Globals.ScreenCenter.X, (int)Globals.ScreenCenter.Y, 3, (int)straal - 20), Color.DarkBlue);
            uurWijzer = new Pijl(new Rectangle((int)Globals.ScreenCenter.X, (int)Globals.ScreenCenter.Y, 3, (int)(straal / 1.2f)), Color.DarkGreen);

            BeweegWijzers();
        }

        public override void Update(GameTime gameTime)
        {
            BeweegWijzers();
        }

        private void BeweegWijzers()
        {
            time = DateTime.Now;

            secWijzer.rotation = ((time.Second * 360 / 60 + 180) * (float)Math.PI) / 180;
            minWijzer.rotation = ((time.Minute * 360 / 60 + 180) * (float)Math.PI) / 180;

            float uur = (100f / 60f) * (float)time.Minute / 100f + time.Hour;
            uurWijzer.rotation = ((uur * 360 / 12 + 180) * (float)Math.PI) / 180;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
            spriteBatch.Draw(clockBase, Globals.ScreenCenter, null, Color.Silver, 0f, new Vector2(clockBase.Width / 2, clockBase.Height / 2), 1f, SpriteEffects.None, 1f);

            secWijzer.Draw(spriteBatch);
            minWijzer.Draw(spriteBatch);
            uurWijzer.Draw(spriteBatch);
        }
    }
}
