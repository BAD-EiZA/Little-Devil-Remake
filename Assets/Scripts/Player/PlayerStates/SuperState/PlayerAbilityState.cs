using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    public PlayerAbilityState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName) : base(players, playerStateMachine, playerData, animatorBoolName)
    {
    }
}
