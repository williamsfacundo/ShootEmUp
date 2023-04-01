using UnityEngine;

using ShootEmUp.Gameplay.Camera;

namespace ShootEmUp.Gameplay.WorldGeneration 
{
    public class CamerasInstantiator : ObjectsInstantiator
    {
        private GameObject _camera;

        private CameraFollowingObject _followingObject;         

        public override void InstantiateObjects()
        {
            if (_objectPrefab != null)
            {
                _followingObject = _objectPrefab.GetComponent<CameraFollowingObject>();
                
                if (_followingObject == null)
                {
                    Debug.LogError("The player prefab assigned doesn´t have PlayerIdentity scripts!");                    
                }
                else
                {
                    _camera = Instantiate(_objectPrefab);                                       
                }
            }
            else
            {
                Debug.LogError("There is no player prefab assigned!");
            }
        }

        public void SetCamerasTarget(Transform playerTransform)
        {
            _followingObject = _camera.GetComponent<CameraFollowingObject>();

            _followingObject.SetTarget(playerTransform);
        }
    }
}