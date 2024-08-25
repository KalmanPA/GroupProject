using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBaseState : State
{
    protected EnemyStateMachine _stateMachine;

    public EnemyBaseState(EnemyStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    protected void MoveToDestenation(Vector3 pos)
    {
        _stateMachine.Agent.SetDestination(pos);
    }
}
