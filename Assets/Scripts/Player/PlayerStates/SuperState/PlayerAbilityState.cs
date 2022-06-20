using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool isAbilityDone;
    private bool isGround;
    public PlayerAbilityState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
    }

    public override void DoCheckState()
    {
        base.DoCheckState();
        isGround = players.CheckTouchGround();
    }

    public override void EnterState()
    {
        base.EnterState();
        isAbilityDone = false;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void LogicUpdateState()
    {
        base.LogicUpdateState();
        if (isAbilityDone)
        {
            if (isGround && players.curVelo.y < 0.01f)
            {
                playerStateMachine.ChangeState(players.IdleState);
            }
            else
            {
                playerStateMachine.ChangeState(players.InAirState);
            }
        }
    }

    public override void PhysicsUpdateState()
    {
        base.PhysicsUpdateState();
    }
}
