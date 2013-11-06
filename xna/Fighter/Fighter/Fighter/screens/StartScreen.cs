using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Fighter.resources;
using Fighter.entity;

namespace Fighter.screens
{
    class StartScreen : Screen
    {
        public StartScreen()
        {
            
        }

        public override void Initialize()
        {
            Managers.screenManager.OpenNewScreen(ScreenManager.ScreenState.Active);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            
        }

        public override void Clear()
        {
            
        }
    }
}
