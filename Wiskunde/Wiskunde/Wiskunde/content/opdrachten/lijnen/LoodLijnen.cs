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
    class LoodLijnen : Opdracht
    {
        Punt P,Q,R;
        List<Lijn> lijn;

        public LoodLijnen()
        {
            name = "Loodlijn";
            nameColor = Color.Black;
            backColor = Color.LightGray;

            background = Assets.grid;
        }

        public override void Init()
        {
            P = new Punt(new Vector2(100, 400), Color.Red);
            Q = new Punt(new Vector2(600, 100), Color.Purple);
            R = new Punt(new Vector2(440, 320), Color.Yellow);

            lijn = new List<Lijn>();
            lijn.Add(new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 3));
            lijn.Add(new Lijn(Vector2.Zero, Vector2.Zero, Color.Red, 3));
        }

        public override void Update(GameTime gameTime)
        {
            P.Update(gameTime);
            Q.Update(gameTime);
            R.Update(gameTime);

            // lijn door twee punten (zwarte)
            lijn[0].a = P.Y - Q.Y;
            lijn[0].b = Q.X - P.X;
            lijn[0].BerekenC(P.position);

            // loodlijn (rode)
            lijn[1].a = -lijn[0].b;
            lijn[1].b = lijn[0].a;
            lijn[1].BerekenC(R.position);

            foreach (Lijn l in lijn)
            {
                l.MoveTo(new Vector2(0, l.BerekenY(0)));
                l.DrawTo(new Vector2(Globals.ScreenWidth, l.BerekenY(Globals.ScreenWidth)));
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            foreach(Lijn l in lijn)
                l.Draw(spriteBatch);

            P.Draw(spriteBatch);
            Q.Draw(spriteBatch);
            R.Draw(spriteBatch);
        }
    }
}
