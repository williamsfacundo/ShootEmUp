using Unity.VisualScripting;
using UnityEngine;
using System;

namespace ShootEmUp.Gameplay.Player.Actions.Combat
{
    public class PlayerMouseInput : MonoBehaviour
    {
        private MouseButton _mouseButton;

        public event Action OnMouseButtonPressed;

        public MouseButton Button 
        {
            set 
            { 
                _mouseButton = value; 
            }
        }

        void Update()
        {
            MouseInput();
        }

        private void MouseInput()
        {
            if (Input.GetMouseButtonDown((int)_mouseButton))
            {
                OnMouseButtonPressed?.Invoke();
            }                        
        }
    }
}