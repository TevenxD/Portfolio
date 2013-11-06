using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;
using System.IO.IsolatedStorage;
using Snake.resources;
using Snake.screens;

namespace Snake
{
    public class Main : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        ScreenManager screenManager;

        public Main()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            Globals.Content = this.Content;
            Globals.graphics = this.graphics;
            Globals.screenColor = Color.Black;

            Globals.ScreenWidth = 382+128;
            Globals.ScreenHeight = 382;
        }

        protected override void Initialize()
        {
            Globals.graphicsDevice = GraphicsDevice;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenManager = new ScreenManager(new StartScreen());

            if (File.Exists("score.sav"))
            {
                FileStream stream = new FileStream("score.sav", FileMode.Open);
                BinaryReader reader = new BinaryReader(stream);

                Locals.highScore = (int)reader.ReadInt16();

                reader.Close();
            }
        }

        protected override void UnloadContent()
        {
            
        }

        KeyboardState oldKeyboardState;
        int count = 1;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            screenManager.Update(gameTime);

            KeyboardState newKeyboardState = Keyboard.GetState();
            if (newKeyboardState.IsKeyDown(Keys.A) && oldKeyboardState.IsKeyUp(Keys.A))
            {
                TakeScreenShot("SnakeScreenShot" + count);
                count++;
            }
            oldKeyboardState = newKeyboardState;

            base.Update(gameTime);
        }

        public void TakeScreenShot(string prefix)
        {
            int w = GraphicsDevice.PresentationParameters.BackBufferWidth;
            int h = GraphicsDevice.PresentationParameters.BackBufferHeight;

            //force a frame to be drawn (otherwise back buffer is empty)
            Draw(new GameTime());

            //pull the picture from the buffer
            int[] backBuffer = new int[w * h];
            GraphicsDevice.GetBackBufferData(backBuffer);

            //copy into a texture
            Texture2D texture = new Texture2D(GraphicsDevice, w, h, false, GraphicsDevice.PresentationParameters.BackBufferFormat);
            texture.SetData(backBuffer);

            //save to disk
            Stream stream = File.OpenWrite(prefix + ".png");
            texture.SaveAsPng(stream, w, h);
            stream.Close();
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Globals.screenColor);

            spriteBatch.Begin();
            screenManager.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
