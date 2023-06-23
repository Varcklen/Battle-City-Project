using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFire : TankFire
{
    [SerializeField, Min(0.2f)] private float _inputCooldown = 1f;
    private readonly float _cooldownDeviation = 0.1f;

    private void Start()
    {
        StartCoroutine(Input());
    }

    IEnumerator Input()
    {
        var cooldown = new WaitForSeconds(_inputCooldown + Random.Range(-_cooldownDeviation, _cooldownDeviation));
        while (true)
        {
            yield return cooldown;
            Fire();
        }

    }
}
