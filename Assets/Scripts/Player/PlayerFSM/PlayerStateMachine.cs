using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurState { get; private set; }
    public void Init(PlayerState startState)
    {
        CurState = startState;
        CurState.EnterState();
    }
    public void ChangeState(PlayerState newState)
    {
        CurState.ExitState();
        CurState = newState;
        CurState.EnterState();
    }
}
