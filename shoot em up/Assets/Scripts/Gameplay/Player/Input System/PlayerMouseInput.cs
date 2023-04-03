using System;
using UnityEngine;
using Unity.VisualScripting;

namespace ShootEmUp.Gameplay.Player.InputSystem
{
    public class PlayerMouseInput : MonoBehaviour
    {
        private MouseButton _mouseButton;

        public event Action OnMouseButtonPressed;

        public event Action OnMouseButtonHeldDown;

        private bool _isPressed;

        public MouseButton Button 
        {
            set 
            { 
                _mouseButton = value;
            }
        }

        void Start()
        {
            _isPressed = true;
        }

        void Update()
        {
            if (_isPressed) 
            {
                MouseInputButtonPress();
            }
            else 
            {
                MouseInputButtonHeldDown();
            }
        }

        private void MouseInputButtonPress()
        {
            if (Input.GetMouseButtonDown((int)_mouseButton))
            {
                OnMouseButtonPressed?.Invoke();
            }                        
        }

        private void MouseInputButtonHeldDown()
        {
            if (Input.GetMouseButton((int)_mouseButton))
            {
                OnMouseButtonHeldDown?.Invoke();
            }
        }
    }
}