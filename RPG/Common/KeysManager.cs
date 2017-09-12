using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Linq;

namespace RPG.Common
{
    internal class KeysManager
    {
        private KeyboardState _previoseState;
        private KeyboardState _currentState;

        public byte ButtonTimeLeft;

        public void UpdateKeysState()
        {
            _previoseState = _currentState;
            _currentState = Keyboard.GetState();

            
        }

        public bool IsPressingKeys(out Keys[] keys)
        {
            keys = null;
            var pressedKeys = _currentState.GetPressedKeys();

            if (!pressedKeys.Any())
                return false;
            

            keys = pressedKeys;
            PressKey();
            
            return true;
        }

        public bool IsPressedKeys(out Keys[] keys)
        {
            keys = new Keys[0];

            var pressingKeys = _currentState.GetPressedKeys();
            var pressedKeys = _previoseState.GetPressedKeys();

            var isEqual = pressingKeys.SequenceEqual(pressedKeys);

            if (isEqual)
                keys = pressingKeys;

            return isEqual;
        }

        public void Update()
        {
            if (ButtonTimeLeft > 0)
            {
                ButtonTimeLeft--;
            }
        }

        public void PressKey()
        {
            ButtonTimeLeft = 10;
        }
    }
}
