using Unity.VisualScripting;
using UnityEngine;

namespace ShootEmUp.Gameplay.Player.ScriptableObjects 
{
    [CreateAssetMenu(fileName = "NewPlayerStats", menuName = "ShootEmUp/Player Stats", order = 1)]
    public class PlayerStats : ScriptableObject
    {
        public GameObject _initialWeapon;

        public MouseButton _useItemMouseButton;
    }
}