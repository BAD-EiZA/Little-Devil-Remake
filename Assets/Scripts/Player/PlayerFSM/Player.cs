﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine PlayerFSM { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public Animator Anim { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody2D rb { get; private set; }
    public Vector2 curVelo { get; private set; }
    [SerializeField]
    private PlayerData playerData;

    private Vector2 workspace;
    private void Awake()
    {
        PlayerFSM = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this, PlayerFSM, playerData, "Idle");
        MoveState = new PlayerMoveState(this, PlayerFSM, playerData, "Move");
    }
    private void Start()
    {
        Anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        InputHandler = GetComponent<PlayerInputHandler>();
        PlayerFSM.Init(IdleState);
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
}
