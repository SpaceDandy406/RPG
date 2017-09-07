using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace RPG
{
    class CheckBox
    {
        public Texture2D yesTexture;
        public Texture2D noTexture;
        public bool state;
        public Rectangle position;

        public CheckBox()
        {
            state = false;
        } 

        public void Change()
        {
            state = !state;
        }

        public bool isCatch(int x, int y)
        {
            if (x >= position.X &&
                x <= position.X + position.Width &&
                y >= position.Y &&
                y <= position.Y + position.Height)
            {
                return true;
            }
            return false;
        }
    }
}
