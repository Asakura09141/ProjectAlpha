using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Move(float direction)
    {
        _rigidbody2D.linearVelocity = new Vector2(direction * _speed, _rigidbody2D.linearVelocity.y);
    }

    public void StopMove()
    {
        _rigidbody2D.linearVelocity = new Vector2(0f * _speed, _rigidbody2D.linearVelocity.y);
    }
}
