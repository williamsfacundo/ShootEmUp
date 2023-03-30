using UnityEngine;

namespace ShootEmUp.Gameplay.Weapon 
{    
    public class WeaponDimensions : MonoBehaviour
    {
        [SerializeField] private Transform _front;

        [SerializeField] private Transform _back;

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
                Debug.Log("There is no front transform!");
            }

            if (_back == null) 
            {
                Debug.Log("There is no back transform!");
            }
        }
    }
}