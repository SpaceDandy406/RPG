using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace RPG
{
    internal class Arrow
    {
        private Texture2D _texture;
        private Vector2 _currentPosition;
        private Point _targetPoint;
        private int _speed;
        private Unit _owner;
        private double _angle;
        private AI _ai;
        private double _damage;

        public byte WatingTime;
        public bool IsAchievedDestiny;
        public bool IsHitted;

        public Arrow(Texture2D texture, Vector2 position, IReadOnlyList<Unit> units, int i, AI ai, Random _r)
        {
            var r = _r;
            _owner = units[i];
            _ai = ai;
            _texture = texture;
            _currentPosition = position;
            IsAchievedDestiny = false;
            _speed = 7;
            WatingTime = 20;
            IsHitted = false;
            _damage = _owner.unitProps.unitStats.rangeAtackPower * 7;

            var distantion = _ai.Dist(_owner.Location, _owner.aim.Location);
            _targetPoint = CalculateTargetPoint(r, distantion);
        }

        private Point CalculateTargetPoint(Random r, int distantion)
        {
            var targetPoint = new Point();
            var maxRandomValue = distantion / _owner.unitProps.unitStats.shootAccuracy;

            targetPoint.X = _owner.aim.Location.Center.X + r.Next((int)-maxRandomValue, (int)maxRandomValue);
            targetPoint.Y = _owner.aim.Location.Center.Y + r.Next((int)-maxRandomValue, (int)maxRandomValue);

            return targetPoint;
        }

        private void Move()
        {
            //TODO: _angle можно считать один раз, нужно вынести в переменную класса.
            //dx, dy обернуть в Vector2. 
            _angle = Math.Atan((double)Math.Abs(_targetPoint.Y - _currentPosition.Y) / Math.Abs(_targetPoint.X - _currentPosition.X));

            var dx = Math.Cos(_angle) * _speed;
            if (_targetPoint.X < _currentPosition.X)
                dx = -dx;

            var dy = Math.Sin(_angle) * _speed;
            if (_targetPoint.Y < _currentPosition.Y)
                dy = -dy;

            _currentPosition.X += (int)Math.Round(dx);
            _currentPosition.Y += (int)Math.Round(dy);

        }

        public void Update()
        {
            var distanceToDestiny = _ai.Dist((int)_currentPosition.X, (int)_currentPosition.Y, _targetPoint.X, _targetPoint.Y);

            IsAchievedDestiny = (distanceToDestiny < _speed);

            if (!IsAchievedDestiny)
            {
                Move();
            }
            else
            {
                WatingTime--;

                if (IsHitted)
                    return;

                IsHitted = true;
                _currentPosition.X = _targetPoint.X;
                _currentPosition.Y = _targetPoint.Y;

                Unit targetUnit;
                if (!_ai.TryGetUnitByPoint(_currentPosition, out targetUnit))
                    return;

                targetUnit.Wound(_damage);
                targetUnit.hiter = _owner;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var drawAngle = Math.Atan((double)(_targetPoint.Y - _currentPosition.Y) / (_targetPoint.X - _currentPosition.X));
            var movedLeft = (_targetPoint.X < _currentPosition.X);
            var rotationVector = Vector2.Zero;
            var effect = SpriteEffects.None;

            if (IsHitted)
            {
                rotationVector = new Vector2(_texture.Width * 0.075f, _texture.Height * 0.075f);
                drawAngle = 1.5f;
            }
            else if (movedLeft)
            {
                effect = SpriteEffects.FlipHorizontally;
            }

            spriteBatch.Draw(_texture, _currentPosition, null, Color.White, (float)drawAngle,
                rotationVector, 0.15f, effect, 0);
        }
    }
}
