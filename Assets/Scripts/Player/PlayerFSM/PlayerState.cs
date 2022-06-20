using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player players;
    protected PlayerStateMachine playerStateMachine;
    protected PlayerData playerData;
    protected bool isAnimFinish;
    private string animatorBoolName;
    protected float onStartTimes;
    public PlayerState(Player players, PlayerStateMachine playerStateMachine, PlayerData playerData, string animatorBoolName)
    {
        this.players = players;
        this.playerStateMachine = playerStateMachine;
        this.playerData = playerData;
        this.animatorBoolName = animatorBoolName;
    }
    public virtual void EnterState()
    {
        DoCheckState();
        onStartTimes = Time.time;
        players.Anim.SetBool(animatorBoolName, true);
        isAnimFinish = false;
    }
    public virtual void ExitState()
    {
        players.Anim.SetBool(animatorBoolName, false);
    }
    public virtual void LogicUpdateState()
    {

    }
    public virtual void PhysicsUpdateState()
    {
        DoCheckState();
    }
    public virtual void DoCheckState()
    {
        
    }
    public virtual void AnimTrigger() { }
    public virtual void AnimFinishTrigger() => isAnimFinish = true;
}
