using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Anarchie.Content.PlayerClass;
using Anarchie.Recources;

namespace Anarchie.Content.Level
{
    class Switch : Sprite
    {
        public Point room;
        public bool pressed = false;

        public Switch(Vector2 position, Point newRoom): base(Assets.switches, position)
        {
            srcRect = new Rectangle(0, 0, 16, 16);
            room = newRoom;
        }

        public void Press()
        {
            animation = 2;
            pressed = true;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
