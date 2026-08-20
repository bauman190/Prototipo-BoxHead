using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    private const int _baseEnemyCount = 6;

    private int _enemysToSpawn = 0;

    private const int _maxEnemysInScreen = 24;

    private int _enemysInScreen = 0;

    [SerializeField] private List<Spawner> spawners;

    private int Round = 1;

    private void Awake()
    {
        GetSpawnersInLvL();
    }

    void Start()
    {
        StartFirstRound();
    }
    
    void Update()
    {
        HandleRounds();
    }

    int CalculeteEnemysInRound()
    {
        return _baseEnemyCount + (Round * 2);
    }

    void PassRound()
    {
        Round++;
        _enemysToSpawn = CalculeteEnemysInRound();
        Debug.Log("Enemys to Spown: " + _enemysToSpawn);
    }

    void StartFirstRound()
    {
        _enemysToSpawn = CalculeteEnemysInRound();
        Debug.Log("Enemys to Spown: " + _enemysToSpawn);
    }

    void HandlePassRound()
    {
        if (_enemysToSpawn == 0 && _enemysInScreen == 0)
        {
            PassRound();
            Debug.Log("Round: " + Round);
        }
    }

    void SpawnEnemy()
    {
        if (_enemysToSpawn > 0 && _enemysInScreen < _maxEnemysInScreen)
        {
            Spawner spawnerToUse = spawners[Random.Range(0,spawners.Count)];
            spawnerToUse.Spawn();
            _enemysInScreen++;
            _enemysToSpawn--;
            Debug.Log("Enemys in Screen: " + _enemysInScreen);
        }
    }

    void HandleRounds()
    {
        SpawnEnemy();
        HandlePassRound();
    }

    void GetSpawnersInLvL()
    {
        spawners = new List<Spawner> { GetComponentInChildren<Spawner>() }; //solo esta devolviendo el primero y no todos
    }

    public void DecreaseEnemysInScreen()
    {
        _enemysInScreen--;
        Debug.Log("Enemys in Screen: " + _enemysInScreen);
    }
}
