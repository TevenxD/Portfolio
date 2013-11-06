using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace SlidePuzzle
{
    class Puzzle
    {
        float timer = 0;
        int seconds;
        int minutes;

        int currentPicture;
        Button leftButton, rightButton;
        Button playButton;

        SpriteFont font;
        Texture2D rectTex;
        Texture2D picture;
        Texture2D background;

        Rectangle rectTile;
        Vector2 puzzlePosition;

        List<List<int>> grid;
        List<List<Rectangle>> rectangles;
        List<Rectangle> srcRects;

        int size;
        int interspace;
        bool complete;

        MouseState mouseState;

        public Puzzle(SpriteFont spriteFont, Texture2D texture, Texture2D background)
        {
            this.font = spriteFont;
            this.picture = texture;
            this.background = background;

            puzzlePosition = new Vector2(232, 24);
            interspace = 0;

            NewPuzzle();

            playButton = new Button(Pictures.play, new Vector2(96, 231), new Rectangle(0, 0, 40, 16));
            leftButton = new Button(Pictures.button, new Vector2(32, 231), new Rectangle(0, 0, 16, 16));
            rightButton = new Button(Pictures.button, new Vector2(184, 231), new Rectangle(16, 0, 16, 16));

            playButton.Click += new ClickEvent(Play);
            leftButton.Click += new ClickEvent(Left);
            rightButton.Click += new ClickEvent(Right);
        }

        private void Play(Object sender)
        {
            picture = Pictures.pictures[currentPicture];
            NewPuzzle();

            seconds = 0;
            minutes = 0;
            timer = 0f;
        }

        private void Left(Object sender)
        {
            if (currentPicture > 0)
                currentPicture--;
            else
                currentPicture = Pictures.pictures.Count - 1;
        }
        private void Right(Object sender)
        {
            if (currentPicture < Pictures.pictures.Count - 1)
                currentPicture++;
            else
                currentPicture = 0;
        }

        private void NewPuzzle()
        {
            int[,] array = Arrays.GetArray();
            size = array.GetUpperBound(1) + 1;

            rectTile = new Rectangle(0, 0, picture.Width / size, picture.Height / size);
            rectTex = CreateRectangle(rectTile, Color.White);

            srcRects = new List<Rectangle>();
            rectangles = new List<List<Rectangle>>();
            grid = new List<List<int>>();

            for (int y = 0; y < size; y++)
            {
                grid.Add(new List<int>());
                rectangles.Add(new List<Rectangle>());

                for (int x = 0; x < size; x++)
                {
                    grid[y].Add(array[y, x]);

                    rectangles[y].Add(new Rectangle((int)puzzlePosition.X + x * (rectTile.Width + interspace), (int)puzzlePosition.Y + y * (rectTile.Height + interspace), rectTile.Width, rectTile.Height));
                    srcRects.Add(new Rectangle(x * rectTile.Width, y * rectTile.Height, rectTile.Width, rectTile.Height));
                }
            }

            complete = false;
        }

        public void Update(GameTime gameTime)
        {
            int check = 1;

            if (!complete)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
                seconds = (int)Math.Floor(timer);
                if (seconds >= 60)
                {
                    minutes++;
                    seconds = 0;
                    timer = 0f;
                }

                mouseState = Mouse.GetState();
            
                for (int y = 0; y < size; y++)
                    for (int x = 0; x < size; x++)
                    {
                        if (mouseState.LeftButton == ButtonState.Pressed && rectangles[y][x].Contains(mouseState.X, mouseState.Y) && grid[y][x] != 0)
                        {
                            if (x > 0 && grid[y][x-1] == size*size)
                                Swap(new Point(x-1,y), new Point(x,y));
                            if (x < size-1 && grid[y][x+1] == size*size)
                                Swap(new Point(x+1, y), new Point(x, y));

                            if (y > 0 && grid[y-1][x] == size*size)
                                Swap(new Point(x, y-1), new Point(x, y));
                            if (y < size-1 && grid[y+1][x] == size*size)
                                Swap(new Point(x, y+1), new Point(x, y));

                            
                        }
                        if (check == grid[y][x])
                            check++;
                    }
            }
            
            if (check == size*size+1 && !complete)
            {
                interspace = 0;
                complete = true;

                for (int y = 0; y < size; y++)
                    for (int x = 0; x < size; x++)
                        rectangles[y][x] = new Rectangle((int)puzzlePosition.X + x * rectTile.Width, (int)puzzlePosition.Y + y * rectTile.Height, rectTile.Width, rectTile.Height);
            }

            playButton.Update();
            leftButton.Update();
            rightButton.Update();
        }

        public void Swap(Point newP, Point oldP)
        {
            int swap = grid[newP.Y][newP.X];
            grid[newP.Y][newP.X] = grid[oldP.Y][oldP.X];
            grid[oldP.Y][oldP.X] = swap;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(background, Vector2.Zero, Color.White);
            spriteBatch.Draw(Pictures.pictures[currentPicture], new Vector2(16, 24), null, Color.White, 0f, Vector2.Zero, 0.5f, SpriteEffects.None, 1f);

            playButton.Draw(spriteBatch);
            leftButton.Draw(spriteBatch);
            rightButton.Draw(spriteBatch);

            spriteBatch.DrawString(font, "Time: " + minutes + ":" + seconds, new Vector2(34, 254), Color.Black);

            for (int y = 0; y < size; y++)
                for (int x = 0; x < size; x++)
                {
                    if (!(grid[y][x] == size * size && !complete))
                        spriteBatch.Draw(picture, rectangles[y][x], srcRects[grid[y][x] - 1], Color.White);
                }
        }

        public static Texture2D CreateRectangle(Rectangle rect, Color color)
        {
            Texture2D tex = new Texture2D(Main.graphicsDevice, rect.Width, rect.Height);
            Color[] data = new Color[rect.Width * rect.Height];

            for (int i = 0; i < data.Length; ++i)
                data[i] = color;

            tex.SetData(data);

            return tex;
        }
    }
}
