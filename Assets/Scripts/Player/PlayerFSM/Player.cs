using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerStateMachine PlayerFSM { get; private set; }
    public Animator Anim { get; private set; }
    private void Awake()
    {
        PlayerFSM = new PlayerStateMachine();
    }
    private void Start()
    {
        Anim = GetComponent<Animator>();
        //init fsm
    }
    private void Update()
    {
        PlayerFSM.CurState.LogicUpdateState();
    }
    private void FixedUpdate()
    {
        PlayerFSM.CurState.PhysicsUpdateState();
    }
}
