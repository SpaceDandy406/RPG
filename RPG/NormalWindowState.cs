using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class NormalWindowState : WindowState
    {
        public NormalWindowState(WindowStateContext _context) : base(_context)
        {

        }

        public override void MouseLeftButtonDown(int x, int y)
        {
            //Unit unit = Context.Game.GetCachedUnit(x, y);
            //if (unit != null)
            //{
            //    Context.Game.store.unitProfile.GetView(unit);
        }
    }
}
