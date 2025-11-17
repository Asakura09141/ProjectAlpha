using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyMovement : MonoBehaviour, IMovable
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _points;

    private readonly float _stoppingDistance = 0.1f;
    private readonly float _timeWait = 2f;
    private int _currentIndex = 0;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        if (_points.Length > 0 && _points[_currentIndex] != null)
            StartCoroutine(Patrol());
    }

    public void Move(float direction)
    {
        _rigidbody2D.linearVelocity = new Vector2(direction * _speed, _rigidbody2D.linearVelocity.y);
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            Transform point = _points[_currentIndex];
            float direction = Mathf.Sign(point.position.x - transform.position.x);

            while (Vector2.Distance(transform.position, point.position) > _stoppingDistance)
            {
                Move(direction);
                yield return null;
            }

            Move(0f);

            yield return new WaitForSeconds(_timeWait);

            _currentIndex = (_currentIndex + 1) % _points.Length;
        }
    }
}