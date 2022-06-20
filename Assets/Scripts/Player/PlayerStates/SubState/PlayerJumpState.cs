using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    private int totalJumpLeft;
    public PlayerJumpState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
        totalJumpLeft = playerData.totalJump;
    }

    public override void EnterState()
    {
        base.EnterState();
        players.SetVeloY(playerData.jumpVelo);
        isAbilityDone = true;
        totalJumpLeft--;
        players.InAirState.SetIsJumps();
    }
    public bool CanJump()
    {
        if(totalJumpLeft > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void ResetTotalJump() => totalJumpLeft = playerData.totalJump;
    public void DownTotalJumpLeft() => totalJumpLeft--;
}
