using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Fighter.screens
{
    class ScreenManager
    {
        public enum ScreenState
        {
            Start,
            Active,
            Pause,
        }

        private ScreenState screenState;
        private ScreenState previousState;
        private List<Screen> screenList;

        public ScreenManager()
        {
            this.screenState = ScreenState.Start;
        }

        public ScreenManager(ScreenState screenState)
        {
            this.screenState = screenState;
        }

        public void LoadContent()
        {
            // Add all screens
            screenList = new List<Screen>();
            screenList.Add(new StartScreen());
            screenList.Add(new GameScreen());
            screenList.Add(new PauseScreen());
            screenList[(int)screenState].Initialize();
        }

        public void OpenNewScreen(ScreenState newState, bool clear = true)
        {
            previousState = screenState;
            screenState = newState;

            if (clear)
            {
                screenList[(int)previousState].Clear();
                screenList[(int)screenState].Initialize();
            }
        }

        public void OpenPreviousScreen()
        {
            ScreenState oldState = screenState;
            screenState = previousState;
            previousState = oldState;
        }

        public void Update(GameTime gameTime)
        {
            screenList[(int)screenState].Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            screenList[(int)screenState].Draw(spriteBatch);

            if (screenState == ScreenState.Pause)
                screenList[(int)previousState].Draw(spriteBatch);
        }
    }
}
