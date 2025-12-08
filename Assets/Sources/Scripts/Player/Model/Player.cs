using UnityEngine;

[RequireComponent(typeof(UniversalInputSystem))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(Health))]
public class Player : MonoBehaviour
{
    private IInputSystem _input;
    private PlayerMovement _movement;
    private Health _health;

    private void Awake()
    {
        _input = GetComponent<IInputSystem>();
        _movement = GetComponent<PlayerMovement>();
        _health = GetComponent<Health>();
    }

    private void Start()
    {
        float testDamage = 30;
        TakeDamage(testDamage);
        TakeDamage(testDamage);
    }

    private void OnEnable()
    {
        _movement.SetInput(_input);
    }

    private void TakeDamage(float damage)
    {
        _health.Remove(damage);
    }

}