using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using ShootEmUp.content.enemy;
using ShootEmUp.content.bullet;
using ShootEmUp.content.player;

namespace ShootEmUp.resources
{
    abstract class Locals
    {
        public static List<Enemy> enemys;
        public static List<PowerUp> powerUps;
        public static List<Bullet> enemyBullets;

        public static int gameScore;
        public static int highScore;
        public static int gameLives;

        public static Keys playKey = Keys.Space;
    }
}
