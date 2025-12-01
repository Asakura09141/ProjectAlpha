using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Jumper : MonoBehaviour, ICanJump
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _feetPoint;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        if (IsGrounded() == false)
        {
            return;
        }

        _rigidbody2D.AddForceY(_jumpForce, ForceMode2D.Impulse);
    }

    public bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(_feetPoint.position, Vector2.down, 0.1f, _groundLayer);
        return hit.collider != null;
    }
}