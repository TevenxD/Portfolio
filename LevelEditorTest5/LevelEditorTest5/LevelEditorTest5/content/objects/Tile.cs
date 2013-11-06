using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditorTest5.content.objects
{
    class Tile
    {
        public Rectangle srcRect, bounds;
        public Vector2 position;
        public int tileIndex;
        public bool empty;

        public Tile(int tileIndex, Vector2 position, Point tileRow, bool empty = false)
        {
            this.tileIndex = tileIndex;
            this.position = position;
            this.empty = empty;

            int width = GameUsage.tilesets[tileIndex].tileWidth;
            int height = GameUsage.tilesets[tileIndex].tileHeight;

            int interspace = GameUsage.tilesets[tileIndex].interspace;
            srcRect = new Rectangle(tileRow.X * (width + interspace), tileRow.Y * (height + interspace), width, height);

            this.bounds = new Rectangle((int)position.X, (int)position.Y, srcRect.Width, srcRect.Height);
        }

        public void setPosition(float x, float y)
        {
            position.X = x;
            position.Y = y;
            bounds.X = (int)x;
            bounds.Y = (int)y;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!empty)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(GameUsage.tilesets[tileIndex].texture, position, srcRect, Color.White);
                spriteBatch.End();
            }
        }
    }
}
