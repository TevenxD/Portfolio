using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake.screens
{
    class ScreenManager
    {
        public static bool pause = false;

        public static Screen screen;
        public Screen pauseScreen;
        public HUD hud;

        public ScreenManager(Screen _screen)
        {
            screen = _screen;
            hud = new HUD(new Vector2(382, 0));

            pauseScreen = new PauseScreen();
        }

        public void Update(GameTime gameTime)
        {
            if (!pause)
                screen.Update(gameTime);
            else
                pauseScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screen.Draw(spriteBatch);
            hud.Draw(spriteBatch);

            if (pause)
                pauseScreen.Draw(spriteBatch);
        }
    }
}
