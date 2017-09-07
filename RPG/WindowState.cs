using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    abstract class WindowState
    {
        WindowStateContext context;
        public WindowStateContext Context { get { return context; } }
        public WindowState(WindowStateContext _context)
        {
            context = _context;
        }
        virtual public void MouseLeftButtonDown(int x, int y) { }

        virtual public void MouseRigthButtonDown(int x, int y) { }

        virtual public void MouseLeftButtonUp() { }

        virtual public void MouseRigthButtonUp() { }

        virtual public void MouseMove(int x, int y) { }
    }
}
