using UnityEngine;

namespace ShootEmUp.Gameplay.Player.Actions.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovementController : MonoBehaviour
    {
        [SerializeField] [Range(10.0f, 50.0f)] private float _velocity;

        [SerializeField] private string _horizontalAxisName;

        [SerializeField] private string _verticalAxisName;

        private Rigidbody2D _rigidbody2D;

        private Vector2 _position;
        private Vector2 _moveDirection;

        private float _inputX;
        private float _inputY;

        void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();            
        }

        void Start()
        {
            _position = Vector2.zero;
            _moveDirection = Vector2.zero;
        }

        void Update()
        {
            MovementInput();

            CalculateMoveDirection();
        }

        void FixedUpdate()
        {
            Movement();
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

            _rigidbody2D.MovePosition(_position + _moveDirection);           
        }        
    }
}