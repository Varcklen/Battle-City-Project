using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for inter-gameplay logic.
/// </summary>
public class GameManager : MonoBehaviour
{
    [HideInInspector] public GameObject Player;
    [SerializeField] private GameObject _playerPrefab;
    [SerializeField] private int _playerLife = 3;
    [SerializeField] private float _ressurectionDelay = 3f;

    public int Score { get; private set; } = 0;
    public int EnemiesToDefeat { get; private set; } = 0;

    public Vector2 _playerSpawnPoint;
    private int _maxLife;
    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this; 
    }

    private void Start()
    {
        _maxLife = _playerLife;
        SetHealth(_playerLife);
        SetScore(Score);

        Debug.Log("TIP: Move: WASD, Shoot: Space.");
    }

    public void SetHealth(int newHealth)
    {
        _playerLife = newHealth;
        InfoPanel.Instance.SetHealth(_playerLife);
    }

    public void SetScore(int newScore)
    {
        Score = newScore;
        InfoPanel.Instance.SetScore(Score);
    }

    public void SetEnemiesLeft(int newAmount)
    {
        EnemiesToDefeat = newAmount;
        InfoPanel.Instance.SetEnemiesLeft(newAmount);
    }

    #region Player Spawn
    public void RessurectPlayer()
    {
        SetHealth(_playerLife--);
        if (_playerLife < 0)
        {
            Lose();
            return;
        }
        Debug.Log($"You'll be ressurected in {_ressurectionDelay} seconds.");
        StartCoroutine(CreatePlayer());
    }

    private IEnumerator CreatePlayer()
    {
        yield return new WaitForSeconds(_ressurectionDelay);
        SpawnPlayer(_playerSpawnPoint);
    }

    public GameObject SpawnPlayer(Vector2 position)
    {
        Player = Instantiate(_playerPrefab, position, Quaternion.identity);
        return Player;
    }
    #endregion

    #region End Game
    public void Lose()
    {
        End(false);
    }

    public void Win()
    {
        End(true);
    }

    public void End(bool isWin)
    {
        WorldCreator.Instance.RemoveOldWorld();
        ResultPanel.Instance.SetResults(isWin);
        SetHealth(_maxLife);
        InfoPanel.Instance.Hide();
    }
    #endregion
}
