using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeathState : EnemyBaseState
{
    Vector3 _deathPos;
    public EnemyDeathState(EnemyStateMachine stateMachine, Vector3 deathPos) : base(stateMachine)
    {
        _deathPos = deathPos;
    }

    public override void Enter()
    {
        _stateMachine.CurrentState = EnemyStates.Death;

        _stateMachine.Image.sprite = _stateMachine.Textures[2];

        _stateMachine.Agent.isStopped = false;

        _stateMachine.Agent.speed = 8f;
    }
    public override void Tick(float deltaTime)
    {
        MoveToDestenation(_deathPos, 8f);
    }

    public override void Exit()
    {

    }
}
