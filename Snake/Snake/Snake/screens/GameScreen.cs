using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Snake.content;
using Snake.resources;

namespace Snake.screens
{
    class GameScreen : Screen
    {
        Level level;

        KeyboardState keyState, oldKeyState;

        public GameScreen()
        {
            Globals.screenColor = Color.Black;
            Locals.fieldColor = Color.Green;
            Locals.snakeColor = Color.Black;
            Locals.deadColor = Color.DarkRed;

            Locals.gameScore = 0;

            level = new Level(new Rectangle(4, 4, 22, 22), new Player(new Point(11, 11), 2 + Locals.difficulty, 100f / Locals.difficulty), 1);
        }

        public override void Update(GameTime gameTime)
        {
            keyState = Keyboard.GetState();

            if (!level.snake.dead)
            {
                level.Update(gameTime);

                if (keyState.IsKeyUp(Locals.pauseKey) && oldKeyState.IsKeyDown(Locals.pauseKey))
                    ScreenManager.pause = true;
            }
            else
                if (keyState.IsKeyUp(Keys.Space) && oldKeyState.IsKeyDown(Keys.Space))
                    ScreenManager.screen = new StartScreen();

            Locals.gameScore = (level.snake.positions.Count - (2 + Locals.difficulty)) * Locals.difficulty;

            oldKeyState = keyState;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            level.Draw(spriteBatch);
        }
    }
}
