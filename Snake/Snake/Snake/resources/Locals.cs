using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Snake.resources
{
    abstract class Locals
    {
        public static Keys pauseKey = Keys.Escape;

        public static Color fieldColor = Color.Green;
        public static Color snakeColor = Color.White;
        public static Color deadColor = Color.Red;

        public static int difficulty = 1;
        public static int gameScore;
        public static int highScore;
        public static int snakeLength;
    }
}
