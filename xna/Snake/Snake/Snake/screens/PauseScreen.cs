using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Snake.resources;

namespace Snake.screens
{
    class PauseScreen : Screen
    {
        SpriteFont font;
        Texture2D line;
        Texture2D background;

        Vector2 linePos;
        Vector2 continueButton, quitButton;

        KeyboardState keyState, oldKeyState;

        public PauseScreen()
        {
            font = Globals.Content.Load<SpriteFont>("SpriteFont1");

            continueButton = new Vector2(148,101);
            quitButton = new Vector2(173,134);

            line = Assets.CreateRectangle(new Rectangle(0, 0, 82, 2), Color.White);
            background = Assets.CreateRectangle(new Rectangle(0, 0, Globals.ScreenWidth, Globals.ScreenHeight), Color.Black * 0.5f);

            linePos = new Vector2(continueButton.X, continueButton.Y + 22);
        }

        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            if (keyState.IsKeyUp(Locals.pauseKey) && oldKeyState.IsKeyDown(Locals.pauseKey))
                ScreenManager.pause = false;

            if ((keyState.IsKeyUp(Keys.Up) && oldKeyState.IsKeyDown(Keys.Up)) ||
                (keyState.IsKeyUp(Keys.Down) && oldKeyState.IsKeyDown(Keys.Down)))
            {
                if (linePos.Y == continueButton.Y + 22)
                {
                    linePos.X = quitButton.X;
                    linePos.Y = quitButton.Y + 24;
                    line = Assets.CreateRectangle(new Rectangle(0, 0, 34, 2), Color.White);
                }
                else if (linePos.Y == quitButton.Y + 24)
                {
                    linePos.X = continueButton.X;
                    linePos.Y = continueButton.Y + 22;
                    line = Assets.CreateRectangle(new Rectangle(0, 0, 82, 2), Color.White);
                }
            }

            if (keyState.IsKeyUp(Keys.Space) && oldKeyState.IsKeyDown(Keys.Space))
            {
                if (linePos.Y == continueButton.Y + 22)
                    ScreenManager.pause = false;
                else if (linePos.Y == quitButton.Y + 24)
                {
                    ScreenManager.pause = false;
                    ScreenManager.screen = new StartScreen();
                    Locals.gameScore = 0;

                    linePos.X = continueButton.X;
                    linePos.Y = continueButton.Y + 22;
                    line = Assets.CreateRectangle(new Rectangle(0, 0, 82, 2), Color.White);
                }
            }

            oldKeyState = keyState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            spriteBatch.Draw(line, linePos, Color.White);

            spriteBatch.DrawString(font, "continue", continueButton, Color.White);
            spriteBatch.DrawString(font, "quit", quitButton, Color.White);
        }
    }
}
