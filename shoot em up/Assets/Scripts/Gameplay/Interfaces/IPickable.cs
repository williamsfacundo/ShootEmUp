using UnityEngine;

namespace ShootEmUp.Gameplay.Interfaces 
{
    public interface IPickable
    {
        public void PickedUp(GameObject objectThatPickedUp);

        public void DroppedDown();
    }
}