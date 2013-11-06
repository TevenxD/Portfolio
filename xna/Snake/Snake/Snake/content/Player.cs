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
    class Player
    {
        public List<Point> positions;
        Point direction;

        KeyboardState keyState;
        Keys left, rigth, up, down, current;

        float interval;
        float timer = 0;

        public bool dead = false;

        public Player(Point start, int length, float interval)
        {
            left = Keys.Left;
            rigth = Keys.Right;
            up = Keys.Up;
            down = Keys.Down;

            direction = new Point(1, 0);
            this.interval = interval;

            positions = new List<Point>();
            for (int i = 0; i < length; i++)
                positions.Add(new Point(start.X - i, start.Y));
        }

        public void Update(GameTime gameTime)
        {
            timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            keyState = Keyboard.GetState();

            if (keyState.IsKeyDown(rigth))
                current = rigth;
            else if (keyState.IsKeyDown(left))
                current = left;
            else if (keyState.IsKeyDown(down))
                current = down;
            else if (keyState.IsKeyDown(up))
                current = up;

            if (timer > interval)
            {
                if (current == rigth && direction.X != -1)
                {
                    direction.X = 1;
                    direction.Y = 0;
                }
                else if (current == left && direction.X != 1)
                {
                    direction.X = -1;
                    direction.Y = 0;
                }
                else if (current == down && direction.Y != -1)
                {
                    direction.Y = 1;
                    direction.X = 0;
                }
                else if (current == up && direction.Y != 1)
                {
                    direction.Y = -1;
                    direction.X = 0;
                }

                Point newPoint = new Point(direction.X + positions[0].X, direction.Y + positions[0].Y);

                for (int i = 0; i < positions.Count; i++)
                {
                    Point oldPoint = positions[i];
                    positions[i] = newPoint;
                    newPoint = oldPoint;

                    if (positions[0] == positions[i] && i > 0)
                    {
                        dead = true;
                        Globals.screenColor = Locals.deadColor;
                    }
                }

                timer = 0f;
            }

            Locals.snakeLength = positions.Count;
        }
    }
}
