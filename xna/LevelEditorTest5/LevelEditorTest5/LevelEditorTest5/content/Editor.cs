using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using LevelEditorTest5.content.menus;
using LevelEditorTest5.content.objects;

namespace LevelEditorTest5.content
{
    class Editor
    {
        // menu's
        Selected selected;
        TileSetMenu tileSetMenu;
        MapMenu mapMenu;
        EditMenu layerMenu;
        FileMenu fileMenu;
        MovingBackground background;

        // tile objects
        List<TileMap> map = new List<TileMap>();
        TileMap tileset;

        KeyboardState press, release;

        public Editor()
        {
            // new selected tile menu
            selected = new Selected(GameUsage.selectedPos);

            // new tileset
            Rectangle tilesetRect = GameUsage.tilesetRect;
            tileset = new TileMap(new Vector2(tilesetRect.X, tilesetRect.Y), selected.tile, tilesetRect.Width, tilesetRect.Height);

            // new map
            Rectangle mapRect = GameUsage.mapRect;
            for (int i = 0; i < 3; i++)
            {
                map.Add(new TileMap(new Vector2(mapRect.X, mapRect.Y), selected.tile, mapRect.Width, mapRect.Height));
                map[i].CreateNewMap(640, 320, i != 0);
            }

            // new tileset menu
            tileSetMenu = new TileSetMenu(GameUsage.tilesetMenuPos, tileset);

            // new map menu
            mapMenu = new MapMenu(GameUsage.MapMenuPos, map);

            // new layer/edit menu
            layerMenu = new EditMenu(GameUsage.layerMenuPos, map);

            // new file menu
            fileMenu = new FileMenu(GameUsage.fileMenuPos, map);

            // background
            background = new MovingBackground(new Vector2(0,0), GameUsage.backTile1, 16, 16, 3, GameUsage.GameWidth, GameUsage.GameHeight);
        }

        public void Update(GameTime gameTime)
        {
            tileset.Update();
            if (!layerMenu.layerSwitch[layerMenu.layer].pressed) 
                map[layerMenu.layer].Update();

            tileSetMenu.Update(gameTime);
            mapMenu.Update(gameTime);
            layerMenu.Update();
            fileMenu.Update();

            background.Update(gameTime);

            press = Keyboard.GetState();
            if (press.IsKeyDown(Keys.B) && release.IsKeyUp(Keys.B))
                background.move = !background.move;
            release = press;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            background.Draw(spriteBatch);

            tileSetMenu.Draw(spriteBatch);
            selected.Draw(spriteBatch);
            mapMenu.Draw(spriteBatch);
            layerMenu.Draw(spriteBatch);
            fileMenu.Draw(spriteBatch);

            tileset.Draw(spriteBatch);

            for (int i = 0; i < map.Count; i++)
            {
                if (!layerMenu.layerSwitch[i].pressed) map[i].Draw(spriteBatch);
            }
        }
    }
}
