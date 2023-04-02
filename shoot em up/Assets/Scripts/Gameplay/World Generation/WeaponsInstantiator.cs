using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.WorldGeneration 
{
    public class WeaponsInstantiator : ObjectsInstantiator
    {
        private GameObject _weapons;

        private WeaponIdentity _weaponsIdentity;

        public override void InstantiateObjects() 
        {
            if (_objectPrefab != null)
            {
                _weaponsIdentity = _objectPrefab.GetComponent<WeaponIdentity>();

                if (_weaponsIdentity == null)
                {
                    Debug.LogError("The player prefab assigned doesn´t have PlayerIdentity scripts!");
                }
                else
                {
                    _weapons = Instantiate(_objectPrefab);
                }
            }
            else
            {
                Debug.LogError("There is no player prefab assigned!");
            }
        }

        public void SetUpWeapons()
        {
            _weaponsIdentity = _weapons.GetComponent<WeaponIdentity>();

            _weaponsIdentity.InitialSettings();
        }
    }
}