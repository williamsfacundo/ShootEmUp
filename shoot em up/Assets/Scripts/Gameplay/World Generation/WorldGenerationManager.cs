using UnityEngine;

namespace ShootEmUp.Gameplay.WorldGeneration 
{
    [RequireComponent(typeof(CamerasInstantiator), typeof(PlayersInstantiator), typeof(WeaponsInstantiator))]
    public class WorldGenerationManager : MonoBehaviour
    {
        private static PlayersInstantiator _playersInstantiator;

        private static CamerasInstantiator _camerasInstantiator;

        private static WeaponsInstantiator _weaponsInstantiator;

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

        private static WeaponsInstantiator Weapons 
        {
            get 
            { 
                return _weaponsInstantiator;
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

            _weaponsInstantiator = GetComponent<WeaponsInstantiator>();
        }

        private void InitializeScripts() 
        {
            _playersInstantiator.InstantiateObjects();

            _camerasInstantiator.InstantiateObjects();

            _weaponsInstantiator.InstantiateObjects();
        }
        
        private void SetObjects() 
        {
            _playersInstantiator.SetUpPlayers();

            _camerasInstantiator.SetCamerasTarget(_playersInstantiator.PlayersIdentity.transform);

            _weaponsInstantiator.SetUpWeapons();
        }

        private void GenerateWorld() 
        {
            GetComponenets();

            InitializeScripts();

            SetObjects();
        }
    }
}