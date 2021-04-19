using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform[] Spawnpoint;
    
    public int enemyCount;
    private int curEnemy = 0;
    public List<GameObject> theEnemy;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy();
    }

    // Update is called once per frame
    void SpawnNewEnemy()
        {
        while (curEnemy < enemyCount)
        {
            int mystery = Random.Range(0, theEnemy.Count);
            int randomNumber = Mathf.RoundToInt(Random.Range(0f, Spawnpoint.Length - 1));
            Instantiate(theEnemy[mystery], Spawnpoint[randomNumber].transform.position, Quaternion.identity);
            curEnemy += 1;
        }    
    }
}
