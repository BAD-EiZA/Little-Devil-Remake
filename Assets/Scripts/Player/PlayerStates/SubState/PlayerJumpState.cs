using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerAbilityState
{
    public PlayerJumpState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
    }

    public override void EnterState()
    {
        base.EnterState();
        players.SetVeloY(playerData.jumpVelo);
    }
}
