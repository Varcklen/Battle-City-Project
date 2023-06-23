using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    public int Faction = 1; 
    [SerializeField] private int Health = 1;

    protected abstract void Death();

    public void TakeDamage()
    {
        Health--;
        if (Health <= 0) Death();
    }
}
