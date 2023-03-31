using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;
using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon 
{
    [RequireComponent(typeof(WeaponIdentity))]
    public class WeaponLevitation : MonoBehaviour, IActionable
    {
        private WeaponIdentity _identity;

        private Vector3 _initialPosition;

        private Vector3 _destinyPosition;

        private Vector3 _auxVector;

        private const float _levitateDistance = 0.4f;

        private float _lerpResult;

        private float _lerpTime;

        private bool _goingUp;

        void Awake()
        {
            _identity = GetComponent<WeaponIdentity>();

            _identity.PickedUp.OnWeaponDropped += ResetLevitation;
        }

        void Start()
        {
            ResetLevitation();

            _auxVector = Vector3.zero;
        }

        void OnDestroy()
        {
            _identity.PickedUp.OnWeaponDropped -= ResetLevitation;
        }

        public void ResetLevitation()
        {
            _lerpTime = 0.0f;

            _goingUp = true;

            _initialPosition = transform.position;

            _destinyPosition = transform.position + (Vector3.up * _levitateDistance);
        }

        public void DoAction()
        {
            Levitate();
        }

        private void Levitate()
        {
            _lerpResult = Mathf.Lerp(_initialPosition.y, _destinyPosition.y, _lerpTime);

            _auxVector.y = _lerpResult;

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