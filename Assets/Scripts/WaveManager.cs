using System.Collections;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    [Header("Enemy Prefab")]
    public GameObject malwarePrefab;

    [Header("Path Waypoints")]
    public Transform[] waypoints;

    [Header("Wave Settings")]
    public int enemyCount = 7;
    public float spawnDelay = 0.8f;

    private bool waveStarted = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !waveStarted)
        {
            StartWave();
        }
    }

    public void StartWave()
    {
        waveStarted = true;
        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnEnemy()
    {
        if (malwarePrefab == null)
        {
            Debug.LogError("Malware Prefab belum diisi di WaveManager.");
            return;
        }

        if (waypoints == null || waypoints.Length == 0)
        {
            Debug.LogError("Waypoints belum diisi di WaveManager.");
            return;
        }

        GameObject enemyObject = Instantiate(
            malwarePrefab,
            waypoints[0].position,
            Quaternion.identity
        );

        Enemy enemy = enemyObject.GetComponent<Enemy>();

        if (enemy != null)
        {
            enemy.SetPath(waypoints);
        }
    }
}