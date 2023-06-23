using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : Unit
{
    [SerializeField] private bool _invulnerable;
    protected override void Death()
    {
        if (_invulnerable) return;
        Destroy(gameObject);
    }
}
