using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
    class AI
    {
        UnitStats unitStats;
        public List<Unit> units;
        Rectangle location;
        byte alience;
        public List<Rectangle> borders;
        Random r = new Random();
        Unit haveUnit;
        


        public AI(List<Unit> _units)
        {
            units = _units;

        }

        

        public byte GetState(Unit unit)
        {
            // 0 - do nothing
            // 11 - move up
            // 12 - move rigth
            // 13 - move down
            // 14 - move left
            // 21 - atack
            // 22 - defence
            // 31 - shoot



            haveUnit = unit;


            location = haveUnit.Location;
            unitStats = haveUnit.unitProps.unitStats;
            alience = haveUnit.unitProps.alience;


            Unit nearestEnemy = NearEnemy();

            //int nearestEnemyId = _aim;
            //nearestEnemy = units[_aim];
            if (nearestEnemy == null)
            {
                return 0;
            }

            if (Dist(location, nearestEnemy.Location) - (GetRadSumm(location, nearestEnemy.Location)) <= unitStats.atackRange)
            {
                return HitOrDef();
            }
            else if ((Dist(location, nearestEnemy.Location)) > 2 * unitStats.atackRange + (GetRadSumm(location, nearestEnemy.Location)) &&
                (Dist(location, nearestEnemy.Location) - (GetRadSumm(location, nearestEnemy.Location)) <= unitStats.rangeAtackRange)) 
            {
                return ShootOrRun(nearestEnemy); 
            }
            else
            {
                //if (_bigTrying > 70)
                //{
                //    return ByPassRecers(_unitStats, _location, _alience);
                //}

                //if (trying > 5000)
                //{
                //    return ByPass(_unitStats, _location, _alience);
                //}

                return MoveToEnemy(nearestEnemy);
            }
            
        }

        public bool CheckSpace(byte space)
        {
            if (space == 11)
            {
                foreach (var unit in units)
                {
                    if (location.Y <= borders[0].Y + borders[0].Height || 
                        (unit != haveUnit &&
                        location.Y - 1 == unit.Location.Y + unit.Location.Height &&
                        ((location.X >= unit.Location.X && location.X <= unit.Location.X + unit.Location.Width) || (location.X + location.Width >= unit.Location.X && location.X + location.Width <= unit.Location.X + unit.Location.Width))))
                    {
                        return false;
                    }
                }
                return true;
            }
            if (space == 12)
            {
                foreach (var unit in units)
                {
                    if (location.X + location.Width >= borders[1].X ||
                        (unit != haveUnit &&
                        location.X + location.Width + 1 == unit.Location.X &&
                        ((location.Y >= unit.Location.Y && location.Y <= unit.Location.Y + unit.Location.Height) || (location.Y + location.Height >= unit.Location.Y && location.Y + location.Height <= unit.Location.Y + unit.Location.Height))))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (space == 13)
            {
                foreach (var unit in units)
                {
                    if (location.Y + location.Height >= borders[2].Y ||
                        (unit != haveUnit &&
                        location.Y + location.Height + 1 == unit.Location.Y &&
                        ((location.X >= unit.Location.X && location.X <= unit.Location.X + unit.Location.Width) || (location.X + location.Width >= unit.Location.X && location.X + location.Width <= unit.Location.X + unit.Location.Width))))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (space == 14)
            {
                foreach (var unit in units)
                {
                    if (location.X <= borders[3].X + borders[3].Width ||
                        (unit != haveUnit &&
                        location.X - 1 == unit.Location.X + unit.Location.Width &&
                        ((location.Y >= unit.Location.Y && location.Y <= unit.Location.Y + unit.Location.Height) || (location.Y + location.Height >= unit.Location.Y && location.Y + location.Height <= unit.Location.Y + unit.Location.Height))))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }

        public int GetRadSumm(Rectangle pos1, Rectangle pos2)
        {
            int width1 = pos1.Width / 2;
            int width2 = pos2.Width / 2;
            int heigth1 = pos1.Height / 2;
            int heigth2 = pos2.Height / 2;

            double rad1 = Math.Sqrt((width1 * width1) + (heigth1 * heigth1));
            double rad2 = Math.Sqrt((width2 * width2) + (heigth2 * heigth2));

            return (int)(rad1 + rad2);
        }

        public bool CheckSpace(byte space, Rectangle location)
        {
            if (space == 11)
            {
                foreach (var unit in units)
                {
                    if (location.Y <= borders[0].Y + borders[0].Height ||
                        (unit != haveUnit &&
                        location.Y - 1 == unit.Location.Y + unit.Location.Height &&
                        ((location.X >= unit.Location.X && location.X <= unit.Location.X + unit.Location.Width) || (location.X + location.Width >= unit.Location.X && location.X + location.Width <= unit.Location.X + unit.Location.Width))))
                    {
                        return false;
                    }
                }
                return true;
            }
            if (space == 12)
            {
                foreach (var unit in units)
                {
                    if (location.X + location.Width >= borders[1].X ||
                        (unit != haveUnit &&
                        location.X + location.Width + 1 == unit.Location.X &&
                        ((location.Y >= unit.Location.Y && location.Y <= unit.Location.Y + unit.Location.Height) || (location.Y + location.Height >= unit.Location.Y && location.Y + location.Height <= unit.Location.Y + unit.Location.Height))))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (space == 13)
            {
                foreach (var unit in units)
                {
                    if (location.Y + location.Height >= borders[2].Y ||
                        (unit != haveUnit &&
                        location.Y + location.Height + 1 == unit.Location.Y &&
                        ((location.X >= unit.Location.X && location.X <= unit.Location.X + unit.Location.Width) || (location.X + location.Width >= unit.Location.X && location.X + location.Width <= unit.Location.X + unit.Location.Width))))
                    {
                        return false;
                    }
                }
                return true;
            }

            if (space == 14)
            {
                foreach (var unit in units)
                {
                    if (location.X <= borders[3].X + borders[3].Width ||
                        (unit != haveUnit &&
                        location.X - 1 == unit.Location.X + unit.Location.Width &&
                        ((location.Y >= unit.Location.Y && location.Y <= unit.Location.Y + unit.Location.Height) || (location.Y + location.Height >= unit.Location.Y && location.Y + location.Height <= unit.Location.Y + unit.Location.Height))))
                    {
                        return false;
                    }
                }
                return true;
            }
            return false;
        }





        public Unit NearEnemy()
        {
            int dist = 10000;
            Unit u = null;

            foreach (var unit in units)
            {
                if (unit != haveUnit && alience != unit.unitProps.alience)
                {
                    if (Dist(location, unit.Location) < dist)
                    {
                        dist = Dist(location, unit.Location);
                        u = unit;
                    }
                }
            }
            return u;
        }

        public int Dist(Rectangle pos1, Rectangle pos2)
        {

            int centre1X = pos1.Center.X;
            int centre1Y = pos1.Center.Y;
            int centre2X = pos2.Center.X;
            int centre2Y = pos2.Center.Y;

            double x = centre1X - centre2X;
            double y = centre1Y - centre2Y;

            return (int)Math.Sqrt((x * x) + (y * y));
        }

        public int Dist(int x1, int y1, int x2, int y2)
        {
            
            double x = x1 - x2;
            double y = y1 - y2;

            return (int)Math.Sqrt((x * x) + (y * y));
        }


        public Unit GetAim(Rectangle _location, byte _alience)
        {
            int dist = 10000;
            Unit un = null;
            foreach (var unit in units)
            {
                if (unit != haveUnit && alience != unit.unitProps.alience)
                {
                    if (Dist(location, unit.Location) < dist)
                    {
                        dist = Dist(location, unit.Location);
                        un = unit;
                    }
                }
            }
            return un;
        }

        public byte GetOtherAim(byte _alience)
        {
            byte id = 255;
            do
            {
                id = (byte)r.Next(units.Count);
            }
            while (units[id].unitProps.alience != _alience);

            return id;
        }

        public byte ByPass(UnitStats _unitStats, Rectangle _location, byte _alience)
        {
            location = _location;
            unitStats = _unitStats;
            alience = _alience;
            

            Unit nearestEnemy = NearEnemy();
            

           
            if (nearestEnemy != null)
            {
                if (CheckSpace(12))
                {
                    return 12;
                }
            }
            if (nearestEnemy != null)
            {
                if (CheckSpace(13))
                {
                    return 13;
                }
            }
            if (nearestEnemy != null)
            {
                if (CheckSpace(14))
                {
                    return 14;
                }
            }
            if (nearestEnemy != null)
            {
                if (CheckSpace(11))
                {
                    return 11;
                }
            }
            return 0;
        }


        public byte ByPassRecers(UnitStats _unitStats, Rectangle _location, byte _alience)
        {
            location = _location;
            unitStats = _unitStats;
            alience = _alience;


            Unit nearestEnemy = NearEnemy();


            if (nearestEnemy != null)
            {
                if (CheckSpace(11))
                {
                    return 11;
                }
            }
            if (nearestEnemy != null)
            {
                if (CheckSpace(14))
                {
                    return 14;
                }
            }
            if (nearestEnemy != null)
            {
                if (CheckSpace(13))
                {
                    return 13;
                }
            }
            if (nearestEnemy != null)
            {
                if (CheckSpace(12))
                {
                    return 12;
                }
            }
            return 0;
        }

        public Way GetWay(Rectangle _location, short trying)
        {
            Way way = new Way();
            Rectangle imagyarylocation = new Rectangle(_location.X, location.Y, location.Width, location.Height);

            way.MoveStates = new List<byte>();

            Unit nearestEnemy = NearEnemy();

            for (int i = 0; i < 200; i = i++)
            {
                if (Dist(imagyarylocation, nearestEnemy.Location) > 4)
                {
                    if (nearestEnemy.Location.X > imagyarylocation.X)
                    {
                        if (CheckSpace(12, imagyarylocation))
                        {
                            way.MoveStates.Add(12);
                        }
                    }
                    if (nearestEnemy.Location.Y > imagyarylocation.Y)
                    {
                        if (CheckSpace(13, imagyarylocation))
                        {
                            way.MoveStates.Add(13);
                        }
                    }
                    if (nearestEnemy.Location.X < imagyarylocation.X)
                    {
                        if (CheckSpace(14, imagyarylocation))
                        {
                            way.MoveStates.Add(14);
                        }
                    }
                    if (nearestEnemy.Location.Y < imagyarylocation.Y)
                    {
                        if (CheckSpace(11, imagyarylocation))
                        {
                            way.MoveStates.Add(11);
                        }
                    }
                }
                else return way;
            }
            return way;
        }

        public byte HitOrDef()
        {
            if (unitStats.health <= 50 && unitStats.health > 20)
            {
                if (r.Next(10) < 7)
                {
                    return 22;
                }
                else return 21;
            }
            else if (unitStats.health <= 20)
            {
                if (r.Next(10) < 9)
                {
                    return 22;
                }
                else return 21;
            }
            if (r.Next(10) < 4)
            {
                return 22;
            }
            else return 21;
        }

        public byte MoveToEnemy(Unit nearestEnemy)
        {
            if (nearestEnemy.Location.X > location.X && (nearestEnemy.Location.X - location.X) > Math.Abs(nearestEnemy.Location.Y - location.Y))
            {
                if (CheckSpace(12))
                {
                    return 12;
                }
            }
            if (nearestEnemy.Location.X < location.X && (location.X - nearestEnemy.Location.X ) < Math.Abs(nearestEnemy.Location.Y - location.Y))
            {
                if (CheckSpace(14))
                {
                    return 14;
                }
            }
            if (nearestEnemy.Location.Y > location.Y)
            {
                if (CheckSpace(13))
                {
                    return 13;
                }
            }
            if (nearestEnemy.Location.Y < location.Y)
            {
                if (CheckSpace(11))
                {
                    return 11;
                }
            }
            if (nearestEnemy.Location.X > location.X)
            {
                if (CheckSpace(12))
                {
                    return 12;
                }
            }
            if (nearestEnemy.Location.X < location.X)
            {
                if (CheckSpace(14))
                {
                    return 14;
                }
            }
            return 0;
        }

        public byte MoveByEnemy(Unit nearestEnemy)
        {
            if (nearestEnemy.Location.X > location.X && (nearestEnemy.Location.X - location.X) > Math.Abs(nearestEnemy.Location.Y - location.Y))
            {
                if (CheckSpace(14))
                {
                    return 14;
                }
            }
            if (nearestEnemy.Location.X < location.X && (location.X - nearestEnemy.Location.X ) < Math.Abs(nearestEnemy.Location.Y - location.Y))
            {
                if (CheckSpace(12))
                {
                    return 12;
                }
            }
            if (nearestEnemy.Location.Y > location.Y)
            {
                if (CheckSpace(11))
                {
                    return 11;
                }
            }
            if (nearestEnemy.Location.Y < location.Y)
            {
                if (CheckSpace(13))
                {
                    return 13;
                }
            }
            if (nearestEnemy.Location.X > location.X)
            {
                if (CheckSpace(14))
                {
                    return 14;
                }
            }
            return 0;
        }


        public byte ShootOrRun(Unit nearestEnemy)
        {
            if ((Dist(nearestEnemy.Location, location) <= unitStats.rangeAtackRange / 2) &&
                r.Next(1000) < 995)
            {
                return MoveByEnemy(nearestEnemy);
            }
            else if ((Dist(nearestEnemy.Location, location) <= unitStats.rangeAtackRange / 3) &&
                r.Next(1000) < 999)
            {
                return MoveByEnemy(nearestEnemy);
            }
            return 31;
        }

        public byte ToDestiny(Rectangle pos, int x, int y)
        {
            int distantionX = Math.Abs(pos.X - x);
            int distantionY = Math.Abs(pos.Y - y);

            if (distantionX > distantionY)
            {
                if (pos.X < x)
                {
                    return 12;
                }
                if (pos.X > x)
                {
                    return 14;
                }
            }

            if (distantionX <= distantionY)
            {
                if (pos.Y < y)
                {
                    return 13;
                }
                if (pos.Y > y)
                {
                    return 11;
                }
            }
            return 0;
        }

        public Unit GetUnitOnThis(Point point)
        {
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].IsCatch(point.X, point.Y))
                {
                    return units[i];
                }
            }
            return null;
        }
    }
}
