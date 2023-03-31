using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Weapon 
{
    [RequireComponent(typeof(WeaponIdentity))]
    public abstract class WeaponBase : MonoBehaviour, IInitiallySettable
    {
        private WeaponIdentity _weaponIdentity;

        protected WeaponIdentity Identity 
        {
            set 
            {
                _weaponIdentity = value;
            }
            get 
            { 
                return _weaponIdentity;
            }
        }        

        public abstract void InitialSettings();
    }
}