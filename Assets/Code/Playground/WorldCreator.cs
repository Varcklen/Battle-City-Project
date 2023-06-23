using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Create/Delete Game World
/// </summary>
public class WorldCreator : MonoBehaviour
{
    [SerializeField] private GameObject basePrefab;
    [SerializeField] private List<GameObject> enemyPrefabs;
    [SerializeField] private List<GameObject> wallPrefabs;
    [SerializeField] private List<GameObject> heavyWallPrefabs;
    [SerializeField] private int minPoints;
    [SerializeField] private int maxPoints;

    [Tooltip("Each attribute unit creates an enemy in the game.")]
    [SerializeField, Range(1, 12)] private int _enemiesToCreate = 4;

    [Tooltip("The higher the attribute, the more walls will be in the game.")]
    [SerializeField, Range(1, 10)] private int _density = 7;

    [Tooltip("The higher the attribute, the more ordinary walls will be heavy.")]
    [SerializeField, Range(1, 10)] private int _heavyWallDensity = 3;
    private static int max = 10;


    [SerializeField] Vector2 _baseSpawn;

    private List<Vector2> _spawnPoints;
    private GameManager _playerSpawn;

    private List<GameObject> _worldUnits;

    public static WorldCreator Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(this);
        else
            Instance = this;
    }

    private void Start()
    {
        _spawnPoints = new List<Vector2>();
        _worldUnits = new List<GameObject>();
        _playerSpawn = GameManager.Instance;
        GenerateNewWorld();
    }

    public void GenerateNewWorld()
    {
        RemoveOldWorld();
        RefreshGridList();

        //Player Creating
        Vector2 _spawnPoint = _playerSpawn._playerSpawnPoint;
        GameObject unit = _playerSpawn.SpawnPlayer(_spawnPoint);
        RemoveFromList(_spawnPoint);
        _worldUnits.Add(unit);

        //Base Creating
        unit = Instantiate(basePrefab, _baseSpawn, Quaternion.identity);
        RemoveFromList(_baseSpawn);
        _worldUnits.Add(unit);

        //Enemy Creating
        for (int i = 0; i < _enemiesToCreate; i++)
        {
            EnemyCreating();
        }
        GameManager.Instance.EnemiesToDefeat = _enemiesToCreate;

        //Wall Creating
        int wallsToCreate = _spawnPoints.Count * _density / max;
        for (int i = 0; i < wallsToCreate; i++)
        {
            WallCreating();
        }
    }

    private void EnemyCreating()
    {
        Vector2 point = GetRandomVectorFromList();
        int random = Random.Range(0, enemyPrefabs.Count);
        CreateUnit(enemyPrefabs, random, point);
    }

    private void WallCreating()
    {
        Vector2 point = GetRandomVectorFromList();
        List<GameObject> list;
        if (Random.Range(1, max) <= _heavyWallDensity)
        {
            list = heavyWallPrefabs;
        }
        else
        {
            list = wallPrefabs;
        }
        int random = Random.Range(0, list.Count-1);
        CreateUnit(list, random, point);
    }

    private void CreateUnit(List<GameObject> list, int random, Vector2 point)
    {
        //Debug.Log($"List: {list}, Count: {list.Count}, Random: {random}, Point: {point}");
        GameObject unit = Instantiate(list[random], point, Quaternion.identity);
        RemoveFromList(point);
        _worldUnits.Add(unit);
    }

    public void RemoveOldWorld()
    {
        foreach (var unit in _worldUnits)
        {
            Destroy(unit);
        }
    }

    private void RefreshGridList()
    {
        _spawnPoints.Clear();
        for (int x = minPoints; x < maxPoints; x++)
        {
            for (int y = minPoints; y < maxPoints; y++)
            {
                _spawnPoints.Add(new Vector2(x, y));
            }
        }
    }

    private Vector2 GetRandomVectorFromList()
    {
        int random = Random.Range(0, _spawnPoints.Count);
        return _spawnPoints[random];
    }

    private void RemoveFromList(Vector2 vector)
    {
        _spawnPoints.Remove(vector);
    }
}
