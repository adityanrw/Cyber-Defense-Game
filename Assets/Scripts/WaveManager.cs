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
    private bool waveFinished = false;

    public void StartWave()
    {
        if (waveStarted) return;

        waveStarted = true;
        waveFinished = false;

        StartCoroutine(SpawnWave());
    }

    private IEnumerator SpawnWave()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(spawnDelay);
        }

        waveFinished = true;
        Debug.Log("Wave selesai spawn semua enemy.");
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
        else
        {
            Debug.LogError("Prefab malware belum punya script Enemy.");
        }
    }

    public bool IsWaveStarted()
    {
        return waveStarted;
    }

    public bool IsWaveFinished()
    {
        return waveFinished;
    }
}