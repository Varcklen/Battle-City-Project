using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : Unit
{
    protected override void Death()
    {
        Destroy(gameObject);
        GameManager.Instance.Lose();
    }
}
