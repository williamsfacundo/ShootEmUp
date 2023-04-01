using UnityEngine;

namespace ShootEmUp.Gameplay.WorldGeneration 
{
    [RequireComponent(typeof(CamerasInstantiator), typeof(PlayersInstantiator))]
    public class WorldGenerationManager : MonoBehaviour
    {
        private static PlayersInstantiator _playersInstantiator;

        private static CamerasInstantiator _camerasInstantiator;

        public static CamerasInstantiator Cameras
        {
            get 
            {
                return _camerasInstantiator;
            }                
        }

        public static PlayersInstantiator Players 
        {
            get 
            {
                return _playersInstantiator;
            }
        }

        void Start()
        {
            GenerateWorld();
        }

        private void GetComponenets() 
        {
            _playersInstantiator = GetComponent<PlayersInstantiator>();
            
            _camerasInstantiator = GetComponent<CamerasInstantiator>();
        }

        private void InitializeScripts() 
        {
            _playersInstantiator.InstantiateObjects();

            _camerasInstantiator.InstantiateObjects();
        }
        
        private void SetObjects() 
        {
            _playersInstantiator.SetUpPlayers();

            _camerasInstantiator.SetCamerasTarget(_playersInstantiator.PlayersIdentity.transform);
        }

        private void GenerateWorld() 
        {
            GetComponenets();

            InitializeScripts();

            SetObjects();
        }
    }
}