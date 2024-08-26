using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseingState : EnemyBaseState
{
    public EnemyChaseingState(EnemyStateMachine stateMachine) : base(stateMachine)
    {

    }
    public override void Enter()
    {
        _stateMachine.CurrentState = EnemyStates.Chaseing;
    }
    public override void Tick(float deltaTime)
    {

    }
    public override void Exit()
    {

    }
}
