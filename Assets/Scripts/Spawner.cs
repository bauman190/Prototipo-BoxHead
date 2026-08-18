using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject entityToSpawn;
    [SerializeField] private Transform target;
    [SerializeField] private Transform container;

    private BoxCollider spawnArea;

    private void Awake()
    {
        spawnArea = GetComponent<BoxCollider>();
    }

    void Start()
    {
        StartCoroutine(SpawnLoop());
    }

    private IEnumerator SpawnLoop()
    {
        while (true)
        {
            float time = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(time);

            Spawn();
        }
    }

    private void Spawn()
    {
        Bounds bounds = spawnArea.bounds;

        Vector3 randomPosition = new Vector3(Random.Range(bounds.min.x, bounds.max.x), transform.position.y, Random.Range(bounds.min.z, bounds.max.z));

        GameObject enemySpawned = Instantiate(entityToSpawn, randomPosition, Quaternion.identity, container);

        if (enemySpawned.TryGetComponent<EnemyController>(out EnemyController enemy))
        {
            enemy.SetTarget(target);
        }
    }
}
