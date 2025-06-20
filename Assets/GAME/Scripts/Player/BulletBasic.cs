using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    [Header("Bullet Basic")]
    [SerializeField] private float speedBullet = 10f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float maxDistace = 15f;
    [SerializeField] private GameObject bulletPerfab;
    // /////////////////////////////
    private Rigidbody2D rg;
    private float posStart;
    private Vector3 movement;

    void Start()
    {
        rg= this.GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        MoveBullet();
    }
    private void MoveBullet()
    {
        this.transform.Translate(movement* speedBullet * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    private float GetDamageBullet()
    {
        return damage;
    }
}
