using UnityEngine;

[RequireComponent(typeof(Movement))]
public class EnemyMovement : MonoBehaviour
{
    private readonly float _stoppingDistance = 1f;

    private Movement _movement;
    private Transform _target;

    private void Awake()
    {
        _movement = GetComponent<Movement>();
    }

    private void FixedUpdate()
    {
        if (_target == null)
            return;

        float distanceSqr = (transform.position - _target.position).sqrMagnitude;

        if (distanceSqr <= _stoppingDistance * _stoppingDistance)
        {
            _movement.StopMove();
            return;
        }

        float direction = Mathf.Sign(_target.position.x - transform.position.x);
        _movement.Move(direction);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }

    public bool IsTargetReached()
    {
        if (_target == null)
            return true;

        float distanceSqr = (transform.position - _target.position).sqrMagnitude;
        return distanceSqr <= _stoppingDistance * _stoppingDistance;
    }
}
