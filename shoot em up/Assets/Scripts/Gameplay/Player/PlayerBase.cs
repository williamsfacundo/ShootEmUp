using UnityEngine;

using ShootEmUp.Gameplay.Identity;
using ShootEmUp.Gameplay.Interfaces;

namespace ShootEmUp.Gameplay.Player 
{
    public abstract class PlayerBase : MonoBehaviour, IInitiallySettable
    {
        private PlayerIdentity _identity;

        public PlayerIdentity Identity 
        {
            set 
            { 
                _identity = value; 
            }
            get 
            { 
                return _identity; 
            }
        }

        public abstract void InitialSettings();
    }
}