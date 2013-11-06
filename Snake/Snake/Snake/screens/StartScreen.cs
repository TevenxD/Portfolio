using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.IO.IsolatedStorage;
using Snake.resources;

namespace Snake.screens
{
    class StartScreen : Screen
    {
        SpriteFont font;
        Texture2D line;

        Vector2 linePos;
        Vector2 easy, normal, hard;

        KeyboardState keyState, oldKeyState;

        public StartScreen()
        {
            font = Globals.Content.Load<SpriteFont>("SpriteFont1");

            line = Assets.CreateRectangle(new Rectangle(0, 0, 48, 2), Color.White);

            easy = new Vector2(90, 40);
            normal = new Vector2(160, 40);
            hard = new Vector2(250, 40);

            linePos = new Vector2(easy.X, 64);

            Globals.screenColor = Color.Black;
            Locals.snakeLength = 0;

            if (Locals.gameScore > Locals.highScore)
            {
                SaveScore();
                Locals.highScore = Locals.gameScore;
            }
        }

        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(Keys.Left) && oldKeyState.IsKeyUp(Keys.Left))
                Locals.difficulty--;
            if (keyState.IsKeyDown(Keys.Right) && oldKeyState.IsKeyUp(Keys.Right))
                Locals.difficulty++;

            switch (Locals.difficulty)
            {
                case 0:
                case 1:
                    Locals.difficulty = 1;
                    line = Assets.CreateRectangle(new Rectangle(0, 0, 47, 2), Color.White);
                    linePos = new Vector2(easy.X, 64);
                    break;
                case 2:
                    line = Assets.CreateRectangle(new Rectangle(0, 0, 64, 2), Color.White);
                    linePos = new Vector2(normal.X, 64);
                    break;
                case 3:
                case 4:
                    Locals.difficulty = 3;
                    line = Assets.CreateRectangle(new Rectangle(0, 0, 47, 2), Color.White);
                    linePos = new Vector2(hard.X, 64);
                    break;
            }

            if (keyState.IsKeyUp(Keys.Space) && oldKeyState.IsKeyDown(Keys.Space))
                ScreenManager.screen = new GameScreen();

            oldKeyState = keyState;
        }

        public void SaveScore()
        {
            if (Locals.gameScore > Locals.highScore)
            {
                FileStream stream = new FileStream("score.sav", FileMode.Create);
                BinaryWriter writer = new BinaryWriter(stream);

                writer.Write(Locals.gameScore);

                writer.Close();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(line, linePos, Color.White);
            spriteBatch.DrawString(font, "Easy", easy, Color.White);
            spriteBatch.DrawString(font, "Normal", normal, Color.White);
            spriteBatch.DrawString(font, "Hard", hard, Color.White);
        }
    }
}
