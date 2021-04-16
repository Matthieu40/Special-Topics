using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] Spawnpoint;
    public GameObject EnemyPrefab;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
    }

    // Update is called once per frame
    void SpawnNewEnemy()
        {
        while (enemyCount < 10)
        {
            int randomNumber = Mathf.RoundToInt(Random.Range(0f, Spawnpoint.Length - 1));
            Instantiate(EnemyPrefab, Spawnpoint[randomNumber].transform.position, Quaternion.identity);
        }    }
}
