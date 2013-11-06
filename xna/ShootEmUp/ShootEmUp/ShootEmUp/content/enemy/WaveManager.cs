using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.resources;

namespace ShootEmUp.content.enemy
{
    class WaveManager
    {
        public static int maxWave = 5;

        public static List<Enemy> NextWave(int wave)
        {
            List<Enemy> enemys;
            enemys = new List<Enemy>();

            switch (wave)
            {
                case 1:
                    enemys.Add(new NormalEnemy(new Vector2(32*0, -32), 2 * 60, 90, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32*4, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*8, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*12, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*16, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*20, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*24, -32), 2 * 60, 90, 1, 0f));
                    
                    enemys.Add(new NormalEnemy(new Vector2(32*2, -32), 2 * 60, 90, 1, 800f));
                    enemys.Add(new NormalEnemy(new Vector2(32*6, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*14, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*18, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*22, -32), 2 * 60, 90, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32*0, -32), 1 * 60, 90, 2, 1200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*4, -32), 1 * 60, 90, 2, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*8, -32), 1 * 60, 90, 2, 0f));
                    enemys.Add(new ItemEnemy(new Vector2(32*12, -32), 1 * 60, 90, 0f, 1));
                    enemys.Add(new NormalEnemy(new Vector2(32*16, -32), 1 * 60, 90, 2, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*20, -32), 1 * 60, 90, 2, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*24, -32), 1 * 60, 90, 2, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32*2, -32), 3 * 60, 90, 2, 1000f));
                    enemys.Add(new NormalEnemy(new Vector2(32*6, -32), 3 * 60, 90, 2, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 3 * 60, 90, 2, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*14, -32), 3 * 60, 90, 2, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*18, -32), 3 * 60, 90, 2, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*22, -32), 3 * 60, 90, 2, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32*1, -32), 2 * 60, 90, 2, 1200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*3, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*5, -32), 2 * 60, 90, 2, 200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*7, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*9, -32), 2 * 60, 90, 2, 200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*11, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*13, -32), 2 * 60, 90, 2, 200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*15, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*17, -32), 2 * 60, 90, 2, 200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*19, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*21, -32), 2 * 60, 90, 2, 200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*23, -32), 2 * 60, 90, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32*6, -32), 3 * 60, 135, 1, 1000f));
                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 3 * 60, 135, 1, 200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*18, -32), 3 * 60, 45, 1, 200f));
                    enemys.Add(new NormalEnemy(new Vector2(32*14, -32), 3 * 60, 45, 1, 200f));

                    enemys.Add(new NormalEnemy(new Vector2(Globals.ScreenWidth / 2, -32), 3 * 60, 80, 1, 200f));
                    enemys.Add(new NormalEnemy(new Vector2(Globals.ScreenWidth / 2 - 32, -32), 3 * 60, 100, 1, 0f));
                    break;
                case 2:
                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 2 * 60, 110, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32*12, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*14, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32*6, -32), 2 * 60, 110, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32*8, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32*16, -32), 2 * 60, 110, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32*18, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*20, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32*6, -32), 2 * 60, 110, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32*8, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 2 * 60, 110, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32*12, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*14, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new ShootEnemy(new Vector2(-32, 80), 3 * 60, 0, 2, 500f, 1000f, 6 * 60));
                    enemys.Add(new ShootEnemy(new Vector2(-32, 16), 3 * 60, 0, 2, 2000f, 600f, 6 * 60));
                    break;
                case 3:
                    enemys.Add(new NormalEnemy(new Vector2(32 * 10, -32), 2 * 60, 90, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 12, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 14, -32), 2 * 60, 90, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32 * 8, -32), 2 * 60, 90, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 10, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new ItemEnemy(new Vector2(32 * 12, -32), 2 * 60, 90, 0f, 2));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 14, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 16, -32), 2 * 60, 90, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32 * 10, -32), 2 * 60, 90, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 12, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 14, -32), 2 * 60, 90, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32 * 2, -32), 3 * 60, 80, 1, 1800f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 4, -32), 3 * 60, 80, 1, 100f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 6, -32), 3 * 60, 80, 1, 100f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 8, -32), 3 * 60, 80, 1, 100f));

                    enemys.Add(new NormalEnemy(new Vector2(32 * 22, -32), 3 * 60, 100, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 20, -32), 3 * 60, 100, 1, 100f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 18, -32), 3 * 60, 100, 1, 100f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 16, -32), 3 * 60, 100, 1, 100f));

                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 2 * 60, 110, 1, 800f));
                    enemys.Add(new NormalEnemy(new Vector2(32*12, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*14, -32), 2 * 60, 70, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 2 * 60, 110, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32*12, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*14, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32 * 8, -32), 3 * 60, 90, 1, 1000f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 16, -32), 3 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 10, -32), 4 * 60, 90, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 14, -32), 4 * 60, 90, 1, 0f));

                    enemys.Add(new ShootEnemy(new Vector2(Globals.ScreenWidth, 40), 2 * 60, 180, 2, 500f, 1000f, 6 * 60));
                    enemys.Add(new ShootEnemy(new Vector2(-32, 80), 3 * 60, 0, 2, 500f, 1000f, 7 * 60));
                    enemys.Add(new ShootEnemy(new Vector2(Globals.ScreenWidth, 120), 1 * 60, 180, 2, 3000f, 600f, 6 * 60));
                    break;
                case 4:
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 12, -32), 2 * 60, 140, 1, 500f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 14, -32), 2 * 60, 140, 1, 100f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 16, -32), 2 * 60, 140, 1, 100f, 600f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 18, -32), 2 * 60, 140, 1, 100f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 20, -32), 2 * 60, 140, 1, 100f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 12, -32), 3 * 60, 160, 1, 600f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 14, -32), 3 * 60, 160, 1, 100f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 16, -32), 3 * 60, 160, 1, 100f, 600f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 18, -32), 3 * 60, 160, 1, 100f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 20, -32), 3 * 60, 160, 1, 100f));

                    enemys.Add(new MirrorEnemy(new Vector2(-32, 64), 2 * 60, 20, 1, 2200f));
                    enemys.Add(new MirrorEnemy(new Vector2(-32, 72), 2 * 60, 20, 1, 600f));
                    enemys.Add(new MirrorEnemy(new Vector2(-32, 80), 2 * 60, 20, 1, 600f));
                    enemys.Add(new MirrorEnemy(new Vector2(Globals.ScreenWidth, 64), 2 * 60, 160, 1, 800f));
                    enemys.Add(new MirrorEnemy(new Vector2(Globals.ScreenWidth, 72), 2 * 60, 160, 1, 600f));
                    enemys.Add(new MirrorEnemy(new Vector2(Globals.ScreenWidth, 80), 2 * 60, 160, 1, 600f));

                    enemys.Add(new MirrorEnemy(new Vector2(-32, 32), 2 * 60, 20, 1, 1300f));
                    enemys.Add(new MirrorEnemy(new Vector2(Globals.ScreenWidth, 32), 2 * 60, 160, 1, 0f));
                    enemys.Add(new MirrorEnemy(new Vector2(-32, 32), 2 * 60, 20, 2, 600f, 800f));
                    enemys.Add(new MirrorEnemy(new Vector2(Globals.ScreenWidth, 32), 2 * 60, 160, 2, 0f, 800f));

                    enemys.Add(new MirrorEnemy(new Vector2(-32, 80), 2 * 60, 0, 3, 1800f, 600f, 7*60));
                    break;
                case 5:
                    enemys.Add(new MirrorEnemy(new Vector2(-32, 80), 2 * 60, 40, 2, 1800f, 600f, 7 * 60));
                    enemys.Add(new MirrorEnemy(new Vector2(Globals.ScreenWidth, 80), 2 * 60, 140, 2, 1600f, 600f, 7 * 60));
                    enemys.Add(new MirrorEnemy(new Vector2(-32, 80), 2 * 60, 40, 2, 1400f, 600f, 7 * 60));
                    enemys.Add(new MirrorEnemy(new Vector2(Globals.ScreenWidth, 80), 2 * 60, 140, 2, 1200f, 600f, 7 * 60));

                    enemys.Add(new NormalEnemy(new Vector2(32*10, -32), 2 * 60, 110, 1, 500f));
                    enemys.Add(new NormalEnemy(new Vector2(32*12, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32*14, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new MirrorEnemy(new Vector2(32 * 4, -32), 2 * 60, 110, 1, 500f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 6, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 8, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new MirrorEnemy(new Vector2(32 * 16, -32), 2 * 60, 110, 1, 0f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 18, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new MirrorEnemy(new Vector2(32 * 20, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32 * 4, -32), 2 * 60, 110, 1, 1000f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 6, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 8, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new NormalEnemy(new Vector2(32 * 16, -32), 2 * 60, 110, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 18, -32), 2 * 60, 90, 1, 0f));
                    enemys.Add(new NormalEnemy(new Vector2(32 * 20, -32), 2 * 60, 70, 1, 0f));

                    enemys.Add(new MirrorEnemy(new Vector2(0, -32), 4 * 60, 20, 1, 2000f));
                    enemys.Add(new MirrorEnemy(new Vector2(32*24, -32), 4 * 60, 160, 1, 0f));
                    break;
            }
            return enemys;
        }
    }
}
