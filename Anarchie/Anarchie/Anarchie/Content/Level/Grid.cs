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
using Anarchie.Recources;

namespace Anarchie.Content.Level
{
    class Grid
    {
        List<List<int[,]>> rooms;
        List<Door> doors;
        public  Point currentRoom;
        public Sprite background;

        public Grid()
        {
           

        }

        public void createLevel(int level)
        {
            createPuzzelObjects(level);
            doors = new List<Door>();
            rooms = new List<List<int[,]>>();

            switch (level)
            {
                //house
                case 0:
                    background = new Sprite(Assets.background3, Vector2.Zero);
                    background.srcRect = new Rectangle(0, 0, 224, 176);
                    background.interspace = 1;

                    rooms.Add (new List<int[,]>());
                    rooms[rooms.Count -1].Add( //0,0 eerst x en dan y
                        new int[,]
                        {
                            {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                            {1,1,1,1,1,1,0,0,1,1,1,1,1,1}
                        }
                    );

                break;


                //overworld
                case 1:

                background = new Sprite(Assets.background1, Vector2.Zero);
                background.srcRect = new Rectangle(0, 0, 224, 176);
                background.interspace = 1;

                //position x en y, breedte en hoogte, level waar de speler heen gaat, waar de deur staat,kamer waar de speler naar toe gaat 
                doors.Add(new Door(new Rectangle(6 * 16, 2 * 16, 16, 16), 2, new Point(1, 1), new Point(0, 0),new Vector2(96,128),0));
                doors.Add(new Door(new Rectangle(6 * 16, 7 * 16, 16, 16), 2, new Point(0, 0), new Point(0, 0), new Vector2(96,128),0));

                rooms.Add (new List<int[,]>());
                rooms[rooms.Count -1].Add( //0,0 eerst x en dan y
                    new int[,]
                    {
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {1,1,0,0,0,0,0,0,0,0,0,0,0,0},
                        {1,1,0,0,0,0,0,0,0,0,0,0,0,0},
                        {1,1,0,0,0,0,0,0,0,0,0,0,0,0},
                        {1,1,0,0,1,1,1,1,1,0,0,1,1,0},
                        {1,1,0,0,1,1,1,1,1,0,0,1,1,0},
                        {1,1,0,0,1,1,0,1,1,1,0,0,0,0},
                        {1,1,0,0,0,0,0,0,0,0,0,0,0,0},
                        {1,1,0,0,0,0,0,0,0,0,0,0,0,0},
                        {1,1,0,0,0,0,0,0,0,0,0,0,0,0}
                    }
                );

                rooms[rooms.Count -1].Add(//1,0
                    new int[,]
                    {
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {0,1,1,0,0,0,0,0,0,0,0,0,1,1},
                        {0,1,1,0,0,0,0,0,0,0,0,0,1,1},
                        {0,0,0,1,1,0,0,0,0,0,0,0,0,1},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                        {0,1,0,0,0,0,0,0,0,0,0,0,0,1},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,1}
                    }
                );

                rooms.Add(new List<int[,]>());
                rooms[rooms.Count - 1].Add(//0,1
                    new int[,]
                    {
                        {1,1,0,0,0,0,0,0,0,0,0,0,0,0},
                        {1,1,0,1,1,0,0,0,0,0,0,0,0,0},
                        {1,1,0,1,1,0,0,0,1,0,1,0,1,0},
                        {1,1,0,0,1,1,0,0,1,0,1,0,1,0},
                        {1,1,0,0,1,1,0,0,0,0,0,0,0,0},
                        {1,1,1,1,1,1,1,0,1,1,1,0,0,0},
                        {1,1,1,0,0,0,0,0,0,0,1,0,0,0},
                        {1,1,0,0,0,0,1,0,0,0,1,0,0,0},
                        {1,1,0,0,0,0,0,0,1,0,1,1,1,1},
                        {1,1,0,0,0,1,0,0,0,0,1,1,1,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1}
                    }
                );

                rooms[rooms.Count - 1].Add(//1,1
                    new int[,]
                    {
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {0,0,1,1,0,1,1,1,0,0,0,0,0,1},
                        {0,0,1,1,0,1,0,1,0,0,0,0,0,1},
                        {0,1,1,0,0,0,0,0,0,0,0,0,0,1},
                        {0,1,1,0,0,0,0,0,0,0,0,0,0,1},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {0,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1}
                    }
                );
                break;

                //dungeon
                case 2:

                //position x en y, breedte en hoogte, level waar de speler heen gaat, waar de deur staat,kamer waar de speler naar toe gaat 
                doors.Add(new Door(new Rectangle(6 * 16, 10 * 16, 16, 16), 1, new Point(0, 0), new Point(1, 1), new Vector2(112,64),16));

                rooms.Add (new List<int[,]>());
                background = new Sprite(Assets.background2, Vector2.Zero);
                background.srcRect = new Rectangle(0, 0, 224, 176);
                background.interspace = 1;

                rooms[rooms.Count -1].Add( //0,0 eerst x en dan y
                    new int[,]
                    {
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                        {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {1,0,0,1,0,0,0,0,1,0,0,1,0,1},
                        {1,0,0,0,0,0,0,0,0,0,0,0,0,0},
                        {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {1,0,0,1,0,0,0,0,1,0,0,1,0,1},
                        {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {1,0,0,0,0,0,0,0,0,0,0,0,0,1},
                        {1,1,1,1,1,1,0,1,1,1,1,1,1,1}
                    }
                );

                rooms[rooms.Count - 1].Add( //0,1 eerst x en dan y
                    new int[,]
                    {
                        {1,1,1,1,1,1,1,1,1,1,1,1,0,1},
                        {1,0,0,0,0,1,0,1,0,1,0,0,0,1},
                        {1,1,1,1,1,1,0,1,0,1,0,0,0,1},
                        {0,0,0,0,0,0,0,0,0,1,0,1,0,1},
                        {1,1,1,0,1,1,0,1,1,1,0,1,0,1},
                        {1,0,0,0,1,0,0,1,0,1,1,1,0,1},
                        {1,1,0,0,1,0,1,1,0,0,0,0,0,1},
                        {1,1,1,0,1,0,1,0,0,1,1,1,0,1},
                        {1,0,1,0,0,1,0,0,1,1,0,1,0,1},
                        {1,0,0,0,0,0,0,1,1,0,0,0,0,1},
                        {1,1,1,1,1,1,1,1,1,1,1,1,1,1}
                    }
                );
                break;
            }
        }

        //deze functie maakt de deur aan
        public void createDoor(Point room)
        {
            Local.doors =new List<Door>();
            foreach (Door door in doors)
            {
                if (door.level == room)
                {
                    Local.doors.Add(door);
                }
            }
            
        }

        //deze functie maakt de kamer aan
        public void createRoom(Point room)
        {
            currentRoom = room;
            createDoor(room);
            Local.collisions = new List<Rectangle>();
            int[,] array = rooms[room.Y][room.X];

            //voegt collision toe
            for (int y = 0; y < array.GetUpperBound(0) + 1; y++)
            {
                for (int x = 0; x < array.GetUpperBound(1) + 1; x++)
                {
                    switch (array[y,x])
                    {
                        case 1:
                            Local.collisions.Add(new Rectangle(x * 16,y * 16,16,16));
                        break;
                    }
                }
            }

            //puzzelDoor is de deur die we aan de switch hebben gekopppeld
            foreach (PuzzelDoor puzzel in Local.puzzelDoor)
            {
                if(puzzel.room == room)
                    Local.collisions.Add(puzzel.hitTest);
            }
        }

        public void createPuzzelObjects(int level)
        {
            Local.switchList = new List<Switch>();

            Local.puzzelDoor = new List<PuzzelDoor>();

            switch (level)
            {
                case 2:
                    Local.switchList.Add(new Switch(new Vector2 (1 * 16, 8 * 16), new Point(1, 0)));
                    Local.puzzelDoor.Add(new PuzzelDoor(new Vector2(12 * 16, 0), Local.switchList[0],new Point(1,0)));
                break;

            }

        }

        Texture2D rectTex = Assets.CreateRectangle(new Rectangle(0, 0, 16, 16), Color.Red * 0.5f);
        Texture2D doorTex = Assets.CreateRectangle(new Rectangle(0, 0, 16, 16), Color.White * 0.5f);

        public void Draw(SpriteBatch spriteBatch)
        {
            /*foreach (Door door in Local.doors)
            {
                spriteBatch.Draw(doorTex,new Vector2(door.rect.X,door.rect.Y),Color.White);
            }

            foreach (Rectangle rect in Local.collisions)
            {
                spriteBatch.Draw(rectTex, new Vector2(rect.X,rect.Y),Color.White);
            }*/
        }
    }
}
