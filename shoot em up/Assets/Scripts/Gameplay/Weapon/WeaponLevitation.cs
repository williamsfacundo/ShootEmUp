using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon 
{    
    public class WeaponLevitation : WeaponBase, IActionable
    {
        private Vector3 _initialPosition;

        private Vector3 _destinyPosition;

        private Vector3 _auxVector;

        private const float _levitateDistance = 0.4f;

        private float _lerpResult;

        private float _lerpTime;

        private bool _goingUp;        

        void OnDestroy()
        {
            Identity.ParabolaMovement.OnParabolaFinished -= ResetLevitation;
        }

        public void ResetLevitation()
        {
            _lerpTime = 0.0f;

            _goingUp = true;

            _initialPosition = transform.position;           

            _destinyPosition = transform.position + (Vector3.up * _levitateDistance);            

            _auxVector.y = 0.0f;
        }

        public void DoAction()
        {
            Levitate();
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<WeaponIdentity>();

            Identity.ParabolaMovement.OnParabolaFinished += ResetLevitation;

            ResetLevitation();

            _auxVector = Vector3.zero;
        }

        private void Levitate()
        {
            _lerpResult = Mathf.Lerp(_initialPosition.y, _destinyPosition.y, _lerpTime);

            _auxVector.y = _lerpResult - _initialPosition.y;

            transform.position = _initialPosition + _auxVector;

            if (_goingUp)
            {
                _lerpTime += Time.deltaTime;

                if (_lerpTime >= 1.0f)
                {
                    _lerpTime = 1.0f;

                    _goingUp = false;
                }

            }
            else
            {
                _lerpTime -= Time.deltaTime;

                if (_lerpTime <= 0.0f)
                {
                    _lerpTime = 0.0f;

                    _goingUp = true;
                }
            }
        }
    }
}