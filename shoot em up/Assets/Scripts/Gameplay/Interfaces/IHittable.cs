using UnityEngine;

namespace ShootEmUp.Gameplay.Interfaces
{
    public interface IHittable
    {
        public void ObjectHit(GameObject objectThatHit);
    }
}