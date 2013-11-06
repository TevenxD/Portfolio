using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;

using Wiskunde.content.opdrachten;
using Wiskunde.content.opdrachten.lijnen;
using Wiskunde.content.opdrachten.cirkels;
using Wiskunde.content.opdrachten.driehoeken;
using Wiskunde.content.opdrachten.verhoudingen;

namespace Wiskunde.content.screens
{
    class StartScreen : Screen
    {
        List<Opdracht> opdrachten;
        List<Rectangle> bounds;
        SpriteFont font;

        MouseState mouseState;

        public StartScreen() // TODO  list with all "opdrachten"   (click to open)
        {
            Globals.screenColor = Color.White;

            opdrachten = new List<Opdracht>();
            opdrachten.Add(new LijnDoor2Punten());
            opdrachten.Add(new LoodLijnen());
            opdrachten.Add(new SnijLijn());
            opdrachten.Add(new EenheidsCirkel());
            opdrachten.Add(new AnalogeKlok());
            opdrachten.Add(new Hoogtepunt());
            opdrachten.Add(new BeeldFormaat());

            bounds = new List<Rectangle>();
            for (int i = 0; i < opdrachten.Count; i++)
                bounds.Add(new Rectangle(200, 30*i, opdrachten[i].name.Length * 12, 30));

            font = Assets.spriteFont1;
        }

        public override void Update(GameTime gameTime)
        {
            mouseState = Mouse.GetState();

            for (int i = 0; i < bounds.Count; i++)
                if (bounds[i].Contains(mouseState.X, mouseState.Y) && mouseState.LeftButton == ButtonState.Pressed)
                    ScreenManager.screen = new GameScreen(opdrachten[i]);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < opdrachten.Count; i++)
                spriteBatch.DrawString(font, opdrachten[i].name, new Vector2(bounds[i].X, bounds[i].Y), Color.Black);

            for (int i = 0; i < bounds.Count; i++)
                if (bounds[i].Contains(mouseState.X, mouseState.Y))
                    spriteBatch.Draw(Assets.CreateRectangle(bounds[i], Color.Blue * 0.5f), bounds[i], Color.White);
        }
    }
}
