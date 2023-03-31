using ShootEmUp.Gameplay.Identity;
using UnityEngine;

namespace ShootEmUp.Gameplay.Weapon 
{    
    public class WeaponDimensions : WeaponBase
    {
        [SerializeField] private Transform _front;

        [SerializeField] private Transform _back;

        [SerializeField] private Transform _spriteTransform;

        [SerializeField] private Vector3 _spriteOffset;        

        private Vector3 _originPosition;

        public Transform Front
        {
            get 
            { 
                return _front; 
            }
        }

        public Transform Back 
        {
            get 
            { 
                return _back;
            }
        }

        void OnDestroy()
        {
            Identity.PickedUp.OnWeaponPickedUp -= ApplyOffsetToSpritePosition;

            Identity.PickedUp.OnWeaponDropped -= SetSpritePositionToOrigin;
        }

        public void ApplyOffsetToSpritePosition() 
        {
            _spriteTransform.position += _spriteOffset;            
        }

        public void SetSpritePositionToOrigin() 
        {
            _spriteTransform.position = _originPosition;
        }

        public override void InitialSettings()
        {
            if (_front == null)
            {
                Debug.LogError("There is no front transform!");
            }

            if (_back == null)
            {
                Debug.LogError("There is no back transform!");
            }

            if (_spriteTransform == null)
            {
                Debug.LogError("There is no given sprite transform!");
            }

            Identity = GetComponent<WeaponIdentity>();

            Identity.PickedUp.OnWeaponPickedUp += ApplyOffsetToSpritePosition;

            Identity.PickedUp.OnWeaponDropped += SetSpritePositionToOrigin;

            _originPosition = _spriteTransform.position;
        }
    }
}