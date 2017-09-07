using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
    class CreateUnitForm
    {
        public List<CompoundTextureRectangle> pictures;
        public List<TextBox> textBoxes;

        public List<string> statsText;
        public List<Vector2> vectors2;

        public Texture2D selectedTextBox;
        public Texture2D textBoxTexture;
        public CheckBox isRangeCheckBox;

        public bool visioble;

        public Texture2D background;
        public Rectangle position;

        public Rectangle Create;
        public Rectangle Cancel;
        public Texture2D CreateTexture;
        public Texture2D CancelTexture;

        public CreateUnitForm(Texture2D back, Rectangle pos)
        {
            pictures = new List<CompoundTextureRectangle>();
            textBoxes = new List<TextBox>();
            background = back;
            position = pos;
            isRangeCheckBox = new CheckBox();
            isRangeCheckBox.position = new Rectangle(pos.X + 100, pos.Y + 30, 20, 20);
            visioble = false;
            Create = new Rectangle(pos.X + pos.Width - 130, pos.Y + pos.Height - 60, 100, 40);
            Cancel = new Rectangle(pos.X + 30, pos.Y + pos.Height - 60, 100, 40);
            vectors2 = new List<Vector2>();
        }

        public void Select(int x, int y)
        {
            foreach (var textBox in textBoxes)
            {
                if (textBox.IsCatch(x, y))
                {
                    textBox.isSelected = true;
                    textBox.texture = selectedTextBox;
                }
                else
                {
                    textBox.isSelected = false;
                    textBox.texture = textBoxTexture;
                }
            }

            if (isRangeCheckBox.isCatch(x, y))
            {
                isRangeCheckBox.Change();
            }
        }

        public void WriteChar(char ch)
        {
            foreach (var textBox in textBoxes)
            {
                if (textBox.isSelected)
                {
                    textBox.AddChar(ch);
                    break;
                }
            }
        }

        public void DeleteChar()
        {
            foreach (var textBox in textBoxes)
            {
                if (textBox.isSelected)
                {
                    textBox.RemoveChar();
                    break;
                }
            }
        }


        public void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            spriteBatch.Draw(background, position, Color.White);
            foreach (var pict in pictures)
            {
                spriteBatch.Draw(pict.texture, pict.rectangle, Color.White);
            }
            foreach (var tBox in textBoxes)
            {
                tBox.Draw(spriteBatch, font);
            }

            for (int i = 0; i < statsText.Count; i++) 
            {
                spriteBatch.DrawString(font, statsText[i], vectors2[i], Color.White);
            }

            spriteBatch.Draw(CreateTexture, Create, Color.White);
            spriteBatch.Draw(CancelTexture, Cancel, Color.White);

            

        }

        public void EnterKey(Keys key)
        {

            //var keys = new Keys[3];
            //keys[0] = Keys.D0;
            //keys[1] = Keys.D1;
            //keys[2] = Keys.D2;

            //var keyState = new KeyboardState(keys);
            //Keys k;
            //var keys1 = keyState.GetPressedKeys();
            //if (keys1.Any())
            //    k = keys1.First();

            //if (Keyboard.GetState().IsKeyDown(Keys.D0))
            //{
            //    WriteChar(Convert.ToChar(48));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D1))
            //{
            //    WriteChar(Convert.ToChar(49));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D2))
            //{
            //    WriteChar(Convert.ToChar(50));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D3))
            //{
            //    WriteChar(Convert.ToChar(51));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D4))
            //{
            //    WriteChar(Convert.ToChar(52));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D5))
            //{
            //    WriteChar(Convert.ToChar(53));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D6))
            //{
            //    WriteChar(Convert.ToChar(54));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D7))
            //{
            //    WriteChar(Convert.ToChar(55));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D8))
            //{
            //    WriteChar(Convert.ToChar(56));
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.D9))
            //{
            //    WriteChar(Convert.ToChar(57));
            //}

            if (key >= Keys.D0 && key <= Keys.D9)
            {
                WriteChar(Convert.ToChar(key));
            }

            if (key == Keys.Back)
            {
                DeleteChar();
            }
        }

        public void CreateElements(List<string> stats)
        {
            statsText = stats;
            int k = 0;
            foreach (var stat in stats)
            {
                TextBox tb = new TextBox();
                tb.position = new Rectangle(position.X + 250, position.Y + 40 + k * 30, 100, 20);
                vectors2.Add(new Vector2(position.X + 30, position.Y + 42 + k * 30));
                tb.texture = textBoxTexture;
                textBoxes.Add(tb);
                k++;
            }
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

        public void Upgrade(Keys key)
        {
            EnterKey(key);
        }
    }
}
