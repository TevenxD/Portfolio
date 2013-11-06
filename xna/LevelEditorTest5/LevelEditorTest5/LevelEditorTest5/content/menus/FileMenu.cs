using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LevelEditorTest5.content.objects;
using System.IO;
using System.IO.IsolatedStorage;

namespace LevelEditorTest5.content.menus
{
    class FileMenu
    {
        Button save;
        Button load;
        Button newButton;

        Button nextLevel;
        Button prevLevel;

        Vector2 position;
        Texture2D menu;

        Rectangle levelRect;
        Texture2D levelDisplay;
        Vector2 levelPos;

        List<TileMap> map;

        public int level = 0;

        public FileMenu(Vector2 position, List<TileMap> map)
        {
            this.map = map;
            this.position = position;
            this.menu = GameUsage.FileMenu;

            levelDisplay = GameUsage.levelDisplay;
            levelPos = new Vector2(position.X + 35, position.Y + 8);
            levelRect = new Rectangle(0, 0, 42, 16);

            save = GameButtons.save;
            load = GameButtons.load;
            newButton = GameButtons.newButton;

            save.position = new Vector2(position.X + 32, position.Y + 32);
            load.position = new Vector2(position.X + 32, position.Y + 52);
            newButton.position = new Vector2(position.X + 32, position.Y + 72);

            save.Click += new ClickEvent(Save);
            load.Click += new ClickEvent(Load);
            newButton.Click += new ClickEvent(New);

            nextLevel = new Button(GameButtons.grayRightTex, new Vector2(position.X + 79, position.Y + 8), GameButtons.srcGrayRight);
            prevLevel = new Button(GameButtons.grayRightTex, new Vector2(position.X + 17, position.Y + 8), GameButtons.srcGrayLeft);

            nextLevel.Click += new ClickEvent(NextLevel);
            prevLevel.Click += new ClickEvent(Prevlevel);
        }

        public void Save(Object sender)
        {
            FileStream stream = new FileStream("level" + level + ".sav", FileMode.Create);
            BinaryWriter writer = new BinaryWriter(stream);

            for (int i = 0; i < map.Count; i++)
                for (int y = 0; y < map[i].tiles.Count; y++)
                    for (int x = 0; x < map[i].tiles[y].Count; x++)
                    {
                        writer.Write((float)map[i].tiles[y][x].srcRect.X);
                        writer.Write((float)map[i].tiles[y][x].srcRect.Y);
                        writer.Write((float)map[i].tiles[y][x].srcRect.Width);
                        writer.Write((float)map[i].tiles[y][x].srcRect.Height);
                        writer.Write((float)map[i].tiles[y][x].tileIndex);
                        writer.Write(map[i].tiles[y][x].empty);
                    }

            writer.Close();
        }
        public void Load(Object sender)
        {
            if (File.Exists("level" + level + ".sav"))
            {
                FileStream stream = new FileStream("level" + level + ".sav", FileMode.Open);
                BinaryReader reader = new BinaryReader(stream);

                for (int i = 0; i < map.Count; i++)
                    for (int y = 0; y < map[i].tiles.Count; y++)
                        for (int x = 0; x < map[i].tiles[y].Count; x++)
                        {
                            map[i].tiles[y][x].srcRect.X = (int)reader.ReadSingle();
                            map[i].tiles[y][x].srcRect.Y = (int)reader.ReadSingle();
                            map[i].tiles[y][x].srcRect.Width = (int)reader.ReadSingle();
                            map[i].tiles[y][x].srcRect.Height = (int)reader.ReadSingle();
                            map[i].tiles[y][x].tileIndex = (int)reader.ReadSingle();
                            map[i].tiles[y][x].empty = reader.ReadBoolean();
                        }
                reader.Close();
            }
        }
        public void New(Object sender)
        {
            for (int i = 0; i < map.Count; i++)
                map[i].CreateNewMap(map[i].lengthX * map[i].tileWidth, map[i].lengthY * map[i].tileHeight, i != 0);
        }

        public void NextLevel(Object sender)
        {
            level++;
            if (level > 8) level = 0;

            levelRect.Y = 16 * level;
        }
        public void Prevlevel(Object sender)
        {
            level--;
            if (level < 0) level = 8;

            levelRect.Y = 16 * level;
        }

        public void Update()
        {
            save.Update();
            load.Update();
            newButton.Update();

            nextLevel.Update();
            prevLevel.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(menu, position, Color.White);
            spriteBatch.Draw(levelDisplay, levelPos, levelRect, Color.White);
            spriteBatch.End();

            save.Draw(spriteBatch);
            load.Draw(spriteBatch);
            newButton.Draw(spriteBatch);

            nextLevel.Draw(spriteBatch);
            prevLevel.Draw(spriteBatch);
        }
    }
}
