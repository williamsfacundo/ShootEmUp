using System;
using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Player.Actions.Items 
{
    public class PlayerPickUpItem : PlayerBase
    {
        private GameObject _pickedUpItem;

        public event Action<GameObject> OnItemPickedUp;

        bool _pickUpItem;

        public GameObject PickedUpItem 
        {
            get
            {
                return _pickedUpItem;
            }
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();

            _pickUpItem = false;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (_pickUpItem) 
            {
                if (collision is IEquipableItem) 
                {
                    _pickedUpItem = collision.GetComponent<IEquipableItem>().PickedUp(gameObject);

                    OnItemPickedUp?.Invoke(_pickedUpItem);
                }

                _pickUpItem = !_pickUpItem;
            }
        }
    }
}