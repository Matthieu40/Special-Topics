 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject theEnemy;
    //public GameObject 
    //public List<GameObject> theEnemy;

    public int xPos;
    public int zPos;
    public int enemyCount;
    void Start()
    {
       
        StartCoroutine(EnemyDrop());   
    }

    IEnumerator EnemyDrop()
    {
        //int mystery = Random.Range(0, theEnemy.Count);
        while (enemyCount < 10)
        {
            //int mystery = Random.Range(0, theEnemy.Count);

            xPos = Random.Range(-70, 40);
            zPos = Random.Range(-70, 40);
            Instantiate(theEnemy, new Vector3(xPos, 0 , zPos), Quaternion.identity);
            //Instantiate(theEnemy[mystery], new Vector3(xPos, 5, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            enemyCount += 1;
        }
    }
}
