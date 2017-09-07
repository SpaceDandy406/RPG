using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
    class UnitFactory
    {
        //public Unit CreateUnit(UnitProps unitProps, UnitStats unitStats)
        //{
        //    Unit unit = new Unit(unitProps, unitStats);

        //    return unit;
        //}

        public Unit CreateUnit(ArrayList objects)
        {
            UnitProps unitProps = new UnitProps();
            List<byte> commonByte = new List<byte>();
            myRectangle location = new myRectangle();
            Texture2D tex = null;
            List<UnitState> usts = new List<UnitState>();

            foreach (var obj in objects)
            {
                if (obj is List<UnitState>)
                {
                    usts = obj as List<UnitState>;
                    tex = usts[0].stateTexture;
                }

                if (obj is List<Texture2D>)
                {
                    unitProps.DistributeTexture(obj as List<Texture2D>);
                }

                if (obj is myRectangle)
                {
                    location = obj as myRectangle;   
                }

                if (obj is ForAsUnitStats)
                {
                    unitProps.ConvertUnitStats(obj as ForAsUnitStats);
                }

                if (obj is List<byte>)
                {
                    commonByte = obj as List<byte>;
                }
            }

            Unit unit = new Unit(unitProps, location.rect, tex);
            unit.DistributeCommons(commonByte);
            unit.DistributeStates(usts);

            return unit;
        }

        public bool IsFreePlace(List<Unit> units, int x, int y)
        {
            foreach (var unit in units)
            {
                if (unit.IsCatch(x, y) ||
                    unit.IsCatch(x + 50, y) || 
                    unit.IsCatch(x, y + 50) ||
                    unit.IsCatch(x + 50, y + 50) )
                {
                    return false;
                }
            }
            return true;
        }
        
        
    }
}
