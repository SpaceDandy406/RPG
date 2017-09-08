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
        public double angle;
        public AI ai;
        public double X;
        public double Y;
        public double dx;
        public double dy;


        public Arrow(Texture2D _texture, Rectangle _position, List<Unit> units, int i, AI _ai, Random _r)
        {
            Random r = _r;
            owner = units[i];
            ai = _ai;
            texture = _texture;
            position = _position;
            onPlace = false;
            speed = 10;
            watingTime = 20;
            hited = false;

            destiny = CalculateDestinyPoint(r, ai.Dist(owner.Location, owner.aim.Location));
        }

        private Point CalculateDestinyPoint(Random r, int distantion)
        {
            destiny = new Point();

            if (r.Next(2) == 0)
            {
                destiny.X = owner.aim.Location.Center.X + r.Next(distantion/owner.unitProps.unitStats.shootAccuracy);
            }
            else
            {
                destiny.X = owner.aim.Location.Center.X - r.Next(distantion/owner.unitProps.unitStats.shootAccuracy);
            }
            if (r.Next(2) == 0)
            {
                destiny.Y = owner.aim.Location.Center.Y + r.Next(distantion/owner.unitProps.unitStats.shootAccuracy);
            }
            else
            {
                destiny.Y = owner.aim.Location.Center.Y - r.Next(distantion/owner.unitProps.unitStats.shootAccuracy);
            }

            return destiny;
        }

        public Unit Victim()
        {
            return ai.GetUnitOnThis(new Point(position.X, position.Y));
        }

        private void Move()
        {
            angle = Math.Atan((double)Math.Abs(destiny.Y - position.Y) / Math.Abs(destiny.X - position.X));
            
            dx = Math.Cos(angle) * speed;
            if (destiny.X < position.X)
                dx = -dx;

            dy = Math.Sin(angle) * speed;
            if (destiny.Y < position.Y)
                dy = -dy;

            position.X += (int)Math.Round(dx);
            position.Y += (int)Math.Round(dy);

        }

        private bool IsPlace()
        {
            if (ai.Dist(position.X, position.Y, destiny.X, destiny.Y) < speed)
                return true;
            return false;
        }

        public void Update()
        {
            if (IsPlace())
            {
                if (!hited)
                {
                    position.X = destiny.X;
                    position.Y = destiny.Y;

                    hited = true;
                    Unit vic = Victim();
                    if (vic != null)
                    {
                        vic.Wound(owner.unitProps.unitStats.rangeAtackPower);
                        vic.hiter = owner;
                    }
                }
                watingTime--;
            }
            else
            {
                Move();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var angle1 = Math.Atan((double) (destiny.Y - position.Y) / (destiny.X - position.X));

            //if (hited)
            //{
            //    spriteBatch.Draw(texture,
            //        new Vector2(position.X, position.Y),
            //        null,
            //        Color.White,
            //        1.5f,
            //        Vector2.Zero,
            //        0.15f,
            //        SpriteEffects.None,
            //        0);
            //}
            //else
            //{
            if (destiny.X < position.X)
            {
                spriteBatch.Draw(texture,
                    new Vector2(position.X, position.Y),
                    null,
                    Color.White,
                    (float) angle1,
                    Vector2.Zero,
                    0.15f,
                    SpriteEffects.FlipHorizontally,
                    0);
            }
            else
            {
                spriteBatch.Draw(texture,
                    new Vector2(position.X, position.Y),
                    null,
                    Color.White,
                    (float)angle1,
                    Vector2.Zero,
                    0.15f,
                    SpriteEffects.None,
                    0);
            }
        }
    }
}
