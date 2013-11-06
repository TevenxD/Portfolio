using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using System.IO.IsolatedStorage;
using ShootEmUp.content.player;
using ShootEmUp.content.enemy;
using ShootEmUp.content.bullet;
using ShootEmUp.resources;

namespace ShootEmUp.content.screens
{
    class GameScreen : Screen
    {
        private Player player;
        private Vector2 startPlayerPos = new Vector2(32 * 12, 480);

        private HUD hud;
        private int wave = 1;

        private Texture2D background = Assets.background;
        private int backPos;

        public GameScreen()
        {
            player = new NormalPlayer(startPlayerPos, 4 * 60, 8 * 60);
            Locals.enemys = WaveManager.NextWave(wave);

            Locals.gameScore = 0;
            Locals.gameLives = 3;
            Locals.powerUps = new List<PowerUp>();

            hud = new HUD();
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);

            EnemyUpdate(gameTime);

            // powerUp update
            for (int i = 0; i < Locals.powerUps.Count; i++)
                Locals.powerUps[i].Update(gameTime);

            // background update
            if (backPos > 0)
                backPos--;
            else
                backPos = Globals.ScreenHeight;
        }

        private void EnemyUpdate(GameTime gameTime)
        {
            // enemys update
            for (int i = 0; i < Locals.enemys.Count; i++)
            {
                Enemy enemy = Locals.enemys[i];

                if (enemy.CountDown(gameTime) <= 0)
                {
                    CheckCollision(enemy);
                    enemy.Update(gameTime);
                }
                else
                    break;
            }

            // enemy bullets update
            foreach (Bullet bullet in Locals.enemyBullets)
            {
                bullet.Update(gameTime);

                if (!bullet.bounds.IsInsideScreen())
                {
                    Locals.enemyBullets.Remove(bullet);
                    break;
                }
            }

            // wave update
            if (Locals.enemys.Count == 0 && wave < WaveManager.maxWave)
            {
                wave++;
                Locals.enemys = WaveManager.NextWave(wave);
            }

            if (Locals.enemys.Count == 0 && wave >= WaveManager.maxWave)
            {
                Locals.gameScore += Locals.gameLives * 2000;
                SaveScore();

                ScreenManager.CreateScreen(new StartScreen());
            }
        }

        private void CheckCollision(Enemy enemy)
        {
            // enemy
            foreach (Bullet bullet in Locals.enemyBullets)
                if (bullet.bounds.Intersects(player.bounds))
                {
                    LoseLife();
                    Locals.enemyBullets.Remove(bullet);
                    break;
                }

            if (enemy.bounds.Intersects(player.bounds))
                LoseLife();

            // player
            foreach (Bullet bullet in player.bullets)
                if (bullet.bounds.Intersects(enemy.bounds))
                {
                    enemy.LoseHealth(1);
                    player.bullets.Remove(bullet);
                    break;
                }
        }

        private void LoseLife()
        {
            Locals.enemys = WaveManager.NextWave(wave);
            Locals.gameLives--;
            player.position = startPlayerPos;

            if (Locals.gameLives <= 0)
            {
                SaveScore();
                ScreenManager.CreateScreen(new StartScreen());
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, new Rectangle(0, backPos, Globals.ScreenWidth, Globals.ScreenHeight),Color.White);

            player.Draw(spriteBatch);

            foreach (PowerUp powerUp in Locals.powerUps)
                powerUp.Draw(spriteBatch);

            foreach (Enemy enemy in Locals.enemys)
            {
                if (enemy.waitTimer <= 0)
                    enemy.Draw(spriteBatch);
                else
                    break;
            }

            foreach (Bullet bullet in Locals.enemyBullets)
                bullet.Draw(spriteBatch);

            hud.Draw(spriteBatch, wave);
        }


        public void SaveScore()
        {
            if (Locals.gameScore > Locals.highScore)
            {
                FileStream stream = new FileStream("score.sav", FileMode.Create);
                BinaryWriter writer = new BinaryWriter(stream);

                writer.Write(Locals.gameScore);

                writer.Close();
            }
        }
    }
}
