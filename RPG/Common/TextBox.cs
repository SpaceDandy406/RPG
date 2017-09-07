using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
    class TextBox
    {
        public Texture2D texture;
        public List<char> text;
        public Rectangle position;
        public Vector2 vector;
        public bool isSelected;

        public TextBox()
        {
            text = new List<char>();
            isSelected = false;
        }

        public void AddChar(char ch)
        {
            text.Add(ch);
        }

        public void RemoveChar()
        {
            text.RemoveAt(text.Count - 1);
        }

        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            vector = new Vector2(position.X + 5, position.Y - 3);
            spriteBatch.Draw(texture, position, Color.White);
            string stat = "";
            foreach (var ch in text)
            {
                stat += ch;
            }
            spriteBatch.DrawString(font, stat, vector, Color.Black);
        }

        public bool IsCatch(int x, int y)
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
