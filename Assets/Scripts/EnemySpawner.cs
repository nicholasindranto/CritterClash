using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // reference ke lokasi spawnnya
    public Transform[] spawnPoints;

    // reference prefab buat spawn enemy nya
    public GameObject[] enemyPrefab;

    // level sekarang
    private int level = 0;

    private void Start()
    {
        level = LevelManager.Instance.level;

        StartSpawning(); // mulai untuk spawning
    }

    // spawn enemy nya
    private void StartSpawning()
    {
        // spawn sesuai levelnya
        if (level == 1)
        {
            // spawn snail aja di spawnPoints 0 dan 1 setiap 5 detik sekali

            InvokeRepeating("SpawnSnail", 0.0f, 5.0f);
        }
        else if (level == 2)
        {
            // spawn snail dan boar di spawnPoints 0 dan 1 setiap 4 detik sekali

            InvokeRepeating("SpawnSnailBoar", 0.0f, 4.0f);
        }
        else if (level == 3)
        {
            // spawn snail dan boar di spawnPoints 0 dan 1 setiap 3 detik sekali
            // sama spawn bee di spawnPoints 2 dan 3 setiap 3 detik sekali

            InvokeRepeating("SpawnSnailBoar", 0.0f, 3.0f);
            InvokeRepeating("SpawnBee", 0.0f, 3.0f);
        }
    }

    private void SpawnSnail()
    {
        // validasi ada targetnya kaga si player
        if (GameManager.Instance.player == null)
        {
            return;
        }

        // kita random dulu lokasinya
        int randomPoint = Random.Range(0, 2);

        // baru kita spawn
        Instantiate(enemyPrefab[0], spawnPoints[randomPoint].position, Quaternion.identity);
    }

    private void SpawnSnailBoar()
    {
        // validasi ada targetnya kaga si player
        if (GameManager.Instance.player == null)
        {
            return;
        }

        // kita random dulu lokasinya
        int randomPoint = Random.Range(0, 2);

        // kita random juga enemynya
        int randomEnemy = Random.Range(0, 2); // 0 = snail, 1 = boar

        // baru kita spawn
        Instantiate(enemyPrefab[randomEnemy], spawnPoints[randomPoint].position, Quaternion.identity);
    }

    private void SpawnBee()
    {
        // validasi ada targetnya kaga si player
        if (GameManager.Instance.player == null)
        {
            return;
        }

        // kita random dulu lokasinya
        int randomPoint = Random.Range(2, 4);

        // baru kita spawn
        Instantiate(enemyPrefab[2], spawnPoints[randomPoint].position, Quaternion.identity);
    }
}
