using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;


namespace RPG
{
    class UnitProps
    {
        //public Texture2D staticTexture;
        //public Texture2D dinamicTexture;
        //public Texture2D atcionTexture;
        public Texture2D healthTexture;
        public Texture2D star;
        public Texture2D damageTexture;

        public Rectangle healthBar;
        public byte alience;

        public List<Rectangle> stars;
        public UnitStats unitStats;


        public UnitProps()
        {
            stars = new List<Rectangle>();
            healthBar = new Rectangle();
        }

        public void ReInicHealthBar(Rectangle loc)
        {
            healthBar = new Rectangle(loc.X, loc.Y - 10, loc.Width, 5);
        }

        public void ConvertUnitStats(ForAsUnitStats uStats)
        {
            unitStats = uStats.unitStats;
        }


        public void DistributeTexture(List<Texture2D> commonTexture)
        {
            healthTexture = commonTexture[0];
            star = commonTexture[1];
            damageTexture = commonTexture[2];
        }



    }
}
