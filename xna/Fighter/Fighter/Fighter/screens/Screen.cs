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
    class Screen
    {
        protected Sprite background;
        protected SpriteFont spriteFont;

        public Screen()
        {
            
        }

        public Screen(Texture2D backgroundTex)
        {
            this.background.texture = backgroundTex;
        }

        public virtual void Initialize()
        {
            spriteFont = Globals.Content.Load<SpriteFont>("SpriteFont1");
        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (background != null)
                background.Draw(spriteBatch);
        }

        public virtual void Clear()
        {
            this.background = null;
        }
    }
}
