using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class HealthView : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _bar;
    [SerializeField] private float _time;

    private void Awake()
    {
        if (_health == null)
        {
            Debug.LogError("Component not specified");
        }
        if (_bar == null)
        {
            Debug.LogError("No Image found for HP bar");
        }
    }

    private void OnEnable()
    {
        _health.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _health.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float current, float max)
    {
        float percent = current / max;
        float time = 5;

        StopAllCoroutines();
        StartCoroutine(LerpHealthBar(time, _bar.fillAmount, percent));
    }

    private IEnumerator LerpHealthBar(float duration, float start, float end)
    {
        float elapsedTime = 0;

        while (elapsedTime <= duration)
        {
            elapsedTime += Time.deltaTime;
            float normalizedTime = Mathf.Clamp01(elapsedTime / duration);
            _bar.fillAmount = Mathf.Lerp(start, end, normalizedTime);

            yield return null;
        }
    }
}