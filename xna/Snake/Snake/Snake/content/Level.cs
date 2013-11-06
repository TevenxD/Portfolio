using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Snake.resources;

namespace Snake.content
{
    class Level
    {
        Texture2D texture;
        Texture2D itemTex;

        List<List<int>> grid;
        Rectangle field;
        int interspace;

        public Player snake;
        Point item;

        public Level(Rectangle field, Player snake, int interspace = 0)
        {
            this.snake = snake;
            this.field = field;
            this.interspace = interspace;

            this.texture = Assets.CreateRectangle(new Rectangle(0,0,16,16), Color.White);
            this.itemTex = Assets.CreateRectangle(new Rectangle(0, 0, 8, 8), Color.White);

            grid = new List<List<int>>();

            for (int x = 0; x < field.Width; x++)
            {
                grid.Add(new List<int>());

                for (int y = 0; y < field.Width; y++)
                    grid[x].Add(0);
            }

            item = RandomPoint;
        }

        public Point RandomPoint
        {
            get 
            {
                Point point = new Point();
                Random random = new Random();

                point.X = random.Next(0, field.Width);
                point.Y = random.Next(0, field.Height);

                return point;
            }
        }

        public void Update(GameTime gameTime)
        {
            snake.Update(gameTime);

            Point point = snake.positions[0];

            if (point.Y > grid.Count - 1)
                point.Y = 0;
            if (point.Y < 0)
                point.Y = grid.Count - 1;

            if (point.X > grid[point.Y].Count - 1)
                point.X = 0;
            if (point.X < 0)
                point.X = grid[point.Y].Count - 1;

            snake.positions[0] = point;

            if (point == item)
            {
                snake.positions.Add(new Point(snake.positions[snake.positions.Count - 1].X, snake.positions[snake.positions.Count - 1].Y));
                item = RandomPoint;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < grid.Count; x++)
                for (int y = 0; y < grid[x].Count; y++)
                {
                    Color color = Locals.fieldColor;

                    foreach (Point point in snake.positions)
                        if (point == new Point(x, y))
                        {
                            color = Locals.snakeColor;
                            if (snake.dead)
                                color = Locals.deadColor;
                            break;
                        }

                    spriteBatch.Draw(texture, new Vector2(field.X + x * (texture.Width + interspace), field.Y + y * (texture.Width + interspace)), color);
                }

            spriteBatch.Draw(itemTex, new Vector2(field.X + item.X * (texture.Width + interspace) + (texture.Width / 2 - itemTex.Width / 2), field.Y + item.Y * (texture.Width + interspace) + (texture.Height / 2 - itemTex.Height / 2)), Color.White);
        }
    }
}
