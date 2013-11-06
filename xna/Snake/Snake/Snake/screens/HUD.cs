using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Snake.resources;

namespace Snake.screens
{
    class HUD
    {
        SpriteFont font;
        Texture2D rect;

        Vector2 position;

        public HUD(Vector2 position)
        {
            this.position = position;

            font = Globals.Content.Load<SpriteFont>("SpriteFont1");
            rect = Assets.CreateRectangle(new Rectangle(0,0,128,382), Color.White);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(rect, position, Color.White);

            spriteBatch.DrawString(font, "Score", new Vector2(position.X + 12, 8), Color.Black);
            spriteBatch.DrawString(font, "" + Locals.gameScore, new Vector2(position.X + 12, 26), Color.Black);

            spriteBatch.DrawString(font, "Highscore", new Vector2(position.X + 12, 56), Color.Black);
            spriteBatch.DrawString(font, "" + Locals.highScore, new Vector2(position.X + 12, 74), Color.Black);

            spriteBatch.DrawString(font, "Snake", new Vector2(position.X + 12, 104), Color.Black);
            spriteBatch.DrawString(font, "" + Locals.snakeLength, new Vector2(position.X + 12, 122), Color.Black);
        }
    }
}
