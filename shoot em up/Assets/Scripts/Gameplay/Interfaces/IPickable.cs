using UnityEngine;

namespace ShootEmUp.Gameplay.Interfaces 
{
    public interface IPickable
    {
        void PickedUp(GameObject objectThatPickedUp);            
    }
}