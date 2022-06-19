using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected Vector2 input;
    public PlayerGroundedState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
    }

    public override void DoCheckState()
    {
        base.DoCheckState();
    }

    public override void EnterState()
    {
        base.EnterState();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdateState()
    {
        base.LogicUpdateState();
        input = players.InputHandler.MoveInput;
    }

    public override void PhysicsUpdateState()
    {
        base.PhysicsUpdateState();
    }
}
