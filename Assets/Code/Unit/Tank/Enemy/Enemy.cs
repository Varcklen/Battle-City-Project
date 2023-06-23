using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit
{
    public int KillPoints = 1;

    private GameManager _playerManager;

    private void Start()
    {
        _playerManager = GameManager.Instance;
    }
    protected override void Death()
    {
        _playerManager.SetScore(_playerManager.Score + KillPoints);
        _playerManager.SetEnemiesLeft(_playerManager.EnemiesToDefeat - 1);
        if (_playerManager.EnemiesToDefeat <= 0)
        {
            _playerManager.Win();
        }
        Destroy(gameObject);
    }
}
