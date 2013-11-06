using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LevelEditorTest5.content.objects;

namespace LevelEditorTest5.content.menus
{
    class Selected
    {
        public Tile tile;
        private Texture2D menu;
        private Vector2 position;

        public Selected(Vector2 position)
        {
            this.position = position;

            menu = GameUsage.selectedMenu;
            tile = new Tile(0, new Vector2(position.X + menu.Width / 2, position.Y + menu.Height / 2), new Point(0, 0));

            tile.position.X -= tile.srcRect.Width / 2;
            tile.position.Y -= tile.srcRect.Height / 2;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(menu, position, Color.White);
            spriteBatch.End();

            tile.Draw(spriteBatch);
        }
    }
}
