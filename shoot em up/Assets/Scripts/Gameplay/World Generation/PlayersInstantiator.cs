using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.WorldGeneration 
{
    public class PlayersInstantiator : ObjectsInstantiator
    {
        private GameObject _players;

        private PlayerIdentity _playersIdentity; 
        
        public PlayerIdentity PlayersIdentity 
        {
            get 
            { 
                return _playersIdentity; 
            }
        }

        public override void InstantiateObjects() 
        {
            if (_objectPrefab != null) 
            {
                _playersIdentity = _objectPrefab.GetComponent<PlayerIdentity>();
                
                if (_playersIdentity == null) 
                {
                    Debug.LogError("The player prefab assigned doesn´t have PlayerIdentity scripts!");                    
                }
                else 
                {
                    _players = Instantiate(_objectPrefab);
                }
            }
            else 
            {
                Debug.LogError("There is no player prefab assigned!");
            }
        }
        
        public void SetUpPlayers() 
        {
            _playersIdentity = _players.GetComponent<PlayerIdentity>();

            _playersIdentity.InitialSettings();
        }
    }
}