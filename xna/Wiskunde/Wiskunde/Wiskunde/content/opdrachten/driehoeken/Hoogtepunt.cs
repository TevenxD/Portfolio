using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;
using Wiskunde.entity;

namespace Wiskunde.content.opdrachten.driehoeken
{
    class Hoogtepunt : Opdracht
    {
        Punt P, Q, R;
        Punt S, T, U;

        Lijn PQ, QR, RP;
        Lijn PQhoogtelijn, QRhoogtelijn, RPhoogtelijn;
        Lijn PS, PU, QT;

        public Hoogtepunt()
        {
            name = "Hoogtepunt";
            nameColor = Color.Black;
            backColor = Color.LightGray;

            background = Assets.grid;
        }

        public override void Init()
        {
            P = new Punt(new Vector2(200, 390), Color.DarkSeaGreen);
            Q = new Punt(new Vector2(600, 390), Color.CornflowerBlue);
            R = new Punt(new Vector2(400, 80), Color.PaleVioletRed);

            S = new Punt(Vector2.Zero, Color.Blue); S.scale = 0.5f;
            T = new Punt(Vector2.Zero, Color.Red); T.scale = 0.5f;
            U = new Punt(Vector2.Zero, Color.Green); U.scale = 0.5f;

            PQ = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 5);
            QR = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 5);
            RP = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 5);

            PS = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 2);
            PU = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 2);
            QT = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 2);

            PQhoogtelijn = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 2);
            QRhoogtelijn = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 2);
            RPhoogtelijn = new Lijn(Vector2.Zero, Vector2.Zero, Color.Black, 2);

            SetTriangleLines();
        }

        public override void Update(GameTime gameTime)
        {
            P.Update(gameTime);
            Q.Update(gameTime);
            R.Update(gameTime);

            SetTriangleLines();
            HoogteLijnen();

            S.position = SnijPunt(PQ, PQhoogtelijn);
            T.position = SnijPunt(QR, QRhoogtelijn);
            U.position = SnijPunt(RP, RPhoogtelijn);

            HoogteLijnPosities();
        }

        private void HoogteLijnPosities()
        {
            PQhoogtelijn.MoveTo(P.position);
            PQhoogtelijn.DrawTo(T.position);

            QRhoogtelijn.MoveTo(Q.position);
            QRhoogtelijn.DrawTo(U.position);

            RPhoogtelijn.MoveTo(R.position);
            RPhoogtelijn.DrawTo(S.position);

            PS.MoveTo(P.position);
            PS.DrawTo(S.position);

            PU.MoveTo(P.position);
            PU.DrawTo(U.position);

            QT.MoveTo(Q.position);
            QT.DrawTo(T.position);
        }

        private void HoogteLijnen()
        {
            PQhoogtelijn.a = -PQ.b;
            PQhoogtelijn.b = PQ.a;
            PQhoogtelijn.c = PQhoogtelijn.a * R.X + PQhoogtelijn.b * R.Y;

            QRhoogtelijn.a = -QR.b;
            QRhoogtelijn.b = QR.a;
            QRhoogtelijn.c = QRhoogtelijn.a * P.X + QRhoogtelijn.b * P.Y;

            RPhoogtelijn.a = -RP.b;
            RPhoogtelijn.b = RP.a;
            RPhoogtelijn.c = RPhoogtelijn.a * Q.X + RPhoogtelijn.b * Q.Y;
        }

        private void SetTriangleLines()
        {
            PQ.MoveTo(P.position);
            PQ.DrawTo(Q.position);

            QR.MoveTo(Q.position);
            QR.DrawTo(R.position);

            RP.MoveTo(R.position);
            RP.DrawTo(P.position);

            PQ.a = Q.Y - P.Y;
            PQ.b = P.X - Q.X;
            PQ.c = PQ.a * P.X + PQ.b * P.Y;

            QR.a = R.Y - Q.Y;
            QR.b = Q.X - R.X;
            QR.c = QR.a * R.X + QR.b * R.Y;

            RP.a = P.Y - R.Y;
            RP.b = R.X - P.X;
            RP.c = RP.a * R.X + RP.b * R.Y;
        }

        private Vector2 SnijPunt(Lijn l, Lijn m)
        {
            float X = (m.b * l.c - l.b * m.c) / (l.a * m.b - m.a * l.b);
            float Y = (m.c * l.a - l.c * m.a) / (l.a * m.b - m.a * l.b);

            return new Vector2(X, Y);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            PQ.Draw(spriteBatch);
            QR.Draw(spriteBatch);
            RP.Draw(spriteBatch);

            PQhoogtelijn.Draw(spriteBatch);
            QRhoogtelijn.Draw(spriteBatch);
            RPhoogtelijn.Draw(spriteBatch);

            PS.Draw(spriteBatch);
            PU.Draw(spriteBatch);
            QT.Draw(spriteBatch);

            P.Draw(spriteBatch);
            Q.Draw(spriteBatch);
            R.Draw(spriteBatch);

            S.Draw(spriteBatch);
            T.Draw(spriteBatch);
            U.Draw(spriteBatch);
        }
    }
}
