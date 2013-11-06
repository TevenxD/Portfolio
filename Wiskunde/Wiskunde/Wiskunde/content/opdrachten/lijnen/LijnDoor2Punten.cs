using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;
using Wiskunde.entity;

namespace Wiskunde.content.opdrachten.lijnen
{
    class LijnDoor2Punten : Opdracht
    {
        public Punt P,Q;
        public Lijn lijn;

        public LijnDoor2Punten()
        {
            name = "Lijn door twee punten";
            nameColor = Color.Black;
            backColor = Color.LightGray;

            background = Assets.grid;
        }

        public override void Init()
        {
            P = new Punt(new Vector2(100, 400), Color.Green);
            Q = new Punt(new Vector2(300, 200), Color.Blue);

            lijn = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 3);
        }

        public override void Update(GameTime gameTime)
        {
            P.Update(gameTime);
            Q.Update(gameTime);

            lijn.a = P.Y - Q.Y;
            lijn.b = Q.X - P.X;
            lijn.BerekenC(P.position);

            lijn.MoveTo(new Vector2(0, lijn.BerekenY(0)));
            lijn.DrawTo(new Vector2(Globals.ScreenWidth, lijn.BerekenY(Globals.ScreenWidth)));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            DrawLines(spriteBatch);
        }

        public void DrawLines(SpriteBatch spriteBatch)
        {
            lijn.Draw(spriteBatch);
            P.Draw(spriteBatch);
            Q.Draw(spriteBatch);
        }
    }
}
