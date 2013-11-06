using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Fighter.content.player;
using Fighter.content.levels;
using Fighter.resources;
using Fighter.entity;

namespace Fighter.screens
{
    class GameScreen : Screen
    {
        List<Rectangle> platforms;
        List<Texture2D> field;

        Player player1, player2;

        public GameScreen()
        {
            platforms = new List<Rectangle>();
            field = new List<Texture2D>();
            base.Initialize();
        }

        public override void Initialize()
        {
            int width = Globals.tileWidth;
            int height = Globals.tileHeight;

            for (int y = 0; y <= Levels.level1Grid.GetUpperBound(0); y++)
                for (int x = 0; x <= Levels.level1Grid.GetUpperBound(1); x++)
                {
                    if (Levels.level1Grid[y, x] == 1)
                        platforms.Add(new Rectangle(x * width, y * height, width, 4));
                    else if (Levels.level1Grid[y, x] == 2)
                        player1 = new NormalPlayer(new Vector2(x * width, y * height), Color.Red);
                    else if (Levels.level1Grid[y, x] == 3)
                        player2 = new NormalPlayer(new Vector2(x * width, y * height), Color.Blue);
                }

            foreach (Rectangle pl in platforms)
                field.Add(Assets.CreateRectangle(pl));

            player1.SetKeys(Keys.A, Keys.W, Keys.D, Keys.E, Keys.S, Keys.Q);
            player2.SetKeys(Keys.Left, Keys.Up, Keys.Right, Keys.End, Keys.Down, Keys.RightShift);
        }

        public override void Update(GameTime gameTime)
        {
            player1.Update(gameTime);
            player2.Update(gameTime);

            foreach (Rectangle r in platforms)
            {
                player1.PlatformCollision(r);
                player2.PlatformCollision(r);
            }

            float pow = 0;
            if (player1.fist.Intersects(player2.bounds) && player1.attack != Player.Attack.None) // player1 attack
            {
                pow = (float)player1.attack / 10;
                player2.knockBack = (player1.power + player2.damage + pow) * player1.direction;
                player2.damage += player1.power / 100 + pow;
                Console.WriteLine(pow);
            }
            if (player2.fist.Intersects(player1.bounds) && player2.attack != Player.Attack.None) // player2 attack
            {
                pow = (float)player2.attack / 10;
                player1.knockBack = (player2.power + player1.damage + pow) * player2.direction;
                player1.damage += player2.power / 100 + pow;
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < MathHelper.Min(field.Count, platforms.Count); i++)
                spriteBatch.Draw(field[i], platforms[i], Color.White);

            player1.Draw(spriteBatch);
            player2.Draw(spriteBatch);

            spriteBatch.DrawString(spriteFont, "" + Math.Round(player1.damage * 100), Vector2.Zero, player1.color);
            spriteBatch.DrawString(spriteFont, "" + Math.Round(player2.damage * 100), new Vector2(Globals.ScreenWidth - 320, 0), player2.color);
        }

        public override void Clear()
        {
            platforms.Clear();
            field.Clear();

            player1 = null;
            player2 = null;
        }
    }
}
