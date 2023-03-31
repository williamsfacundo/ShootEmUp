using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Bullet
{
    public abstract class BulletBase : MonoBehaviour, IInitiallySettable
    {
        private BulletIdentity _bulletIdentity;

        public BulletIdentity Identity 
        {
            set 
            { 
                _bulletIdentity = value;
            }
            get 
            { 
                return _bulletIdentity; 
            }
        }

        public abstract void InitialSettings();
    }
}