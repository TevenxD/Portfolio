using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Wiskunde.resources;

namespace Wiskunde.content.opdrachten
{
    class Opdracht
    {
        protected Color backColor;
        protected Color nameColor;
        public Vector2 namePosition;
        public string name;
        protected SpriteFont font;

        protected Texture2D background;

        public Opdracht()
        {
            font = Assets.spriteFont1;
        }

        public virtual void Init()
        {

        }

        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (background != null)
                spriteBatch.Draw(background, Vector2.Zero, backColor);

            spriteBatch.DrawString(font, name, namePosition, nameColor);
        }
    }
}
