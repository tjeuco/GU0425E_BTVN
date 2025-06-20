using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] EnemyBasic enemyPerfab;
    [SerializeField] private int maxEnemy = 5;
    public List<EnemyBasic> enemyPerfabList = new List<EnemyBasic>();
    void Start()
    {
     for (int i = 0; i < maxEnemy; i++)
        {
           EnemyBasic e = Instantiate(enemyPerfab, this.transform.position,Quaternion.identity, this.transform);
            enemyPerfabList.Add(e);
        }   
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
