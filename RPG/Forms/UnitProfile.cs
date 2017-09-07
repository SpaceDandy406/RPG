using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
    class UnitProfile
    {
        public Texture2D textureBackground;
        public Rectangle position;

        public bool visioble;

        public View view;

        public UnitProfile(Texture2D texture)
        {
            textureBackground = texture;
            visioble = false;
        }

        public void GetView(Unit unit)
        {
            position = new Rectangle(unit.Location.X, unit.Location.Y, 0, 0);
            view.images = new List<CompoundTextureRectangle>();
            view.texts = new List<string>();
            view.vectors = new List<Vector2>();

            view.texts.Add("Level = " + unit.unitProps.stars.Count);
            view.texts.Add("Max Health = " + unit.unitProps.unitStats.maxHealth);
            view.texts.Add("Health = " + unit.unitProps.unitStats.health);
            view.texts.Add("Atack = " + unit.unitProps.unitStats.atack);
            view.texts.Add("Atack Time = " + unit.unitProps.unitStats.atackTime);
            view.texts.Add("Atack Range = " + unit.unitProps.unitStats.atackRange);
            view.texts.Add("Defence Time = " + unit.unitProps.unitStats.defenceTime);
            if (unit.unitProps.unitStats.rangeUnit)
            {
                view.texts.Add("Range Atack Power = " + unit.unitProps.unitStats.rangeAtackPower);
                view.texts.Add("Range Atack Time = " + unit.unitProps.unitStats.rangeAtackTime);
                view.texts.Add("Range Atack Range = " + unit.unitProps.unitStats.rangeAtackRange);
            }

            for (int i = 0; i < view.texts.Count; i++)
            {
                view.vectors.Add(new Vector2(unit.Location.X + 10, unit.Location.Y + 10 + i * 20));
            }

            visioble = true;

            SetSize();

        }

        private void SetSize()
        {
            position.Height = view.texts.Count * 20 + 30;
            position.Width = 300;
        }

        public void Update()
        {
            if (visioble)
            {
                
            }
            else
            {
                
            }
        }

        public void Show(SpriteBatch spriteBatch, SpriteFont spriteFont)
        {
            spriteBatch.Draw(textureBackground, position, Color.White);
            for (int i = 0; i < view.texts.Count; i++)
            {
                spriteBatch.DrawString(spriteFont, view.texts[i], view.vectors[i], Color.White);
            }
        }
    }
}
