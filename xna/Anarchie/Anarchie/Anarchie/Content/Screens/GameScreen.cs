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
using Anarchie.Content.PlayerClass;
using Anarchie.Recources;
using Anarchie.Content.Level;

namespace Anarchie.Content.Screens
{
    class GameScreen : Screen
    {
        Player player;
        Grid grid;

        public GameScreen()
        {
            player = new Player(new Vector2(100,150));
            grid = new Grid();
            grid.createLevel(1);
            grid.createRoom(new Point (0,0));
        }

        public override void Update(GameTime gameTime)
        {
            player.Update(gameTime);
            ScreenUpdate();

            foreach (PuzzelDoor p in Local.puzzelDoor)
            {
                if (p.room == grid.currentRoom)
                    p.Update(gameTime);
            }
        }

        public void ScreenUpdate()
        {
            if (player.isOnDown)
            {
                player.position.Y = 0;
                grid.createRoom(new Point(grid.currentRoom.X, grid.currentRoom.Y + 1));
                grid.background.srcRect.Y += 176 + grid.background.interspace;
            }
            if (player.isOnUp)
            {
                player.position.Y = 176;
                grid.createRoom(new Point(grid.currentRoom.X, grid.currentRoom.Y - 1));
                grid.background.srcRect.Y -= 176 + grid.background.interspace;
            }

            if (player.isOnRight)
            {
                player.position.X = 0;
                grid.createRoom(new Point(grid.currentRoom.X + 1, grid.currentRoom.Y));
                grid.background.srcRect.X += 224 + grid.background.interspace;
            }

            if (player.isOnLeft)
            {
                player.position.X = 224;
                grid.createRoom(new Point(grid.currentRoom.X - 1, grid.currentRoom.Y));
                grid.background.srcRect.X -= 224 + grid.background.interspace;
            }

            foreach (Door door in Local.doors)
            {
                if (player.hitTest.Contains((int)door.center.X, (int)door.center.Y))
                {
                    grid.createLevel(door.destenation);
                    grid.createRoom(door.destRoom);
                    player.position = door.playerPosition;
                    grid.background.srcRect = new Rectangle(door.destRoom.X * (224 + grid.background.interspace), door.destRoom.Y * (176 + grid.background.interspace), 224, 176);
                }
            }

            foreach (Switch s in Local.switchList)
            {
                //hier gebeleven
                if (player.hitTest.Contains((int)s.center.X, (int)s.center.Y) && s.room == grid.currentRoom)
                {
                    s.Press();
                }
            }
           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            grid.background.Draw(spriteBatch);
            grid.Draw(spriteBatch);

            foreach (Switch s in Local.switchList)
            {
                if (s.room == grid.currentRoom)
                     s.Draw(spriteBatch);
            }

            foreach (PuzzelDoor p in Local.puzzelDoor)
            {
                if (p.room == grid.currentRoom)
                    p.Draw(spriteBatch);
            }

            player.Draw(spriteBatch);
        }

    }
}
