using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PLAYER_STATE _playerState = PLAYER_STATE.IsIdle;
    public PLAYER_STATE PlayerState => _playerState;

    [SerializeField] bool _isShoot = false;
    public bool IsShoot => _isShoot;
    
    [SerializeField]
    AnimController anim;

    [SerializeField]
    float Speed = 10, jumpForce = 100;

    Rigidbody2D rg;

    public enum PLAYER_STATE
    {
        IsIdle = 0,
        IsRun = 1,
        IsJump = 2,
        IsShoot = 3
    }

    void Start()
    {
        this.anim = this.GetComponentInChildren<AnimController>();
        this.rg = this.GetComponent<Rigidbody2D>();       
    }

    void Update()
    {
        this.AutoDetectState();
        this.FlipPlayer();

        if (Input.GetKeyDown(KeyCode.Space))
            this.rg.AddForce(Vector2.up * jumpForce);

        this._isShoot = Input.GetKey(KeyCode.C);

        if (Input.GetKeyDown(KeyCode.Z))
        {
            this.anim.SetSpeed(0.2f);
            this.Speed = 2;
        }

        if (Input.GetKeyUp(KeyCode.Z))
        {
            this.anim.SetSpeed(1f);
             this.Speed = 10;
        }
    }
    void FlipPlayer()
    {
        float face = this.transform.localScale.x;
        if (Input.GetAxisRaw("Horizontal") != 0)
        {
            face = Input.GetAxisRaw("Horizontal");
        }

        this.transform.localScale = new Vector3(face, 1, 1);
    }
    void FixedUpdate()
    {
        Vector2 movement = this.rg.velocity;
        movement.x = Input.GetAxisRaw("Horizontal") * this.Speed;
        this.rg.velocity = movement;
    }

    void AutoDetectState()
    {
        if (this.rg.velocity.y != 0)
        {
            this._playerState = PLAYER_STATE.IsJump;
            return;
        }
        this._playerState = Math.Abs(this.rg.velocity.x) > 0.1f ? PLAYER_STATE.IsRun : PLAYER_STATE.IsIdle;
    }

}
