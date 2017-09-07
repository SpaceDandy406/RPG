using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
    class Arrow
    {
        public Texture2D texture;
        public Rectangle position;
        public Point destiny;
        public byte speed;
        public Unit owner;
        public byte watingTime;
        public bool onPlace;
        public bool hited;
        AI ai;
        

        public Arrow(Texture2D _texture, Rectangle _position, ref List<Unit> units, int i, AI _ai, Random _r)
        {
            Random r = _r;
            owner = units[i];
            destiny = new Point();
            ai = _ai;

            int distantion = ai.Dist(owner.Location, owner.aim.Location);

            if (r.Next(2) == 0)
            {
                destiny.X = owner.aim.Location.Center.X + r.Next(distantion / owner.unitProps.unitStats.shootAccuracy);
            }
            else 
            {
                destiny.X = owner.aim.Location.Center.X - r.Next(distantion / owner.unitProps.unitStats.shootAccuracy);
            }
            if (r.Next(2) == 0)
            {
                destiny.Y = owner.aim.Location.Center.Y + r.Next(distantion / owner.unitProps.unitStats.shootAccuracy);
            }
            else
            {
                destiny.Y = owner.aim.Location.Center.Y - r.Next(distantion / owner.unitProps.unitStats.shootAccuracy);
            }
            texture = _texture;
            position = _position;
            onPlace = false;
            speed = 10;
            watingTime = 20;
            hited = false;
        }

        public Unit Victim()
        {
            return ai.GetUnitOnThis(new Point(position.X, position.Y));
        }

        public void Move()
        {
            int dist = ai.Dist(position.X, position.Y, destiny.X, destiny.Y);
            if ((ai.ToDestiny(position, destiny.X, destiny.Y) == 11)&& dist > speed)
            {
                position.Y -= speed;
            }
            else if ((ai.ToDestiny(position, destiny.X, destiny.Y) == 12) && dist > speed)
            {
                position.X += speed;
            }
            else if((ai.ToDestiny(position, destiny.X, destiny.Y) == 13) && dist > speed)
            {
                position.Y += speed;
            }
            else if((ai.ToDestiny(position, destiny.X, destiny.Y) == 14) && dist > speed)
            {
                position.X -= speed;
            }
            else
            {
                onPlace = true;
            }

        }

        public void Update()
        {
            if (onPlace)
            {
                if (!hited)
                {
                    hited = true;
                    if (Victim() != null)
                    {
                        Unit vic = Victim();
                        vic.Wound(owner.unitProps.unitStats.rangeAtackPower);
                        vic.hiter = owner;
                    }
                }
                watingTime--;
            }
            Move();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }
    }
}
