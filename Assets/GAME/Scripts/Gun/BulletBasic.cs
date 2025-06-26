using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour
{
    [Header("Bullet Basic")]
    [SerializeField] private float speedBullet = 100f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private float maxDistace = 15f;
    [SerializeField] private GameObject ExplosionPerfab;
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
    public  void MoveBullet()
    {
        this.rg.velocity = movement * speedBullet;
        if (Mathf.Abs(this.transform.position.x - posStart) >= maxDistace)
        {
            DisableBullet();
        }
    }
    public  void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
    public float GetDamageBullet()
    {
        return damage;
    }
    public void SetDirectionBullet(Vector3 direction)
    {
        posStart = this.transform.position.x;
        movement = direction;
    }
    public void DisableBullet()
    {
        Destroy(this.gameObject);
    }
}
