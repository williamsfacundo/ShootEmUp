using UnityEngine;

namespace ShootEmUp.Gameplay.Interfaces 
{
    public interface IPickable
    {
        public GameObject PickedUp(GameObject objectThatPickedUp);

        public void DroppedDown();
    }
}