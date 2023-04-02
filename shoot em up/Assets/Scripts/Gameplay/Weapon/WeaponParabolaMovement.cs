using System;
using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon
{
    public class WeaponParabolaMovement : WeaponBase
    {
        public event Action OnParabolaFinished;

        private Vector3 _originalDirection;

        private Vector3 _direction;

        private float _parabolaTime;

        private float _negativeVelocity;
        
        private float _velocity;

        private float _timer;      

        void Update()
        {
            if (_timer > 0.0f) 
            {
                _timer -= Time.deltaTime;

                _direction.y -= (_negativeVelocity * Time.deltaTime) * _originalDirection.y;                
            }
            else 
            {
                OnParabolaFinished?.Invoke();
            }
        }

        void FixedUpdate()
        {
            if (_timer > 0.0f)
            {
                transform.position += _direction * _velocity * Time.deltaTime;                
            }            
        }

        void OnDestroy()
        {
            Identity.PickedUp.OnWeaponDropped -= EnableScript;
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            Identity.PickedUp.OnWeaponDropped += EnableScript;

            SetValues();

            enabled = false;
        }

        private void EnableScript() 
        {
            enabled = true;

            ResetValues();
        }

        private void SetValues() 
        {
            _originalDirection = new Vector3(1.0f, 3.0f, 0.0f); //The higher the value in Y the higher the parabola in Y will be

            _direction = _originalDirection;

            _parabolaTime = 1.5f;

            _velocity = _parabolaTime / 2.0f;

            _negativeVelocity = 1.0f / _velocity;

            _timer = _parabolaTime;
        }

        private void ResetValues() 
        {
            _direction = _originalDirection;

            _timer = _parabolaTime;
        }        
    }
}