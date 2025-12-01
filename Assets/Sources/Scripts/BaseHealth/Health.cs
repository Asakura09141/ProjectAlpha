using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _value;

    private void Awake()
    {
        if (_value > _maxValue)
        {
            _value = _maxValue;
        }
    }

    public void TakeDamage(int damage)
    {
        _value = _value - damage < 0 ? 0 : _value - damage;
    }

    public void Heal(int amount)
    {
        _value = _value + amount > _maxValue ? _maxValue : _value + amount;
    }
}