using UnityEngine;

namespace ShootEmUp.Gameplay.WorldGeneration 
{
    public abstract class ObjectsInstantiator : MonoBehaviour
    {
        [SerializeField] protected GameObject _objectPrefab;

        public abstract void InstantiateObjects();        
    }
}