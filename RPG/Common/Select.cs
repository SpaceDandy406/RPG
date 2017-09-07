using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
    class Select
    {
        byte time;
        byte width;
        Rectangle[] borders;
        public bool visiable;
        Texture2D texture;

        public Select(byte _time, byte _width, Texture2D _texture)
        {
            time = _time;
            width = _width;
            borders = new Rectangle[4];
            texture = _texture;
            visiable = true;
        }

        public void SetBorders(Rectangle pos)
        {
            borders[0] = new Rectangle(pos.X - width, pos.Y - width, pos.Width + width, width);
            borders[1] = new Rectangle(pos.X + pos.Width, pos.Y - width, width, pos.Height + width);
            borders[2] = new Rectangle(pos.X, pos.Y + pos.Height, pos.Width + width, width);
            borders[3] = new Rectangle(pos.X - width, pos.Y, width, pos.Height + width);
            visiable = true;
        }


        public void Upgrade()
        {
            if (time > 0)
            {
                time--;
            }
            else
            {
                time = 20;
                visiable = !visiable;
            }
        }

       public void Draw(SpriteBatch spriteBatch)
        {
            if (visiable)
            {
                foreach (var border in borders)
                {
                    spriteBatch.Draw(texture, border, Color.White);
                }
            }
        }

    }
}
