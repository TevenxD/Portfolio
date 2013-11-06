using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.content.opdrachten;
using Wiskunde.resources;
using Wiskunde.entity;

namespace Wiskunde.content.screens
{
    class GameScreen : Screen
    {
        Opdracht opdracht;
        Button backButton;

        public GameScreen(Opdracht opdracht)
        {
            this.opdracht = opdracht;
            this.opdracht.Init();
            this.opdracht.namePosition = new Vector2(24, 0);

            this.backButton = new Button(Assets.backButton, new Vector2(0, 0), new Rectangle(0, 0, 20, 20));
            this.backButton.Click += new ClickEvent(Exit);
        }

        public override void Update(GameTime gameTime)
        {
            opdracht.Update(gameTime);
            backButton.Update(gameTime);
        }

        private void Exit(Object sender)
        {
            ScreenManager.screen = new StartScreen();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            opdracht.Draw(spriteBatch);
            backButton.Draw(spriteBatch);
        }
    }
}
