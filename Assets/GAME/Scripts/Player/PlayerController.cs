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

    private bool _isShoot = false;
    public bool IsShoot => _isShoot;
    private AnimController anim;
    private bool isGround;
    [Header("---Player Move Info---")]
    [SerializeField] private float Speed = 10f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private int numberJumpMax = 2;
    [SerializeField] private Transform pointCheckGround;
    [SerializeField] private LayerMask layerGround;
    private int tempNumberJump = 1;
    private Rigidbody2D rg;

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
        this.PlayerJump();
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
    void PlayerJump()
    {
        isGround = Physics2D.OverlapCircle(pointCheckGround.position, 0.1f, layerGround);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (tempNumberJump < numberJumpMax)
            {
                // this.rg.AddForce(new Vector2(this.rg.velocity.x, jumpForce));
                this.rg.velocity = new Vector2(this.rg.velocity.x, jumpForce);
                jumpForce += 20f;
                tempNumberJump++;
            }
            Debug.Log("So lan nhay:" + tempNumberJump);
        }
        if (isGround)
        {
            tempNumberJump = 1;
            jumpForce = 10f;
        }
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
