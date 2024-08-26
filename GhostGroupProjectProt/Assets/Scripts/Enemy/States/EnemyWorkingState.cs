using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWorkingState : EnemyBaseState
{
    float _duration = 3f;
    public EnemyWorkingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {
    }

    public override void Enter()
    {
        _stateMachine.Image.sprite = _stateMachine.Textures[2];
    }
    public override void Tick(float deltaTime)
    {
        _duration -= deltaTime;

        if (_duration <= 0)
        {
            _stateMachine.SwitchState(new EnemyMovingState(_stateMachine, _stateMachine.GetNextWorkPosition()));
        }
    }
    public override void Exit()
    {

    }
}
