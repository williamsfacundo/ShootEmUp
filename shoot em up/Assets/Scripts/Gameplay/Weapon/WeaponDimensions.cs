using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Weapon 
{
    [RequireComponent(typeof(WeaponIdentity))]
    public class WeaponDimensions : MonoBehaviour
    {
        [SerializeField] private Transform _front;

        [SerializeField] private Transform _back;

        [SerializeField] private Transform _spriteTransform;

        [SerializeField] [Range(0.1f, 10.0f)] private float _spriteXOffset;

        private WeaponIdentity _identity;

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

        void Awake()
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

            _identity = GetComponent<WeaponIdentity>();
        }        

        void Start()
        {
            _identity.PickedUp.OnWeaponPickedUp += ApplyOffsetToSpritePosition;

            _identity.PickedUp.OnWeaponDropped += SetSpritePositionToOrigin;

            _originPosition = _spriteTransform.position;            
        }

        void OnDestroy()
        {
            _identity.PickedUp.OnWeaponPickedUp -= ApplyOffsetToSpritePosition;

            _identity.PickedUp.OnWeaponDropped -= SetSpritePositionToOrigin;
        }

        public void ApplyOffsetToSpritePosition() 
        {
            _spriteTransform.position += Vector3.right * _spriteXOffset;
        }

        public void SetSpritePositionToOrigin() 
        {
            _spriteTransform.position = _originPosition;
        }
    }
}