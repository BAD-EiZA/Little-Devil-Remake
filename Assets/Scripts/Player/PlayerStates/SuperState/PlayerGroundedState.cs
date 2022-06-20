using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int Xinput;
    private bool JumpInput;
    private bool isGrounds;
    public PlayerGroundedState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
    }

    public override void DoCheckState()
    {
        base.DoCheckState();
        isGrounds = players.CheckTouchGround();
    }

    public override void EnterState()
    {
        base.EnterState();
        players.JumpState.ResetTotalJump();
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdateState()
    {
        base.LogicUpdateState();
        Xinput = players.InputHandler.NormInputX;
        JumpInput = players.InputHandler.JumpInput;
        if (JumpInput && players.JumpState.CanJump())
        {
            players.InputHandler.UseJumpInput();
            playerStateMachine.ChangeState(players.JumpState);
        }
        else if (!isGrounds)
        {
            players.InAirState.StartCoyTime();
            playerStateMachine.ChangeState(players.InAirState);
        }
    }

    public override void PhysicsUpdateState()
    {
        base.PhysicsUpdateState();
    }
}
