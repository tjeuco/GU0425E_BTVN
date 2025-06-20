using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    private Vector3 pos;
    void Start()
    {
        pos.x = Random.Range(-8, 8);
        pos.y = Random.Range(-8, 8);
        this.transform.position = pos;
    }
}
