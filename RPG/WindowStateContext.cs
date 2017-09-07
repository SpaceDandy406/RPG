using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    class WindowStateContext
    {
        Game1 game;

        public Game1 Game { get { return game; } set { game = value; } }


        public WindowStateContext(Game1 _game)
        {
            game = _game;
        }
    }
}
