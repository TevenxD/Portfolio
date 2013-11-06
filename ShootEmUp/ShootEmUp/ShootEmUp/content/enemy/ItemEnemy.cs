using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShootEmUp.resources;
using ShootEmUp.content.player;

namespace ShootEmUp.content.enemy
{
    class ItemEnemy : NormalEnemy
    {
        public ItemEnemy(Vector2 position, float speed, float direction, float waitTimer = 1000f, int dropItem = 1)
            : base(position, speed, direction, dropItem, waitTimer)
        {
            this.texture = Assets.itemEnemy;
            this.srcRect = new Rectangle(0, 0, 32, 32);

            if (dropItem < 1 || dropItem > 2)
                dropItem = 1;

            this.interval = 120f;
            this.totalFrames = 6;
            this.animation = dropItem;
        }

        protected override void Dead()
        {
            Locals.powerUps.Add(new PowerUp(position, 2 * 60, animation));

            base.Dead();
        }

        public override void LoseHealth(int damage)
        {
            Dead();
        }
    }
}
