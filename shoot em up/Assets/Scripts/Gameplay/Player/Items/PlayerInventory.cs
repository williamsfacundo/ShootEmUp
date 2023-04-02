using UnityEngine;
using System;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Player.Items
{
    public class PlayerInventory : PlayerBase
    {
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
            _equippedItem.GetComponent<IEquipableItem>().DroppedDown(transform.position);

            _equippedItem = newWeapon;

            _equipableItem = _equippedItem.GetComponent<IEquipableItem>(); 

            OnWeaponChanged?.Invoke();            
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();

            if (Identity.Stats._initialWeapon == null)
            {
                Debug.LogError("No initial weapon was given!");
            }
            else
            {
                if (IsEquipItemPrefabAnEquippableItem(Identity.Stats._initialWeapon))
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
            _equippedItem = Instantiate(Identity.Stats._initialWeapon, transform.position, Quaternion.identity);

            _equipableItem = _equippedItem.GetComponent<IEquipableItem>();

            _weaponIdentityAux = _equippedItem.GetComponent<WeaponIdentity>();

            _weaponIdentityAux.InitialSettings();

            _weaponIdentityAux.PickedUp.PickedUp(gameObject);

            OnWeaponChanged?.Invoke();
        }

        private bool IsEquipItemPrefabAnEquippableItem(GameObject prefab) 
        {
            return prefab.GetComponent<IEquipableItem>() != null;
        }
    }
}