using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using LevelEditorTest5.content.objects;

namespace LevelEditorTest5.content
{
    class GameUsage
    {
        public const int GameWidth = 576;
        public const int GameHeight = 320;

        public static Rectangle tilesetRect = new Rectangle(16, 16, 208, 80);
        public static Rectangle mapRect = new Rectangle(16, 128, 400, 176);
        public static Vector2 selectedPos = new Vector2(240, 16);
        public static Vector2 tilesetMenuPos = new Vector2(0, 0);
        public static Vector2 MapMenuPos = new Vector2(0, 112);
        public static Vector2 layerMenuPos = new Vector2(432, 0);
        public static Vector2 fileMenuPos = new Vector2(320, 0);
        

        // [layer][tileIndex]
        public static List<TileSet> tilesets = new List<TileSet>();

        public static Texture2D levelDisplay = Main.MAIN.Content.Load<Texture2D>("content\\buttons\\levelSelection");
        public static Texture2D selectedMenu = Main.MAIN.Content.Load<Texture2D>("content\\menus\\selectedMenu");
        public static Texture2D tileSetMenu = Main.MAIN.Content.Load<Texture2D>("content\\menus\\TilesetMenu");
        public static Texture2D MapMenu = Main.MAIN.Content.Load<Texture2D>("content\\menus\\MapMenu");
        public static Texture2D EditMenu = Main.MAIN.Content.Load<Texture2D>("content\\menus\\layerMenu");
        public static Texture2D FileMenu = Main.MAIN.Content.Load<Texture2D>("content\\menus\\fileMenu");

        public static Texture2D backTile1 = Main.MAIN.Content.Load<Texture2D>("content\\menus\\movingBackgroundTile");
        public static Texture2D backTile2 = Main.MAIN.Content.Load<Texture2D>("content\\menus\\movingBackgroundTile2");
    }
}
