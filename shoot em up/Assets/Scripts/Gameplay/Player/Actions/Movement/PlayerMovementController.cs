using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using TMPro;

namespace ShootEmUp.Gameplay.Player.Actions.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : PlayerBase
    {
        private Vector3 _aceleration;

        private Vector3 _negatedAceleration;

        private Vector3 _velocity;                    

        void Update()
        {
            MovementCalculations();         
        }

        void FixedUpdate()
        {
            Move();       
        }

        void OnDestroy()
        {
            Identity.MovementAxisInput.OnAxisOneValueChanged -= UpdateXAceleration;

            Identity.MovementAxisInput.OnAxisTwoValueChanged -= UpdateYAceleration;
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();

            Identity.MovementAxisInput.OnAxisOneValueChanged += UpdateXAceleration;

            Identity.MovementAxisInput.OnAxisTwoValueChanged += UpdateYAceleration;

            _aceleration = Vector3.zero;

            _negatedAceleration = Vector3.zero;

            _velocity = Vector3.zero;
        }        

        private void MovementCalculations() 
        {
            if (_aceleration.x != 0.0f && Mathf.Abs(_velocity.x) < Identity.Stats._maxVelocity) 
            {
                _velocity.x += _aceleration.x * Time.deltaTime;
            }

            if (_aceleration.y != 0.0f && Mathf.Abs(_velocity.y) < Identity.Stats._maxVelocity)
            {
                _velocity.y += _aceleration.y * Time.deltaTime;
            }

            if (_negatedAceleration.x != 0.0f && _velocity.x != 0.0f)
            {
                _velocity.x += _negatedAceleration.x * Time.deltaTime;

                if (_negatedAceleration.x > 0.0f) 
                {
                    if (_velocity.x > 0.0f) 
                    {
                        _velocity.x = 0.0f;
                    }
                }
                else 
                {
                    if (_velocity.x < 0.0f)
                    {
                        _velocity.x = 0.0f;
                    }
                }
            }

            if (_negatedAceleration.y != 0.0f && _velocity.y != 0.0f)
            {
                _velocity.y += _negatedAceleration.y * Time.deltaTime;

                if (_negatedAceleration.y > 0.0f)
                {
                    if (_velocity.y > 0.0f)
                    {
                        _velocity.y = 0.0f;
                    }
                }
                else
                {
                    if (_velocity.y < 0.0f)
                    {
                        _velocity.y = 0.0f;
                    }
                }
            }
        }

        private void Move()
        {
            transform.position += _velocity * Time.deltaTime;                           
        }

        private void UpdateXAceleration() 
        {
            _aceleration.x = Identity.Stats._movementAceleration * Identity.MovementAxisInput.AxisOneValue;

            if (Identity.MovementAxisInput.AxisOneValue == 0.0f) 
            {
                if (_velocity.x > 0.0f) 
                {
                    _negatedAceleration.x = -Identity.Stats._maxVelocity * 2.0f;
                }
                else 
                {
                    _negatedAceleration.x = Identity.Stats._maxVelocity * 2.0f;
                }                
            }
            else 
            {
                _negatedAceleration.x = 0.0f;
            }
        }

        private void UpdateYAceleration() 
        {
            _aceleration.y = Identity.Stats._movementAceleration * Identity.MovementAxisInput.AxisTwoValue;

            if (Identity.MovementAxisInput.AxisTwoValue == 0.0f)
            {
                if (_velocity.y > 0.0f)
                {
                    _negatedAceleration.y = -Identity.Stats._maxVelocity * 2.0f;   
                }
                else
                {
                    _negatedAceleration.y = Identity.Stats._maxVelocity * 2.0f;
                }
            }
            else
            {
                _negatedAceleration.y = 0.0f;
            }
        }
    }
}