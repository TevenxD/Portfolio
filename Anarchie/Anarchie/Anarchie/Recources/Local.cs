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
using Anarchie.Content.Level;

namespace Anarchie.Recources
{
    class Local
    {
       public static List<Rectangle> collisions;
       public static List<Door> doors;
       public static List<PuzzelDoor> puzzelDoor;
       public static List<Switch> switchList;
    }
}
