using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.IO.IsolatedStorage;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using LevelEditorTest5.content;
using LevelEditorTest5.content.objects;

namespace LevelEditorTest5
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Main MAIN;

        Editor editor;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            MAIN = this;
            this.IsMouseVisible = true;

            graphics.PreferredBackBufferWidth = GameUsage.GameWidth;
            graphics.PreferredBackBufferHeight = GameUsage.GameHeight;
        } 

        protected override void Initialize()
        {
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset1"), 16, 16, 21, 9, 1));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset2"), 16, 16, 19, 6, 1));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset3"), 16, 16, 17, 7, 1));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset4"), 16, 16, 11, 8, 1));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset5"), 16, 16, 23, 7, 1));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset6"), 16, 16, 36, 33, 1));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset7"), 16, 16, 45, 17, 1));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset8"), 16, 16, 21, 12, 1));

            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\zelda\\tileset1"), 16, 16, 24, 25, 1));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset9"), 16, 16, 105, 66, 0));
            GameUsage.tilesets.Add(new TileSet(Main.MAIN.Content.Load<Texture2D>("content\\tilesets\\tileset10"), 16, 16, 10, 7, 1));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            editor = new Editor();
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            editor.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            editor.Draw(spriteBatch);

            base.Draw(gameTime);
        }
    }
}
