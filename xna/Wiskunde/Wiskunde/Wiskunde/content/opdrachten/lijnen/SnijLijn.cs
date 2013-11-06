using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.content.opdrachten.lijnen;
using Wiskunde.resources;
using Wiskunde.entity;

namespace Wiskunde.content.opdrachten.lijnen
{
    class SnijLijn : Opdracht
    {
        List<LijnDoor2Punten> lijnen;
        Vector2 snijPunt;
        Texture2D cross;

        public SnijLijn()
        {
            name = "Snijdende lijnen";
            nameColor = Color.Black;
            backColor = Color.LightGray;

            background = Assets.grid;
        }

        public override void Init()
        {
            lijnen = new List<LijnDoor2Punten>();
            lijnen.Add(new LijnDoor2Punten());
            lijnen.Add(new LijnDoor2Punten());

            lijnen[0].P = new Punt(new Vector2(100, 50), Color.Yellow);
            lijnen[0].Q = new Punt(new Vector2(620, 380), Color.Red);
            lijnen[0].lijn = new Lijn(lijnen[0].P.position, lijnen[0].Q.position, Color.BlueViolet, 3f);

            lijnen[1].P = new Punt(new Vector2(100, 420), Color.Green);
            lijnen[1].Q = new Punt(new Vector2(600, 100), Color.Blue);
            lijnen[1].lijn = new Lijn(lijnen[1].P.position, lijnen[1].Q.position, Color.OrangeRed, 3f);

            snijPunt = SnijPuntPosition();

            cross = Assets.cross;
        }

        public override void Update(GameTime gameTime)
        {
            foreach (LijnDoor2Punten lijn in lijnen)
                lijn.Update(gameTime);

            snijPunt = SnijPuntPosition();
            snijPunt.X = (float)Math.Round(snijPunt.X);
            snijPunt.Y = (float)Math.Round(snijPunt.Y);
        }

        public Vector2 SnijPuntPosition()
        {
            float Deel = (lijnen[0].lijn.a * lijnen[1].lijn.b - lijnen[1].lijn.a * lijnen[0].lijn.b);
            float X = (lijnen[1].lijn.b * lijnen[0].lijn.c - lijnen[0].lijn.b * lijnen[1].lijn.c) / Deel;
            float Y = (lijnen[1].lijn.c * lijnen[0].lijn.a - lijnen[0].lijn.c * lijnen[1].lijn.a) / Deel;

            return new Vector2(X, Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            foreach (LijnDoor2Punten lijn in lijnen)
                lijn.DrawLines(spriteBatch);

            spriteBatch.Draw(cross, snijPunt, null, Color.DarkRed, 0f, new Vector2(cross.Width/2,cross.Height/2), 1f, SpriteEffects.None, 1f);
        }
    }
}
