using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaOfEffect : MonoBehaviour
{
    public DamageOverTime dot;
    [SerializeField] private float _cooldown;
    private bool _isDamaging;
    private int _timeToLiveRemaining; // Remaining duration of the effect

    private void Start()
    {
        _cooldown = dot.cooldown;
        _timeToLiveRemaining = dot.timeToLive;
        StartCoroutine(DestroyAfterDuration());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Opponent"))
        {
            dot.Apply(collision.gameObject);
            StartDamaging();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Opponent"))
        {
            StopDamaging();
        }
    }

    private void StartDamaging()
    {
        if (!_isDamaging)
        {
            _isDamaging = true;
            StartCoroutine(DamageOverTime());
        }
    }

    private void StopDamaging()
    {
        _isDamaging = false;
    }

    private IEnumerator DamageOverTime()
    {
        while (_isDamaging)
        {
            yield return new WaitForSeconds(_cooldown);
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x / 2);
            foreach (Collider2D collider in colliders)
            {
                if (collider.CompareTag("Opponent"))
                {
                    dot.Apply(collider.gameObject);
                }
            }
        }
    }

    private IEnumerator DestroyAfterDuration()
    {
        yield return new WaitForSeconds(_timeToLiveRemaining);
        Destroy(gameObject); // Destroy the area object after duration
    }
}
