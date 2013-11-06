using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace LevelEditorTest5.content.objects
{
    class TileMap
    {
        public List<List<Tile>> tiles;
        private Tile selectedTile;

        private MouseState mousePress, mouseRelease;

        public int tileWidth, tileHeight;
        public int lengthX, lengthY;
        public int Width, Height;

        public Point scroll = new Point(0, 0);
        private Point scrollMax = new Point(0, 0);

        public Vector2 position;
        public bool editMode = false;

        public TileMap(Vector2 position, Tile tile, int width, int height)
        {
            this.position = position;
            selectedTile = tile;

            this.Width = width;
            this.Height = height;
        }

        public void CreateNewTileSet(int tileIndex)
        {
            tileWidth = GameUsage.tilesets[tileIndex].tileWidth;
            tileHeight = GameUsage.tilesets[tileIndex].tileHeight;

            lengthX = GameUsage.tilesets[tileIndex].lengthX;
            lengthY = GameUsage.tilesets[tileIndex].lengthY;

            scroll.X = 0;
            scroll.Y = 0;
            scrollMax.X = lengthX - Width / tileWidth;
            scrollMax.Y = lengthY - Height / tileHeight;
            if (scrollMax.X < 0) scrollMax.X = 0;
            if (scrollMax.Y < 0) scrollMax.Y = 0;

            tiles = new List<List<Tile>>();

            for (int y = 0; y < lengthY; y++)
            {
                tiles.Add(new List<Tile>());

                for (int x = 0; x < lengthX; x++)
                    tiles[y].Add(new Tile(tileIndex, new Vector2(x * tileWidth, y * tileWidth), new Point(x, y)));
            }

            selectedTile.srcRect = tiles[0][0].srcRect;
            selectedTile.tileIndex = tileIndex;
        }

        public void CreateNewMap(int mapWidth, int mapHeight, bool empty)
        {
            tileWidth = selectedTile.srcRect.Width;
            tileHeight = selectedTile.srcRect.Height;

            lengthX = mapWidth / tileWidth;
            lengthY = mapHeight / tileHeight;

            scroll.X = 0;
            scroll.Y = 0;
            scrollMax.X = lengthX - Width / tileWidth;
            scrollMax.Y = lengthY - Height / tileHeight;
            if (scrollMax.X < 0) scrollMax.X = 0;
            if (scrollMax.Y < 0) scrollMax.Y = 0;

            editMode = true;
            tiles = new List<List<Tile>>();

            for (int y = 0; y < lengthY; y++)
            {
                tiles.Add(new List<Tile>());

                for (int x = 0; x < lengthX; x++)
                    tiles[y].Add(new Tile(selectedTile.tileIndex, new Vector2(x * tileWidth, y * tileHeight), new Point(0,0), empty));
            }
        }

        public void FillMap()
        {
            for (int y = 0; y < lengthY; y++)
                for (int x = 0; x < lengthX; x++)
                {
                    tiles[y][x].tileIndex = selectedTile.tileIndex;
                    tiles[y][x].srcRect = selectedTile.srcRect;
                    tiles[y][x].empty = false;
                }
        }

        public void EmptyMap()
        {
            for (int y = 0; y < lengthY; y++)
                for (int x = 0; x < lengthX; x++)
                {
                    tiles[y][x].empty = true;
                }
        }

        public void Update()
        {
            KeyboardState key = Keyboard.GetState();

            for (int y = scroll.Y; y < lengthY - (scrollMax.Y - scroll.Y); y++)
                for (int x = scroll.X; x < lengthX - (scrollMax.X - scroll.X); x++)
                    click(x, y);

            if (!key.IsKeyDown(Keys.LeftShift) && !key.IsKeyDown(Keys.RightShift) || !editMode)
                mouseRelease = mousePress;
        }

        private void click(int x, int y)
        {
            mousePress = Mouse.GetState();
            bool mouseOver = tiles[y][x].bounds.Contains(mousePress.X, mousePress.Y);

            if (mousePress.LeftButton == ButtonState.Pressed && mouseRelease.LeftButton == ButtonState.Released && mouseOver)
            {
                if (editMode)
                {
                    tiles[y][x].srcRect = selectedTile.srcRect;
                    tiles[y][x].tileIndex = selectedTile.tileIndex;
                    tiles[y][x].empty = false;
                }
                else selectedTile.srcRect = tiles[y][x].srcRect;
            }
            if (mousePress.RightButton == ButtonState.Pressed && mouseRelease.RightButton == ButtonState.Released && mouseOver && editMode)
                tiles[y][x].empty = true;
        }

        public void Scroll(string direction)
        {
            switch (direction)
            {
                default:
                case "right":
                    scroll.X++;
                    if (scroll.X > scrollMax.X) scroll.X = scrollMax.X;
                    break;
                case "left":
                    scroll.X--;
                    if (scroll.X < 0) scroll.X = 0;
                    break;
                case "down":
                    scroll.Y++;
                    if (scroll.Y > scrollMax.Y) scroll.Y = scrollMax.Y;
                    break;
                case "up":
                    scroll.Y--;
                    if (scroll.Y < 0) scroll.Y = 0;
                    break;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int y = scroll.Y; y < lengthY - (scrollMax.Y - scroll.Y); y++)
                for (int x = scroll.X; x < lengthX - (scrollMax.X - scroll.X); x++)
                {
                    tiles[y][x].setPosition(position.X + (x * tileWidth) - (scroll.X * tileWidth), position.Y + (y * tileHeight) - (scroll.Y * tileWidth));
                    tiles[y][x].Draw(spriteBatch);
                }
        }
    }
}
