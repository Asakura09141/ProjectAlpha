using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private IInputSystem _inputSystem;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _inputSystem = GetComponent<InputSystemManager>();
    }

    private void OnEnable()
    {
        _inputSystem.Moving += OnMoving;
        _inputSystem.Jumping += OnJumping;
    }

    private void OnDisable()
    {
        _inputSystem.Moving -= OnMoving;
        _inputSystem.Jumping -= OnJumping;
    }

    private void OnMoving(float moveDirection)
    {
        _rigidbody2D.linearVelocity = new Vector2(moveDirection * _speed, _rigidbody2D.linearVelocity.y);
    }

    private void OnJumping()
    {
        _rigidbody2D.linearVelocity = new Vector2(_rigidbody2D.linearVelocity.y, _jumpForce);
    }
}