using Unity.VisualScripting;
using UnityEngine;
using System;

namespace ShootEmUp.Gameplay.Player.Actions.Combat
{
    public class PlayerPullTheTriggerAction : MonoBehaviour
    {
        [SerializeField] private MouseButton _pullTheTriggerMouseButton;

        public event Action OnTriggerPulled;

        void Update()
        {
            PullTheTrigger();
        }

        private void PullTheTrigger()
        {
            if (Input.GetMouseButtonDown((int)_pullTheTriggerMouseButton))
            {
                OnTriggerPulled?.Invoke();
            }                        
        }
    }
}