using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.resources;

namespace ShootEmUp.content.screens
{
    class HUD
    {
        private Texture2D hud;
        private SpriteFont font;
        private Vector2 position = new Vector2(0, Globals.ScreenHeight - 64);

        public HUD()
        {
            hud = Assets.hud;
            font = Assets.font;
        }

        public void Draw(SpriteBatch spriteBatch, int wave)
        {
            spriteBatch.Draw(hud, position, Color.White);

            spriteBatch.DrawString(font, "" + Locals.gameScore, new Vector2(position.X + 62, position.Y + 11), Color.Black);
            spriteBatch.DrawString(font, "" + Locals.gameLives, new Vector2(position.X + 58, position.Y + 37), Color.Black);
            spriteBatch.DrawString(font, "" + wave, new Vector2(position.X + 420, position.Y + 11), Color.Black);
        }
    }
}
