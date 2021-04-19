 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public GameObject theEnemy;
     
    public List<GameObject> theEnemy;

    public int xPos;
    public int zPos;
    public int enemyCount;
    private int curEnemy = 0;
    void Start()
    {
       
        StartCoroutine(EnemyDrop());   
    }

    IEnumerator EnemyDrop()
    {
        
        while (curEnemy < enemyCount)
        {
            int mystery = Random.Range(0, theEnemy.Count);

            xPos = Random.Range(-70, 40);
            zPos = Random.Range(-70, 40);
            
            Instantiate(theEnemy[mystery], new Vector3(xPos, 5, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            curEnemy += 1;
        }
    }
}
