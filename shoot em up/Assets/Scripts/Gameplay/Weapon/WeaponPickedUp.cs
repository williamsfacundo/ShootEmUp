using UnityEngine;

using ShootEmUp.Gameplay.Interfaces;
using Unity.VisualScripting;

namespace ShootEmUp.Gameplay.Weapon 
{
    public class WeaponPickedUp : MonoBehaviour, IPickable
    {
        private Transform _target = null;

        public void PickedUp(GameObject objectThatPickedUp)
        {
            _target = objectThatPickedUp.transform;            
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