using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootEmUp.content.screens
{
    class ScreenManager
    {
        public static Screen currentScreen, previousScreen;

        public ScreenManager()
        {

        }

        public static void CreateScreen(Screen screen)
        {
            previousScreen = currentScreen;
            currentScreen = screen;
        }

        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}
