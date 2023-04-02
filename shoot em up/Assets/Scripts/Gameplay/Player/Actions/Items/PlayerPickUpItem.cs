using System;
using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Player.Actions.Items 
{
    public class PlayerPickUpItem : PlayerBase
    {
        private GameObject _pickedUpItem;

        private IEquipableItem _equipableItemAux;

        public event Action<GameObject> OnItemPickedUp;        

        public GameObject PickedUpItem 
        {
            get
            {
                return _pickedUpItem;
            }
        }

        void OnDestroy()
        {
            Identity.PickUpItemKeyboardInput.OnKeyboardKeyPressed -= PickUpItem;
        }

        void OnTriggerEnter2D(Collider2D collision)
        {            
            _equipableItemAux = collision.GetComponent<IEquipableItem>();
        }

        void OnTriggerExit2D(Collider2D collision)
        {
            _equipableItemAux = null;
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();

            Identity.PickUpItemKeyboardInput.OnKeyboardKeyPressed += PickUpItem;

            _equipableItemAux = null;
        }


        private void PickUpItem() 
        {
            if (_equipableItemAux != null)
            {
                _pickedUpItem = _equipableItemAux.PickedUp(gameObject);

                OnItemPickedUp?.Invoke(_pickedUpItem);
            }
        }
    }
}