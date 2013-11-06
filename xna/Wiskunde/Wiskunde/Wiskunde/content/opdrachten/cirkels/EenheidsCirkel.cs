using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;
using Wiskunde.entity;

namespace Wiskunde.content.opdrachten.cirkels
{
    class EenheidsCirkel : Opdracht
    {
        float hoek;
        int circleRadius;
        Texture2D circleTex;
        Color color;
        Pijl wijzer;

        Lijn horizontaal;
        Lijn verticaal;

        MouseState mouseState;
        List<Lijn> vierkant;

        public EenheidsCirkel()
        {
            name = "Eenheidscirkel";
            nameColor = Color.Black;
        }

        public override void Init()
        {
            color = Color.DarkRed;

            vierkant = new List<Lijn>();
            for (int i = 0; i < 4; i++)
                vierkant.Add(new Lijn(Vector2.Zero, Vector2.Zero, color, 2f));

            circleRadius = 180;
            circleTex = Assets.CreateCircle(circleRadius);

            wijzer = new Pijl(new Rectangle((int)Globals.ScreenCenter.X, (int)Globals.ScreenCenter.Y, 3, circleRadius), color);

            horizontaal = new Lijn(new Vector2(0, Globals.ScreenCenter.Y), new Vector2(Globals.ScreenWidth, Globals.ScreenCenter.Y), color, 1);
            verticaal = new Lijn(new Vector2(Globals.ScreenCenter.X, 0), new Vector2(Globals.ScreenCenter.X, Globals.ScreenHeight), color, 1);
        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            hoek = (float)Math.Atan2(-(wijzer.position.Y - mouseState.Y), -(wijzer.position.X - mouseState.X));

            wijzer.rotation = (float)Math.Atan2(wijzer.position.X - mouseState.X, -(wijzer.position.Y - mouseState.Y));

            vierkant[0].MoveTo(Globals.ScreenCenter);
            vierkant[0].DrawTo(new Vector2(Globals.ScreenCenter.X, Globals.ScreenCenter.Y + circleRadius * (float)Math.Sin(hoek)));
            vierkant[1].MoveTo(vierkant[0].end);
            vierkant[1].DrawTo(new Vector2(vierkant[1].begin.X + circleRadius * (float)Math.Cos(hoek), vierkant[1].begin.Y));

            vierkant[2].MoveTo(vierkant[1].end);
            vierkant[2].DrawTo(new Vector2(vierkant[1].end.X, vierkant[0].begin.Y));
            vierkant[3].MoveTo(vierkant[2].end);
            vierkant[3].DrawTo(new Vector2(vierkant[0].begin.X, vierkant[2].end.Y));
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);

            spriteBatch.Draw(circleTex, Globals.ScreenCenter - new Vector2(circleRadius + 1, circleRadius + 1), color);
            horizontaal.Draw(spriteBatch);
            verticaal.Draw(spriteBatch);

            wijzer.Draw(spriteBatch);

            foreach (Lijn lijn in vierkant)
                lijn.Draw(spriteBatch);
        }
    }
}
