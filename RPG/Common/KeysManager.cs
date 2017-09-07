using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace RPG.Common
{
    internal class KeysManager
    {
        public byte ButtonTimeLeft;
        public bool IsPressedKeys(out Keys[] keys)
        {
            keys = null;
            var pressedKeys = Keyboard.GetState().GetPressedKeys();

            if (!pressedKeys.Any() || ButtonTimeLeft > 0)
                return false;
            

            keys = pressedKeys;
            PressKey();
            
            return true;
        }

        public void Upgrade()
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
