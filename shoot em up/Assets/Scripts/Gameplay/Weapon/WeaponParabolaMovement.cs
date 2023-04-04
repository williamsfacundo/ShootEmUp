using System;
using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Physics;
using Unity.VisualScripting;

namespace ShootEmUp.Gameplay.Weapon
{
    public class WeaponParabolaMovement : WeaponBase
    {
        public event Action OnParabolaFinished;
        
        private const float ParabolaDuration = 1.0f;

        private Vector3 _initialPosition;

        private Vector3 _initialVelocity;

        private Vector3 _resultingPosition;

        private float _yAceleration;

        private float _currentTime;

        void Update()
        {           
            ParabolaTimeStatus();
        }

        void FixedUpdate()
        {
            Move();
        }

        void OnDestroy()
        {
            Identity.PickedUp.OnWeaponDropped -= EnableScript;
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            Identity.PickedUp.OnWeaponDropped += EnableScript;           

            _initialVelocity = new Vector3(1.0f, 4f, 0.0f);

            _yAceleration = -(_initialVelocity.y * 2.0f);

            _resultingPosition = Vector3.zero;

            enabled = false;
            
            ResetValues();            
        }
        
        private void ResetValues()
        {
            _initialPosition = transform.position;

            _currentTime = 0.0f;                                                
        }

        private void Move() 
        {
            _resultingPosition.x = transform.position.x + _initialVelocity.x * Time.deltaTime;

            _resultingPosition.y = UARM.CalculatePositionRelatedToTime(_initialPosition.y, _initialVelocity.y, _yAceleration, _currentTime);

            _resultingPosition.z = transform.position.z;

            transform.position = _resultingPosition;
        }       

        private void ParabolaTimeStatus() 
        {
            if (_currentTime >= ParabolaDuration) 
            {
                OnParabolaFinished?.Invoke();

                enabled = false;
            }
            else 
            {
                _currentTime += Time.deltaTime;

                if (_currentTime > ParabolaDuration) 
                {
                    _currentTime = ParabolaDuration;
                }
            }
        }

        private void EnableScript()
        {
            enabled = true;

            ResetValues();
        }
    }
}