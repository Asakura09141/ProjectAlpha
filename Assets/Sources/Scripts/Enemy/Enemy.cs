using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movement))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private readonly float _stoppingDistance = 1f;
    private readonly float _timeWait = 2f;

    [SerializeField] private Transform[] _points;

    private int _currentIndex = 0;
    private bool _isPatrolling = true;
    private bool _isMovingToPoint = false;
    private Movement _movement;
    private Health _health;
    private Transform _targetPoint;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        if (_points.Length > 0 && _points[_currentIndex] != null)
        {
            StartCoroutine(Patroling());
        }
        else
        {
            Debug.LogError("There are no points of movement.");
        }
    }

    private void FixedUpdate()
    {
        if (_isMovingToPoint == false || _targetPoint == null)
        {
            return;
        }

        float distanceSqr = (transform.position - _targetPoint.position).sqrMagnitude;

        if (distanceSqr <= _stoppingDistance * _stoppingDistance)
        {
            _movement.StopMove();
            _isMovingToPoint = false;
            return;
        }

        float direction = Mathf.Sign(_targetPoint.position.x - transform.position.x);
        _movement.Move(direction);
    }

    private IEnumerator Patroling()
    {
        while (_isPatrolling)
        {
            _targetPoint = _points[_currentIndex];
            _isMovingToPoint = true;

            while (_isMovingToPoint)
                yield return null;

            yield return new WaitForSeconds(_timeWait);

            _currentIndex = (_currentIndex + 1) % _points.Length;
        }
    }
}
