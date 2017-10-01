using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Collections;
using RPG.Common;


namespace RPG
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        AI ai;
        List<Arrow> arrows;
        UnitFactory unitFactory;
        CommonStore store;
        List<GameObject> gameObjects;
        List<Unit> units;
        KeysManager keysManager = new KeysManager();
        WindowStateContext context;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            units = new List<Unit>();
            store.removeUnits = new List<byte>();
            store.kilingUnits = new List<byte>();
            graphics.PreferredBackBufferWidth = 1280;
            graphics.PreferredBackBufferHeight = 680;
            store.swordHitSnds = new SoundEffect[6];
            store.songs = new Song[3];
            store.arrowShootSnds = new SoundEffect[4];
            store.arrowHitSnds = new SoundEffect[5];
            store.borders = new List<Rectangle>();
            IsMouseVisible = true;
            unitFactory = new UnitFactory();
            store.objects = new ArrayList();
            arrows = new List<Arrow>();
            store.pauseCheck = true;

            context = new WindowStateContext(this);

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            base.Initialize();

            store.r = new Random();

            List<UnitState> uStates = new List<UnitState>();
            uStates.Add(new NormalState(Content.Load<Texture2D>("Circle0")));
            uStates.Add(new AtackState(Content.Load<Texture2D>("Circle1")));
            uStates.Add(new DefenceState(Content.Load<Texture2D>("Circle2")));
            uStates.Add(new ShootState(Content.Load<Texture2D>("CircleShoot")));

            List<UnitState> uStates2 = new List<UnitState>();
            uStates2.Add(new NormalState(Content.Load<Texture2D>("Rect0")));
            uStates2.Add(new AtackState(Content.Load<Texture2D>("Rect1")));
            uStates2.Add(new DefenceState(Content.Load<Texture2D>("Rect2")));
            uStates2.Add(new ShootState(Content.Load<Texture2D>("RectShoot")));


            List<Texture2D> tex = new List<Texture2D>();
            tex.Add(Content.Load<Texture2D>("GreenHealth"));
            tex.Add(Content.Load<Texture2D>("Star"));
            tex.Add(Content.Load<Texture2D>("DamageEffectTexture"));

            myRectangle myRect = new myRectangle();


            ForAsUnitStats uStats = new ForAsUnitStats();
            uStats.unitStats.atack = 20;
            uStats.unitStats.atackRange = 20;
            uStats.unitStats.atackTime = 50;
            uStats.unitStats.defenceTime = 60;
            uStats.unitStats.health = 300;
            uStats.unitStats.maxHealth = 300;
            uStats.unitStats.level = 0;
            uStats.unitStats.rangeUnit = false;
            uStats.unitStats.rangeAtackPower = 0;
            uStats.unitStats.rangeAtackRange = 0;
            uStats.unitStats.rangeAtackTime = 0;
            uStats.unitStats.speed = 1;
            uStats.unitStats.shootAccuracy = 15;

            List<byte> commonBytes = new List<byte>();

            commonBytes.Add(0);
            commonBytes.Add(0);
            commonBytes.Add(0);

            for (int i = 0; i < 8; i++)
            {
                //int x = 10;
                //int y = 10;
                //while (!(unitFactory.IsFreePlace(units, x, y)))
                //{
                //    x = store.r.Next(1200);
                //    y = store.r.Next(600);
                //}
                myRect.rect = new Rectangle(100, 40 + i * 80, 50, 50);

                store.objects.Add(uStates);
                store.objects.Add(tex);
                store.objects.Add(myRect);
                store.objects.Add(uStats);
                store.objects.Add(commonBytes);
                units.Add(unitFactory.CreateUnit(store.objects));

                store.objects.Clear();

            }

            uStats.unitStats.atack = 20;
            uStats.unitStats.atackRange = 20;
            uStats.unitStats.atackTime = 50;
            uStats.unitStats.defenceTime = 60;
            uStats.unitStats.health = 50;
            uStats.unitStats.maxHealth = 50;
            uStats.unitStats.level = 0;
            uStats.unitStats.rangeUnit = true;
            uStats.unitStats.rangeAtackPower = 1.1;
            uStats.unitStats.rangeAtackRange = 600;
            uStats.unitStats.rangeAtackTime = 700;
            uStats.unitStats.shootAccuracy = 15;

            for (int i = 0; i < 8; i++)
            {
                //int x = 10;
                //int y = 10;
                //while (!(unitFactory.IsFreePlace(units, x, y)))
                //{
                //    x = store.r.Next(1200);
                //    y = store.r.Next(600);
                //}
                myRect.rect = new Rectangle(30, 40 + i * 80, 50, 50);

                store.objects.Add(uStates);
                store.objects.Add(tex);
                store.objects.Add(myRect);
                store.objects.Add(uStats);
                store.objects.Add(commonBytes);
                units.Add(unitFactory.CreateUnit(store.objects));

                store.objects.Clear();

            }










            ForAsUnitStats uStats1 = new ForAsUnitStats();
            uStats1.unitStats.atack = 29;
            uStats1.unitStats.atackRange = 20;
            uStats1.unitStats.atackTime = 70;
            uStats1.unitStats.defenceTime = 40;
            uStats1.unitStats.health = 300;
            uStats1.unitStats.maxHealth = 300;
            uStats1.unitStats.level = 0;
            uStats1.unitStats.rangeUnit = false;
            uStats1.unitStats.rangeAtackPower = 0;
            uStats1.unitStats.rangeAtackRange = 0;
            uStats1.unitStats.rangeAtackTime = 0;
            uStats1.unitStats.speed = 1;
            uStats1.unitStats.shootAccuracy = 15;

            commonBytes.Clear();

            commonBytes.Add(1);
            commonBytes.Add(0);
            commonBytes.Add(0);

            for (int i = 0; i < 8; i++)
            {
                //int x = 10;
                //int y = 10;
                //while (!(unitFactory.IsFreePlace(units, x, y)))
                //{
                //    x = store.r.Next(1200);
                //    y = store.r.Next(600);
                //}
                myRect.rect = new Rectangle(1000, 40 + i * 80, 50, 50);

                store.objects.Add(uStates2);
                store.objects.Add(tex);
                store.objects.Add(myRect);
                store.objects.Add(uStats1);
                store.objects.Add(commonBytes);
                units.Add(unitFactory.CreateUnit(store.objects));

                store.objects.Clear();

            }

            uStats1.unitStats.atack = 30;
            uStats1.unitStats.atackRange = 20;
            uStats1.unitStats.atackTime = 70;
            uStats1.unitStats.defenceTime = 40;
            uStats1.unitStats.health = 50;
            uStats1.unitStats.maxHealth = 50;
            uStats1.unitStats.level = 0;
            uStats1.unitStats.rangeUnit = true;
            uStats1.unitStats.rangeAtackPower = 1;
            uStats1.unitStats.rangeAtackRange = 600;
            uStats1.unitStats.rangeAtackTime = 600;
            uStats1.unitStats.shootAccuracy = 15;

            for (int i = 0; i < 8; i++)
            {
                //int x = 10;
                //int y = 10;
                //while (!(unitFactory.IsFreePlace(units, x, y)))
                //{
                //    x = store.r.Next(1200);
                //    y = store.r.Next(600);
                //}
                myRect.rect = new Rectangle(1100, 40 + i * 80, 50, 50);

                store.objects.Add(uStates2);
                store.objects.Add(tex);
                store.objects.Add(myRect);
                store.objects.Add(uStats1);
                store.objects.Add(commonBytes);
                units.Add(unitFactory.CreateUnit(store.objects));

                store.objects.Clear();

            }




            List<string> stats = new List<string>();
            stats.Add("atack = ");
            stats.Add("atackRange = ");
            stats.Add("atackTime = ");
            stats.Add("defenceTime = ");
            stats.Add("maxHealth = ");
            stats.Add("rangeAtackPower = ");
            stats.Add("rangeAtackRange = ");
            stats.Add("rangeAtackTime = ");

            store.createUnitForm.CreateElements(stats);


            foreach (var unit in units)
            {
                unit.ai = ai;
            }


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            store.font = Content.Load<SpriteFont>("English Towne");

            store.borders.Add(new Rectangle(0, 0, graphics.PreferredBackBufferWidth, 7));
            store.borders.Add(new Rectangle(graphics.PreferredBackBufferWidth - 7, 0, 7, graphics.PreferredBackBufferHeight));
            store.borders.Add(new Rectangle(0, graphics.PreferredBackBufferHeight - 7, graphics.PreferredBackBufferWidth, 7));
            store.borders.Add(new Rectangle(0, 0, 7, graphics.PreferredBackBufferHeight));

            store.borderTexture = Content.Load<Texture2D>("Border");
            store.pauseTexture = Content.Load<Texture2D>("Pause");

            store.unitProfile = new UnitProfile(store.borderTexture);

            store.pause = new Rectangle(440, 240, 400, 200);

            ai = new AI(units);
            ai.borders = store.borders;

            store.swordHitSnds[0] = Content.Load<SoundEffect>("0259310");
            store.swordHitSnds[1] = Content.Load<SoundEffect>("025937");
            store.swordHitSnds[2] = Content.Load<SoundEffect>("025938");
            store.swordHitSnds[3] = Content.Load<SoundEffect>("025939");
            store.swordHitSnds[4] = Content.Load<SoundEffect>("SwordsClangs1");
            store.swordHitSnds[5] = Content.Load<SoundEffect>("SwordsClangs");

            //TODO            
            
            store.songs[0] = Content.Load<Song>("Ayreon - Day Seven_ Hope");
            store.songs[1] = Content.Load<Song>("Slash - Anastasia");

            store.arrowTexture = Content.Load<Texture2D>("Arrow");

            for (int i = 0; i < 5; i++)
            {
                store.arrowHitSnds[i] = Content.Load<SoundEffect>("ArrowHit" + i);
            }

            for (int i = 0; i < 4; i++)
            {
                store.arrowShootSnds[i] = Content.Load<SoundEffect>("ArrowShoot" + i);
            }


            store.createUnitForm = new CreateUnitForm(Content.Load<Texture2D>("BackGroundCreateUnitForm"), new Rectangle(100, 100, 380, 350));
            store.createUnitForm.selectedTextBox = Content.Load<Texture2D>("SelectedTextBox");
            store.createUnitForm.isRangeCheckBox.yesTexture = Content.Load<Texture2D>("IsRangeCheckBoxYes");
            store.createUnitForm.isRangeCheckBox.noTexture = Content.Load<Texture2D>("IsRangeCheckBoxNo");
            store.createUnitForm.CancelTexture = Content.Load<Texture2D>("CancelButtonCreateUnitForm");
            store.createUnitForm.CreateTexture = Content.Load<Texture2D>("CreateButtonCreateUnitForm");
            store.createUnitForm.textBoxTexture = Content.Load<Texture2D>("TextBox");



            store.select = new Select(20, 5, store.borderTexture);

            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            if (MediaPlayer.State == MediaState.Stopped)
            {
                //TODO вернуть коммент после того, как вернём музыку
                MediaPlayer.Play(store.songs[store.r.Next(store.songs.Length)]);
            }

            Keys[] keys;



            if ((Keyboard.GetState().IsKeyDown(Keys.Space)) && keysManager.ButtonTimeLeft == 0)
            {
                store.pauseCheck = !store.pauseCheck;
                keysManager.PressKey();
            }

            if (!store.pauseCheck)
            {
                UnitsAction();
            }


            if (Mouse.GetState().LeftButton == ButtonState.Pressed && keysManager.ButtonTimeLeft == 0)
            {
                keysManager.PressKey();
                bool isCatch = false;
                bool isUnit = false;
                foreach (var unit in units)
                {
                    if (unit.IsCatch(Mouse.GetState().X, Mouse.GetState().Y))
                    {
                        Unit un = unit;
                        store.select.SetBorders(unit.Location);
                        isCatch = true;
                        if (store.unitForShow == unit)
                        {
                            isUnit = true;
                        }
                        else
                        {
                            store.unitForShow = un;
                        }
                        break;
                    }
                    else
                    {
                        store.select.SetBorders(new Rectangle());
                    }
                }
                if (isUnit)
                {
                    store.unitProfile.visioble = !store.unitProfile.visioble;
                }
                else if (!isCatch)
                {
                    if (!store.unitProfile.visioble)
                    {
                        if (!store.createUnitForm.IsCatch(Mouse.GetState().X, Mouse.GetState().Y) && store.createUnitForm.visioble)
                        {
                            store.createUnitForm.visioble = !store.createUnitForm.visioble;
                        }
                        else if (!store.createUnitForm.visioble)
                        {
                            store.createUnitForm.visioble = !store.createUnitForm.visioble;
                        }
                    }
                    store.unitProfile.visioble = false;
                }

                if (store.createUnitForm.visioble)
                {
                    store.createUnitForm.Select(Mouse.GetState().X, Mouse.GetState().Y);
                }


            }

            if (Mouse.GetState().RightButton == ButtonState.Pressed && keysManager.ButtonTimeLeft == 0 && store.createUnitForm.visioble)
            {
                store.select.SetBorders(new Rectangle(Mouse.GetState().X - 25, Mouse.GetState().Y - 25, 50, 50));
            }

            if (keysManager.IsPressedKeys(out keys) && store.createUnitForm.visioble)
            {
                store.createUnitForm.Upgrade(keys.First());
            }


            keysManager.Upgrade();
            store.select.Upgrade();

            base.Update(gameTime);
        }


        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();



            foreach (var border in store.borders)
            {
                spriteBatch.Draw(store.borderTexture, border, Color.White);
            }

            foreach (var unit in units)
            {
                unit.Draw(spriteBatch);
            }




            foreach (var arrow in arrows)
            {
                arrow.Draw(spriteBatch);
            }

            store.select.Draw(spriteBatch);


            if (store.unitProfile.visioble)
            {
                store.unitProfile.GetView(store.unitForShow);
                spriteBatch.Draw(store.unitProfile.textureBackground, store.unitProfile.position, Color.White);
                for (int i = 0; i < store.unitProfile.view.texts.Count; i++)
                {
                    spriteBatch.DrawString(store.font, store.unitProfile.view.texts[i], store.unitProfile.view.vectors[i], Color.Green);
                }
            }



            if (store.pauseCheck)
            {
                spriteBatch.Draw(store.pauseTexture, store.pause, Color.White);
            }

            if (store.createUnitForm.visioble)
            {
                store.createUnitForm.Draw(spriteBatch, store.font);
            }


            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void RefreshUnitsId()
        {
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].unitProps.unitStats.health <= 0)
                {
                    if (units[i].hiter != null)
                    {
                        units[i].hiter.LevelUp();
                    }
                    units.Remove(units[i]);
                    i--;
                }
            }

            //for (int i = 0; i < units.Count; i++)
            //{
            //    units[i].unitProps.unitStats.id = (byte)i;
            //}
        }


        public void UnitsAction()
        {
            for (var i = 0; i < units.Count; i++)
            {
                try
                {
                    if (units[i].relaxTime == 0)
                    {
                        units[i].state = ai.GetState(units[i]);
                    }
                    units[i].Decide(ai);
                    units[i].Move();

                    if (units[i].state == 21)
                    {
                        store.swordHitSnds[store.r.Next(store.swordHitSnds.Length)].Play();
                        units[i].state = 0;
                        if (units[i].aim != null)
                        {
                            if (units[i].aim.state != 22)
                            {
                                units[i].aim.Wound(units[i].unitProps.unitStats.atack);
                                units[i].aim.hiter = units[i];
                            }
                        }
                    }
                    if (units[i].state == 31)
                    {
                        store.arrowShootSnds[store.r.Next(store.arrowShootSnds.Length)].Play();
                        units[i].state = 0;

                        var startPosition = new Vector2(units[i].Location.X + 10, units[i].Location.Y + 10);
                        var newArrow = new Arrow(store.arrowTexture, startPosition, units, i, ai, store.r);

                        arrows.Add(newArrow);
                    }
                }
                catch
                {

                }
            }


            //for (int i = 0; i < units.Count; i++)  
            //{
            //    if (units[i].unitProps.unitStats.health <= 0)
            //    {
            //        units.RemoveAt(units[i].aim);
            //    }



            for (int i = 0; i < arrows.Count; i++)
            {
                if (arrows[i].IsAchievedDestiny && !arrows[i].IsHitted)
                {
                    store.arrowHitSnds[store.r.Next(store.arrowHitSnds.Length)].Play();
                }

                arrows[i].Update();

                if (arrows[i].WatingTime == 0)
                {
                    arrows.RemoveAt(i);
                }
            }


            RefreshUnitsId();
        }


        Unit GetCachedUnit(int x, int y)
        {
            for (int i = 0; i < units.Count; i++)
            {
                if (units[i].IsCatch(x, y))
                {
                    return units[i];
                }
            }
            return null;
        }
    }
}
