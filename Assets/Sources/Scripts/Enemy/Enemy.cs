using System.Collections;
using UnityEngine;

[RequireComponent(typeof(EnemyMovement))]
[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    private readonly float _timeWait = 2f;

    [SerializeField] private Transform[] _points;

    private int _currentIndex = 0;
    private bool _isPatrolling = true;

    private EnemyMovement _movement;
    private Health _health;

    private void Awake()
    {
        _movement = GetComponent<EnemyMovement>();
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

    private IEnumerator Patroling()
    {
        while (_isPatrolling)
        {
            _movement.SetTarget(_points[_currentIndex]);

            yield return new WaitUntil(() => _movement.IsTargetReached());

            yield return new WaitForSeconds(_timeWait);

            _currentIndex = (_currentIndex + 1) % _points.Length;
        }
    }
}