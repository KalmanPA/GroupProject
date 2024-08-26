using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInvestigatingState : EnemyBaseState
{
    Vector3 _investigationPosition;

    float _duration = 6f;
    public EnemyInvestigatingState(EnemyStateMachine stateMachine, Vector3 investigationPosition) : base(stateMachine)
    {
        _investigationPosition = investigationPosition;
    }

    public override void Enter()
    {
        _stateMachine.CurrentState = EnemyStates.Investigating;

        _stateMachine.Image.sprite = _stateMachine.Textures[4];

        _stateMachine.Agent.speed = 6f;
    }
    public override void Tick(float deltaTime)
    {
        _duration -= deltaTime;

        if (_duration < 0)
        {
            _stateMachine.SwitchState(new EnemyMovingState(_stateMachine, _stateMachine.GetNextWorkPosition()));
        }

        MoveToDestenation(_investigationPosition);
    }

    public override void Exit()
    {

    }
}
