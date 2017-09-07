using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using System.Collections;

namespace RPG.Common
{
    struct CommonStore
    {
        public List<byte> removeUnits;
        public List<byte> kilingUnits;
        public SoundEffect[] swordHitSnds;
        public Song[] songs;
        public Texture2D pauseTexture;
        public Rectangle pause;
        public List<Rectangle> borders;
        public Texture2D borderTexture;
        public Select select;
        public bool pauseCheck;
        public SpriteFont font;
        public ArrayList objects;
        public UnitProfile unitProfile;
        public Unit unitForShow;
        public Random r;
        public Texture2D arrowTexture;
        public SoundEffect[] arrowShootSnds;
        public SoundEffect[] arrowHitSnds;
        public CreateUnitForm createUnitForm;
    }
}
