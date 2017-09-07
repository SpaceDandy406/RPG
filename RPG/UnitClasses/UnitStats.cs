using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPG
{
    struct UnitStats
    {
        public short health;
        public short maxHealth;
        public byte atack;
        public byte atackTime;
        public ushort atackRange;
        public byte defenceTime;
        public byte level;
        public bool rangeUnit;
        public byte rangeAtackPower;
        public ushort rangeAtackRange;
        public ushort rangeAtackTime;
        public byte speed;
        public byte shootAccuracy;
    }
}
