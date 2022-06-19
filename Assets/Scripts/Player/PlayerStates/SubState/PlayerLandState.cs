using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
    }
}
