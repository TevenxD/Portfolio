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

namespace Anarchie.Content.Level
{
    class Door
    {
        public int destenation;
        public Rectangle rect;
        public Point level;
        public Point destRoom;
        public Vector2 center;
        public Vector2 playerPosition;

        public Door(Rectangle rect, int destenation, Point level, Point destRoom, Vector2 newPlayerPosition, int hitTestY)
        {
            this.rect = rect;
            this.destenation = destenation;
            this.level = level;
            this.destRoom = destRoom;
            this.playerPosition = newPlayerPosition;
            this.center = new Vector2(rect.X + rect.Width / 2, rect.Y + hitTestY); 
        }
    }
}
