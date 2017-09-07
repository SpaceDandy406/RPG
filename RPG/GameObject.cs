using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    abstract class GameObject
    {
        public Rectangle Location;
        public Texture2D Texture;

        public GameObject(Rectangle location, Texture2D texture)
        {
            Location = location;
            Texture = texture; 
        }

        virtual public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
        }

        abstract public void Update();
    }
}
