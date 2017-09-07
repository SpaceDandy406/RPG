using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class DefenceState: UnitState
    {
        public DefenceState(Texture2D texture)
        {
            base.stateTexture = texture;
        }
    }
}
