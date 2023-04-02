using System;
using UnityEngine;

namespace ShootEmUp.Gameplay.Player.InputSystem 
{
    public class PlayerKeyboardInput : MonoBehaviour
    {
        private KeyCode _keyboardKey;

        public event Action OnKeyboardKeyPressed;

        public KeyCode KeyboardButton 
        {
            set 
            {
                _keyboardKey = value; 
            }
        }

        void Update()
        {
            KeyboardInput();
        }

        private void KeyboardInput() 
        {
            if (Input.GetKeyDown(_keyboardKey)) 
            {
                OnKeyboardKeyPressed?.Invoke();
            }
        }
    }
}