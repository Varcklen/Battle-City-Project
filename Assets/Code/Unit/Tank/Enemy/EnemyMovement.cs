using System.Collections;
using UnityEngine;

public class EnemyMovement : TankMovement
{
    [SerializeField, Min(0.2f)] private float _inputCooldown = 0.5f;
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
            MovePlayer(StaticScripts.GetRandomVector());
            yield return cooldown;
        }
        
    }
}
