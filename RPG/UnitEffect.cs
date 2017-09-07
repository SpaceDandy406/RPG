using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
    class UnitEffect
    {
        public string name;
        public Texture2D effectTexture;
        public Rectangle position;
        public ushort timeLeft;

        public UnitEffect(string _name, Texture2D _effectTexture, Rectangle _position, ushort _time)
        {
            name = _name;
            effectTexture = _effectTexture;
            position = _position;
            timeLeft = _time;
        }
    }
}
