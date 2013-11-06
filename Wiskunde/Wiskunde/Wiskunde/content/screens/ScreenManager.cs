using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Wiskunde.content.screens
{
    class ScreenManager
    {
        public static Screen screen;

        public ScreenManager()
        {

        }

        public void Update(GameTime gameTime)
        {
            screen.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screen.Draw(spriteBatch);
        }
    }
}
