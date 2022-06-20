using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    private bool isGrounded;
    private int Xinput;
    private bool jumpInput;
    private bool jumpInputStop;
    private bool coyTime;
    private bool isJumps;
    public PlayerInAirState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
    }

    public override void DoCheckState()
    {
        base.DoCheckState();
        isGrounded = players.CheckTouchGround();
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
        CheckCoyTime();
        Xinput = players.InputHandler.NormInputX;
        jumpInput = players.InputHandler.JumpInput;
        jumpInputStop = players.InputHandler.JumpInputStop;
        ChecksJumpMultipier();
        if (isGrounded && players.curVelo.y < 0.01f)
        {
            playerStateMachine.ChangeState(players.LandState);
        }
        else if(jumpInput && players.JumpState.CanJump())
        {
            playerStateMachine.ChangeState(players.JumpState);
        }
        else
        {
            players.CheckFlip(Xinput);
            players.SetVeloX(playerData.moveVelo * Xinput);
            players.Anim.SetFloat("yVelocity", players.curVelo.y);
            players.Anim.SetFloat("xVelocity", Mathf.Abs(players.curVelo.x));
        }
    }
    private void ChecksJumpMultipier()
    {
        if (isJumps)
        {
            if (jumpInputStop)
            {
                players.SetVeloY(players.curVelo.y * playerData.varJumpHeightMultipier);
                isJumps = false;
            }
            else if (players.curVelo.y <= 0f)
            {
                isJumps = false;
            }
        }
    }
    public override void PhysicsUpdateState()
    {
        base.PhysicsUpdateState();
    }
    private void CheckCoyTime()
    {
        if (coyTime && Time.time > onStartTimes + playerData.coyTime)
        {
            coyTime = false;
            players.JumpState.DownTotalJumpLeft();
        }
    }
    public void StartCoyTime() => coyTime = true;
    public void SetIsJumps() => isJumps = true;
}
