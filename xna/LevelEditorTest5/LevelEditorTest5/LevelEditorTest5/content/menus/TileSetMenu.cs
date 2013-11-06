using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LevelEditorTest5.content.objects;

namespace LevelEditorTest5.content.menus
{
    class TileSetMenu
    {
        private MovingBackground background;

        public Button left;
        public Button right;
        public Button up;
        public Button down;

        public Button nextTileset;
        public Button prevTileset;

        private Texture2D menu;
        private Vector2 position;
        private TileMap tileset;

        public int tileIndex;

        public TileSetMenu(Vector2 position, TileMap tileset)
        {
            this.position = position;
            this.tileset = tileset;

            tileset.CreateNewTileSet(tileIndex);

            menu = GameUsage.tileSetMenu;

            right = new Button(GameButtons.rightTex, new Vector2(position.X + menu.Width - 32, position.Y + menu.Height - 16), GameButtons.srcRight);
            left = new Button(GameButtons.leftTex, new Vector2(position.X + 16, position.Y + menu.Height - 16), GameButtons.srcLeft);
            down = new Button(GameButtons.downTex, new Vector2(position.X + menu.Width - 16, position.Y + menu.Height - 32), GameButtons.srcDown);
            up = new Button(GameButtons.upTex, new Vector2(position.X + menu.Width - 16, position.Y + 16), GameButtons.srcUp);

            nextTileset = new Button(GameButtons.grayRightTex, new Vector2(position.X + menu.Width - 32, position.Y + 0), GameButtons.srcGrayRight);
            prevTileset = new Button(GameButtons.grayRightTex, new Vector2(position.X + 16, position.Y + 0), GameButtons.srcGrayLeft);

            right.Click += new ClickEvent(ScrollRight);
            left.Click += new ClickEvent(ScrollLeft);
            down.Click += new ClickEvent(Scrolldown);
            up.Click += new ClickEvent(Scrollup);

            nextTileset.Click += new ClickEvent(NextTileSet);
            prevTileset.Click += new ClickEvent(PrevTileSet);

            background = new MovingBackground(new Vector2(position.X + 16, position.Y + 16), GameUsage.backTile2, 16, 16, 7, 208, 80);
        }

        public void NextTileSet(Object sender)
        {
            tileIndex++;
            if (tileIndex > GameUsage.tilesets.Count - 1)
                tileIndex = 0;

            tileset.CreateNewTileSet(tileIndex);
        }
        public void PrevTileSet(Object sender)
        {
            tileIndex--;
            if (tileIndex < 0)
                tileIndex = GameUsage.tilesets.Count - 1;

            tileset.CreateNewTileSet(tileIndex);
        }

        public void ScrollRight(Object sender)
        {
            tileset.Scroll("right");
        }
        public void ScrollLeft(Object sender)
        {
            tileset.Scroll("left");
        }
        public void Scrolldown(Object sender)
        {
            tileset.Scroll("down");
        }
        public void Scrollup(Object sender)
        {
            tileset.Scroll("up");
        }

        public void Update(GameTime gameTime)
        {
            right.Update();
            left.Update();
            down.Update();
            up.Update();

            nextTileset.Update();
            prevTileset.Update();

            background.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(menu, position, Color.White);
            spriteBatch.End();

            background.Draw(spriteBatch);

            right.Draw(spriteBatch);
            left.Draw(spriteBatch);
            down.Draw(spriteBatch);
            up.Draw(spriteBatch);

            nextTileset.Draw(spriteBatch);
            prevTileset.Draw(spriteBatch);
        }
    }
}
