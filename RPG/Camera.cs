using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using RPG.Common;
using System.Diagnostics;

namespace RPG
{
    internal class Camera
    {
        private float ViewportWidth;
        private float ViewportHeight;

        private KeysManager keysManager;

        protected float _zoom; 
        protected float _rotation;
        
        public Matrix _transform; 
        public Vector2 _pos; 


        public Camera(KeysManager _keysManagers)
        {
            ViewportWidth = 0;
            ViewportHeight = 0;
            keysManager = _keysManagers;
        }

        public float Zoom
        {
            get { return _zoom; }
            set { _zoom = value; if (_zoom < 0.1f) _zoom = 0.1f; } 
        }

        public float Rotation
        {
            get { return _rotation; }
            set { _rotation = value; }
        }


        public void Move(Vector2 amount)
        {
            _pos += amount;
        }



        public void MoveUp()
        {
            _pos.Y = _pos.Y - 5 / Zoom;
        }
        public void MoveDown()
        {
            _pos.Y = _pos.Y + 5 / Zoom;
        }
        public void MoveRight()
        {
            _pos.X = _pos.X + 5 / Zoom;
        }
        public void MoveLeft()
        {
            _pos.X = _pos.X - 5 / Zoom;
        }

        public Vector2 Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }

        public Matrix get_transformation(GraphicsDevice graphicsDevice)
        {
            _transform =       
              Matrix.CreateTranslation(new Vector3(-_pos.X, -_pos.Y, 0)) *
                                         Matrix.CreateRotationZ(Rotation) *
                                         Matrix.CreateScale(new Vector3(Zoom, Zoom, 1)) *
                                         Matrix.CreateTranslation(new Vector3(ViewportWidth * 1f, ViewportHeight * 1f, 0));
            return _transform;
        }
        

        public void Update()
        {
            Keys[] keys;
            Keys key = Keys.Enter;

            if (keysManager.IsPressingKeys(out keys))
            {
                key = keys[0];
            }
            if (key == Keys.Up)
            {
                MoveUp();
            }
            if (key == Keys.Down)
            {
                MoveDown();
            }
            if (key == Keys.Left)
            {
                MoveLeft();
            }
            if (key == Keys.Right)
            {
                MoveRight();
            }

            if (key == Keys.P)
            {
                Zoom = 1.03f * Zoom;
            }
            if (key == Keys.O)
            {
                Zoom = 0.97f * Zoom;
            }

        }
    }
}
