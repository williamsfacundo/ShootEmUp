using UnityEngine;
using System;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Player.Items
{
    public class PlayerInventory : PlayerBase
    {
        [SerializeField] private GameObject _initialEquipItemPrefab;

        public event Action OnWeaponChanged;

        private GameObject _equippedItem;

        private WeaponIdentity _weaponIdentityAux;

        IEquipableItem _equipableItem;

        public GameObject EquippedItem 
        {
            get 
            {
                return _equippedItem;
            }
        }

        public IEquipableItem EquipableItem 
        {
            get 
            {
                return _equipableItem;
            }
        }

        void OnDestroy()
        {
            Identity.PickUpItem.OnItemPickedUp -= SwitchEquippedItem;
        }

        public void SwitchEquippedItem(GameObject newWeapon) 
        {
            _equippedItem.GetComponent<IEquipableItem>().DroppedDown();

            _equippedItem = newWeapon;

            _equipableItem = _equippedItem.GetComponent<IEquipableItem>(); 

            OnWeaponChanged?.Invoke();            
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();

            if (_initialEquipItemPrefab == null)
            {
                Debug.LogError("No initial weapon was given!");
            }
            else
            {
                if (IsEquipItemPrefabAnEquippableItem(_initialEquipItemPrefab))
                {
                    SetInitialWeapon();
                }
                else
                {
                    Debug.LogError("The initial weapon given is not a weapon!");
                }
            }

            Identity.PickUpItem.OnItemPickedUp += SwitchEquippedItem;
        }

        private void SetInitialWeapon()
        {
            _equippedItem = Instantiate(_initialEquipItemPrefab, transform.position, Quaternion.identity);

            _equipableItem = _equippedItem.GetComponent<IEquipableItem>();

            _weaponIdentityAux = _equippedItem.GetComponent<WeaponIdentity>();

            _weaponIdentityAux.InitialSettings();

            _weaponIdentityAux.PickedUp.PickedUp(gameObject);
        }

        private bool IsEquipItemPrefabAnEquippableItem(GameObject prefab) 
        {
            return prefab.GetComponent<IEquipableItem>() != null;
        }
    }
}