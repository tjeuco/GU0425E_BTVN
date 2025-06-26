using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    [SerializeField] BulletBasic bulletPerfab;
    [SerializeField] Transform pointShoot;
    [SerializeField] int maxBullet = 16;

    int currentBullet;
    PlayerController player;
    void Start()
    {
        currentBullet = maxBullet;
        player = GetComponentInParent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            PlayerShoot();
        }
    }
    void PlayerShoot()
    {
        if (bulletPerfab == null) return;
        BulletBasic b = Instantiate(bulletPerfab,pointShoot.position, Quaternion.identity);
        b.SetDirectionBullet((player.transform.localScale.x > 0 ? Vector3.right : Vector3.left));
    }
}
