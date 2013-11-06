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
    class PuzzelDoor : Sprite
    {
        public Switch doorSwitch;
        public Point room;
        bool isVisible;

        public PuzzelDoor(Vector2 position, Switch newDoorSwitch, Point newRoom ) : base(Assets.switchDoor,position)
        {
            doorSwitch = newDoorSwitch;
            room = newRoom;
            hitTest = new Rectangle((int)position.X,(int)position.Y, 16, 16);
            isVisible = true;
        }

        public override void Update(GameTime gameTime)
        {
            isVisible = !doorSwitch.pressed;
            if (!isVisible && Local.collisions.Contains(hitTest))
                Local.collisions.Remove(hitTest);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            base.Draw(spriteBatch);
        }
    }
}
