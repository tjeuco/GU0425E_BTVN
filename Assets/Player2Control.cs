using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player2Control : MonoBehaviour
{
    private Vector3 target;
    [SerializeField] EnemyManager enemyManager;
    [SerializeField] float speedMove = 1f;
    [SerializeField] GameObject enemy2Perfab;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyManager == null || enemyManager.enemyPerfabList == null) return;
        target = enemyManager.enemyPerfabList[0].transform.position;
        MovePlayer(target);
    }
    void MovePlayer(Vector3 target)
    { 
        Vector3 dir = (target - this.transform.position).normalized;
        this.transform.position += dir * speedMove * Time.deltaTime;
        if (dir.magnitude < 0.3f)
        {
            GameObject ene = Instantiate(enemy2Perfab, enemyManager.enemyPerfabList[0].transform.position, Quaternion.identity);
            Destroy(enemyManager.enemyPerfabList[0].gameObject);
            enemyManager.enemyPerfabList.RemoveAt(0);
        }
    }
}
