using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LevelEditorTest5.content.objects;

namespace LevelEditorTest5.content.menus
{
    class MapMenu
    {
        private MovingBackground background;

        public Button left;
        public Button right;
        public Button up;
        public Button down;

        private Texture2D menu;
        public Vector2 position;

        public List<TileMap> map;
        
        public MapMenu(Vector2 position, List<TileMap> map)
        {
            this.menu = GameUsage.MapMenu;
            this.position = position;
            this.map = map;

            right = new Button(GameButtons.rightTex, new Vector2(position.X + menu.Width - 32, position.Y + menu.Height - 16), GameButtons.srcRight);
            left = new Button(GameButtons.leftTex, new Vector2(position.X + 16, position.Y + menu.Height - 16), GameButtons.srcLeft);
            down = new Button(GameButtons.downTex, new Vector2(position.X + menu.Width - 16, position.Y + menu.Height - 32), GameButtons.srcDown);
            up = new Button(GameButtons.upTex, new Vector2(position.X + menu.Width - 16, position.Y + 16), GameButtons.srcUp);

            right.Click += new ClickEvent(ScrollRight);
            left.Click += new ClickEvent(ScrollLeft);
            down.Click += new ClickEvent(Scrolldown);
            up.Click += new ClickEvent(Scrollup);

            background = new MovingBackground(new Vector2(position.X + 16, position.Y + 16), GameUsage.backTile2, 16, 16, 7, 400, 176);
        }

        public void ScrollRight(Object sender)
        {
            for (int i = 0; i < map.Count; i++)
                map[i].Scroll("right");
        }
        public void ScrollLeft(Object sender)
        {
            for (int i = 0; i < map.Count; i++)
                map[i].Scroll("left");
        }
        public void Scrolldown(Object sender)
        {
            for (int i = 0; i < map.Count; i++)
                map[i].Scroll("down");
        }
        public void Scrollup(Object sender)
        {
            for (int i = 0; i < map.Count; i++)
                map[i].Scroll("up");
        }

        public void Update(GameTime gameTime)
        {
            right.Update();
            left.Update();
            down.Update();
            up.Update();

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
        }
    }
}