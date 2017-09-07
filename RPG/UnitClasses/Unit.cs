using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace RPG
{
     class Unit: GameObject
    {
        public UnitProps unitProps;
        public byte state;
        public ushort relaxTime;

        public AI ai;

        public Unit hiter;
        public Unit aim;

        public List<UnitState> unitStates;
        public List<UnitEffect> effects;

        Way way;


        public Unit(UnitProps _unitProps, Rectangle location, Texture2D texture): base (location, texture)
        {
            unitProps = _unitProps;
            unitStates = new List<UnitState>();
            //ai = _ai;

            ChangeTextureForNormal();

            way.MoveStates = new List<byte>();
            
            effects = new List<UnitEffect>();


            SetPosition(location);
        }

        public void DistributeStates(List<UnitState> _unitStates)
        {
            foreach (var state in _unitStates)
            {
                if (state is NormalState)
                {
                    unitStates.Add(state as NormalState);
                }

                if (state is AtackState)
                {
                    unitStates.Add(state as AtackState);
                }

                if (state is DefenceState)
                {
                    unitStates.Add(state as DefenceState);
                }

                if (state is ShootState)
                {
                    unitStates.Add(state as ShootState);
                }
            }
        }

        public void SetPosition(myRectangle pos)
        {
            Location = pos.rect;
            unitProps.ReInicHealthBar(Location);
        }
        public void SetPosition(Rectangle pos)
        {
            Location = pos;
            unitProps.ReInicHealthBar(Location);
        }

        //public Unit(UnitProps _unitProps)
        //{
        //    unitProps = _unitProps;

        //    ChangeTextureForNormal();


        //    way.MoveStates = new List<byte>();

        //    effects = new List<UnitEffect>();

        //}

        public void ChangeTextureForNormal()
        {
            foreach (var state in unitStates)
            {
                if (state is NormalState)
                {
                    Texture = state.stateTexture;
                    break;
                }
            }
        }

        public void ChangeTextureForAtack()
        {
            foreach (var state in unitStates)
            {
                if (state is AtackState)
                {
                    Texture = state.stateTexture;
                    break;
                }
            }
        }

        public void ChangeTextureForShoot()
        {
            foreach (var state in unitStates)
            {
                if (state is ShootState)
                {
                    Texture = state.stateTexture;
                    break;
                }
            }
        }

        public void ChangeTextureForDefence()
        {
            foreach (var state in unitStates)
            {
                if (state is DefenceState)
                {
                    Texture = state.stateTexture;
                    break;
                }
            }
        }

        public void Decide(AI ai)
        {
            if (relaxTime == 0)
            {
                aim = ai.GetAim(Location, unitProps.alience);
                ChangeTextureForNormal();
                //way = ai.GetWay(unitProps.position, trying);
                //state = ai.SetState(ref this);
                //if (state == 0)
                //{
                //    trying += 200;
                //    bigTrying++;
                //}
                //else if (trying > 0)
                //{
                //    trying--;
                //}
                //if (bigTrying >= 30)
                //{
                //    aim = ai.GetOtherAim(alience);
                //}
                //if(bigTrying > 50)
                //{
                //    bigTrying--;
                //}
                if (state == 21)
                {
                    ChangeTextureForAtack();
                    relaxTime += unitProps.unitStats.atackTime;
                }
                if (state == 22)
                {
                    ChangeTextureForDefence();
                    relaxTime += unitProps.unitStats.defenceTime;
                }
                if (state == 31)
                {
                    ChangeTextureForShoot();
                    relaxTime += unitProps.unitStats.rangeAtackTime;
                }
            }
            else
            relaxTime--;

            Tick();
        }


        public void Tick()
        {
            foreach (var effect in effects)
            {
                if (effect.timeLeft > 0)
                {
                    effect.timeLeft--;
                }
            }
            for (int i = 0; i < effects.Count; i++)
            {
                if (effects[i].timeLeft == 0)
                {
                    effects.Remove(effects[i]);
                    i--;
                }
            }
        }

        public void Move()
        {
            if (state == 11)
            {
                Location.Y -= unitProps.unitStats.speed;
                unitProps.healthBar.Y -= unitProps.unitStats.speed;
                for (int i = 0; i < unitProps.stars.Count; i++)
                {
                    Rectangle st = unitProps.stars[i];
                    st.Y -= unitProps.unitStats.speed;
                    unitProps.stars[i] = st;
                }
                foreach (var effect in effects)
                {
                    effect.position.Y -= unitProps.unitStats.speed;
                }
            }
            if (state == 12)
            {
                Location.X += unitProps.unitStats.speed;
                unitProps.healthBar.X += unitProps.unitStats.speed;
                for (int i = 0; i < unitProps.stars.Count; i++)
                {
                    Rectangle st = unitProps.stars[i];
                    st.X += unitProps.unitStats.speed;
                    unitProps.stars[i] = st;
                }
                foreach (var effect in effects)
                {
                    effect.position.X += unitProps.unitStats.speed;
                }
            }
            if (state == 13)
            {
                Location.Y += unitProps.unitStats.speed;
                unitProps.healthBar.Y += unitProps.unitStats.speed;
                for (int i = 0; i < unitProps.stars.Count; i++)
                {
                    Rectangle st = unitProps.stars[i];
                    st.Y += unitProps.unitStats.speed;
                    unitProps.stars[i] = st;
                }
                foreach (var effect in effects)
                {
                    effect.position.Y += unitProps.unitStats.speed;
                }
            }
            if (state == 14)
            {
                Location.X -= unitProps.unitStats.speed;
                unitProps.healthBar.X -= unitProps.unitStats.speed;
                for (int i = 0; i < unitProps.stars.Count; i++)
                {
                    Rectangle st = unitProps.stars[i];
                    st.X -= unitProps.unitStats.speed;
                    unitProps.stars[i] = st;
                }
                foreach (var effect in effects)
                {
                    effect.position.X -= unitProps.unitStats.speed;
                }
            }
        }

        public void LevelUp()
        {
            unitProps.stars.Add(new Rectangle(Location.X + unitProps.stars.Count * 14, Location.Y + Location.Height - 15, 12, 12));
            unitProps.unitStats.atack += 2;
            unitProps.unitStats.rangeAtackPower += 2;
            unitProps.unitStats.atackTime = (byte)(unitProps.unitStats.atackTime * 0.9);
            unitProps.unitStats.rangeAtackTime = (ushort)(unitProps.unitStats.rangeAtackTime * 0.9);
            unitProps.unitStats.shootAccuracy++;
        }

        public void DistributeCommons(List<byte> commons)
        {
            unitProps.alience = commons[0];
            state = commons[1];
            relaxTime = commons[2];
        }

        public bool IsCatch(int x, int y)
        {
            if (x >= Location.X &&
                x <= Location.X + Location.Width &&
                y >= Location.Y &&
                y <= Location.Y + Location.Height)
            {
                return true;
            }
            return false;
        }

        public void Wound(byte atack)
        {
            unitProps.unitStats.health -= atack;
            unitProps.healthBar.Width = (int)((double)unitProps.unitStats.health / (double)unitProps.unitStats.maxHealth * Location.Width);
            effects.Add(new UnitEffect("damage", unitProps.damageTexture, Location, 7));
        }

        override public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
            spriteBatch.Draw(unitProps.healthTexture, unitProps.healthBar, unitProps.healthBar, Color.White, 0, Vector2.Zero, 0, 0);
            //spriteBatch.Draw(unitProps.healthTexture, unitProps.healthBar, Color.White);
            DrawEffects(spriteBatch);
        }


        public void DrawEffects(SpriteBatch spriteBatch)
        {
            foreach (var pos in unitProps.stars)
            {
                spriteBatch.Draw(unitProps.star, pos, Color.White);
            }
            foreach (var effect in effects)
            {
                spriteBatch.Draw(effect.effectTexture, effect.position, Color.White);
            }
        }

        public override void Update()
        {
            state = ai.GetState(this);
        }
    }
}
