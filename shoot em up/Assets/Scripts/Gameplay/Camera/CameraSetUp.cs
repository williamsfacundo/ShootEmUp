using UnityEngine;

namespace ShootEmUp.Gameplay.Camera
{
    public class CameraSetUp : MonoBehaviour
    {
        [SerializeField] [Range(1f, 10f)] private float _cameraSize;

        private UnityEngine.Camera[] _cameras;

        private Vector2 _viewPosition;
        private Vector2 _viewSize;

        void Start()
        {
            _cameras = UnityEngine.Camera.allCameras;

            if (_cameras.Length < 1) 
            {
                Debug.LogError("No camera on scene!");
            }
            else if (_cameras.Length == 1) 
            {
                _cameras[0].enabled = true;

                _viewPosition = new Vector2(0.0f, 0.0f);
                _viewSize = new Vector2(1.0f, 1.0f);

                _cameras[0].orthographic = true;
                _cameras[0].orthographicSize = _cameraSize;
                _cameras[0].rect = new Rect(_viewPosition.x, _viewPosition.y, _viewSize.x, _viewSize.y);
            }
            else 
            {
                //Code for more than one camera
            }           
        }
    }
}