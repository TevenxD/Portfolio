using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.IO.IsolatedStorage;
using ShootEmUp.resources;

namespace ShootEmUp.content.screens
{
    class StartScreen : Screen
    {
        private KeyboardState keyboardState, oldKeyboardState;

        private Texture2D background;
        private SpriteFont font;
        private string text;

        private Keys startKey;

        // flicker effect
        private float timer = 0f;
        private float interval = 600f;
        private bool visible = true;

        public StartScreen()
        {
            background = Assets.scoreScreen;
            font = Assets.font;

            startKey = Keys.Enter;
            text = "Press " + startKey + " to play";

            LoadScore();
        }

        public override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();

            // when key is released
            if (keyboardState.IsKeyUp(startKey) && oldKeyboardState.IsKeyDown(startKey))
            {
                ScreenManager.CreateScreen(new GameScreen());
            }

            oldKeyboardState = keyboardState;

            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            if (timer > interval)
            {
                timer = 0f;
                visible = !visible;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);

            spriteBatch.DrawString(font, "" + Locals.gameScore, new Vector2(144, 85), Color.Black);
            spriteBatch.DrawString(font, "" + Locals.highScore, new Vector2(484, 85), Color.Black);

            if (visible)
                spriteBatch.DrawString(font, text, new Vector2(Globals.ScreenWidth / 2 - text.Length * 6, 300), Color.White);
        }

        private void LoadScore()
        {
            if (File.Exists("score.sav"))
            {
                FileStream stream = new FileStream("score.sav", FileMode.Open);
                BinaryReader reader = new BinaryReader(stream);

                Locals.highScore = (int)reader.ReadInt16();

                reader.Close();
            }
        }
    }
}
