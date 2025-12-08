using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public event Action<float, float> HealthChanged;

    [SerializeField] private float _maxValue;
    [SerializeField] private float _value;

    private void OnValidate()
    {
        if (_value > _maxValue)
        {
            _value = _maxValue;
        }
        else if (_value < 0)
        {
            _value = 0;
        }

        HealthChanged?.Invoke(_value, _maxValue);
    }

    public void Add(float damage)
    {
        _value = _value + damage < 0 ? 0 : _value + damage;
        HealthChanged?.Invoke(_value, _maxValue);
    }

    public void Remove(float amount)
    {
        _value = _value - amount > _maxValue ? _maxValue : _value - amount;
        HealthChanged?.Invoke(_value, _maxValue);
    }
}