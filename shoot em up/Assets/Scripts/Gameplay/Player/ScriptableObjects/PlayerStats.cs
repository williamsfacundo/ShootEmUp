using Unity.VisualScripting;
using UnityEngine;

namespace ShootEmUp.Gameplay.Player.ScriptableObjects 
{
    [CreateAssetMenu(fileName = "NewPlayerStats", menuName = "ShootEmUp/Player Stats", order = 1)]
    public class PlayerStats : ScriptableObject
    {
        public GameObject _initialWeapon;

        public MouseButton _useItemMouseButton;

        public KeyCode _pickUpItemButton;

        public string _horizontalAxisName;

        public string _verticalAxisName;

        public float _movementAceleration;

        public float _maxVelocity;
    }
}