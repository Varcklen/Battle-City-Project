using UnityEngine;

public class Player : Unit
{
    private GameManager _playerSpawn;

    private void Start()
    {
        _playerSpawn = FindObjectOfType<GameManager>();
    }

    protected override void Death()
    {
        _playerSpawn.RessurectPlayer();
        Destroy(gameObject);
    }
}
