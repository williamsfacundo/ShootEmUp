using UnityEngine;

using ShootEmUp.Gameplay.Identity;

namespace ShootEmUp.Gameplay.Player.Actions.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : PlayerBase
    {
        [SerializeField] [Range(10.0f, 50.0f)] private float _velocity;

        [SerializeField] private string _horizontalAxisName;

        [SerializeField] private string _verticalAxisName;        

        private Vector2 _position;
        private Vector2 _moveDirection;

        private float _inputX;
        private float _inputY;              

        void Update()
        {
            MovementInput();

            CalculateMoveDirection();
        }

        void FixedUpdate()
        {
            Movement();
        }

        public override void InitialSettings()
        {
            Identity = GetComponent<PlayerIdentity>();            

            _position = Vector2.zero;

            _moveDirection = Vector2.zero;
        }

        private void MovementInput() 
        {
            _inputX = Input.GetAxisRaw(_horizontalAxisName);
            _inputY = Input.GetAxisRaw(_verticalAxisName);
        }

        private void CalculateMoveDirection() 
        {
            _moveDirection.x = _inputX * _velocity * Time.deltaTime;
            _moveDirection.y = _inputY * _velocity * Time.deltaTime;            
        }

        private void Movement()
        {
            _position.x = transform.position.x;
            _position.y = transform.position.y;

            Identity.EntityRigidbody2D.MovePosition(_position + _moveDirection);           
        }
    }
}