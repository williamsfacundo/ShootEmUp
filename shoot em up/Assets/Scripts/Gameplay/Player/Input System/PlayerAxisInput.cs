using System;
using UnityEngine;

namespace ShootEmUp.Gameplay.Player.InputSystem 
{
    public class PlayerAxisInput : MonoBehaviour
    {
        public event Action OnAxisOneValueChanged;

        public event Action OnAxisTwoValueChanged;

        private string _axisOneName;

        private string _axisTwoName;

        private float _axisOneValue;

        private float _axisTwoValue;

        private float _lastAxisOneValue;

        private float _lastAxisTwoValue;

        public string AxisOneName 
        {
            set
            { 
                _axisOneName = value; 
            }
        }

        public string AxisTwoName 
        {
            set 
            { 
                _axisTwoName = value; 
            }
        }

        public float AxisOneValue
        {
            get
            { 
                return _axisOneValue; 
            }
        }

        public float AxisTwoValue 
        {
            get 
            { 
                return _axisTwoValue;
            }
        }

        void Start()
        {
            _axisOneValue = 0.0f;

            _axisTwoValue = 0.0f;

            _lastAxisOneValue = 0.0f;

            _lastAxisTwoValue = 0.0f;
        }

        void Update()
        {
            _axisOneValue = Input.GetAxisRaw(_axisOneName);

            _axisTwoValue = Input.GetAxisRaw(_axisTwoName);

            if (_lastAxisOneValue != _axisOneValue) 
            {
                OnAxisOneValueChanged?.Invoke();

                _lastAxisOneValue = _axisOneValue;
            }

            if (_lastAxisTwoValue != _axisTwoValue) 
            {
                OnAxisTwoValueChanged?.Invoke();

                _lastAxisTwoValue = _axisTwoValue;
            }
        }
    }
}