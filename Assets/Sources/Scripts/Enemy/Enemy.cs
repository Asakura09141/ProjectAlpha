using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Enemy : MonoBehaviour
{
    private readonly float _stoppingDistance = 1f;
    private readonly float _timeWait = 2f;

    [SerializeField] private Transform[] _points;

    private int _currentIndex = 0;
    private bool _isPatrolling = true;
    private Movement _movement;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void Start()
    {
        if (_points.Length > 0 && _points[_currentIndex] != null)
            StartCoroutine(Patroling());
    }

    private IEnumerator Patroling()
    {
        Transform point = _points[_currentIndex];
        float direction = Mathf.Sign(point.position.x - transform.position.x);

        while ((transform.position - point.position).sqrMagnitude > _stoppingDistance * _stoppingDistance)
        {
            if (_isPatrolling == false)
            {
                yield break;
            }

            _movement.Move(direction);
            yield return null;
        }

        _movement.StopMove();

        yield return new WaitForSeconds(_timeWait);

        _currentIndex = (_currentIndex + 1) % _points.Length;

        StartCoroutine(Patroling());
    }
}
