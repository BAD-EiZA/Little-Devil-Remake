using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirState : PlayerState
{
    public PlayerInAirState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
    }
}
