using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    class ShootState: UnitState
    {
        public ShootState(Texture2D texture)
        {
            base.stateTexture = texture;
        }
    }
}
