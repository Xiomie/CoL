using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateEnemy : MonoBehaviour
{
    public GameObject theEnemy;
    public int xPos;
    public int yPos;
    public int zPos;
    public int enemyCount;

    void Start()
    {
        StartCoroutine(EnemyDrop());
    }
  IEnumerator EnemyDrop()
        {
            while (enemyCount < 10)
            {
                xPos = Random.Range(-40, 200);
                zPos = Random.Range(-40, -250);
                yPos = Random.Range(1, 50);
                Instantiate(theEnemy, new Vector3(xPos, yPos, zPos), Quaternion.identity);
                yield return new WaitForSeconds(1f);
                enemyCount += 1;
            }
        }
   
}
