using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine PlayerFSM { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerJumpState JumpState { get; private set; }
    public PlayerInAirState InAirState { get; private set; }
    public PlayerLandState LandState { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Vector2 curVelo { get; private set; }
    public int FaceDirection { get; private set; }
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private PlayerData playerData;

    private Vector2 workspace;
    private void Awake()
    {
        PlayerFSM = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, PlayerFSM, playerData, "Idle");
        MoveState = new PlayerMoveState(this, PlayerFSM, playerData, "Move");
        JumpState = new PlayerJumpState(this, PlayerFSM, playerData, "InAir");
        InAirState = new PlayerInAirState(this, PlayerFSM, playerData, "InAir");
        LandState = new PlayerLandState(this, PlayerFSM, playerData, "Land");
    }
    private void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        PlayerFSM.Init(IdleState);
        FaceDirection = 1;
    }
    private void Update()
    {
        curVelo = rb.velocity;
        PlayerFSM.CurState.LogicUpdateState();
    }
    private void FixedUpdate()
    {
        PlayerFSM.CurState.PhysicsUpdateState();
    }
    public void SetVeloX(float velocity)
    {
        workspace.Set(velocity, curVelo.y);
        rb.velocity = workspace;
        curVelo = workspace;
    }
    public void SetVeloY(float velocity)
    {
        workspace.Set(curVelo.x, velocity);
        rb.velocity = workspace;
        curVelo = workspace;
    }
    public void CheckFlip(int Xinput)
    {
        if (Xinput != 0 && Xinput != FaceDirection)
        {
            Flip();
        }
    }
    public bool CheckTouchGround()
    {
        return Physics2D.OverlapCircle(groundCheck.position, playerData.groundCheckRadius, playerData.isThatGround);
    }
    private void AnimTriggers() => PlayerFSM.CurState.AnimTrigger();
    private void AnimFinishTriggers() => PlayerFSM.CurState.AnimFinishTrigger();
    public void Flip()
    {
        FaceDirection *= -1;
        transform.Rotate(0.0f, 180.0f, 0.0f);
    }
}
