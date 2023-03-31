using UnityEngine;
using System;

using ShootEmUp.Gameplay.Interfaces;
using Unity.VisualScripting;

namespace ShootEmUp.Gameplay.Weapon 
{
    public class WeaponPickedUp : MonoBehaviour, IPickable
    {
        private Transform _target;

        public event Action OnWeaponPickedUp;

        public event Action OnWeaponDropped;

        public Transform Target 
        {
            set 
            { 
                _target = value;

                if (_target == null) 
                {
                    OnWeaponDropped?.Invoke();
                }
                else 
                {
                    OnWeaponPickedUp?.Invoke();
                }
            }
        }

        public void PickedUp(GameObject objectThatPickedUp)
        {
            Target = objectThatPickedUp.transform;            
        }    

        void LateUpdate()
        {
            FollowTarget();

            //Levitate();
        }

        void FollowTarget() 
        {
            if (_target != null) 
            {
                transform.position = _target.transform.position;
            }
        }

        void Levitate() //Levitate in the air 
        {
            if (_target == null) 
            {
                transform.position += Vector3.up * Time.deltaTime;
            }
        }
    }
}