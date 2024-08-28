using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolingState : EnemyBaseState
{
    Vector3 _destination;
    public EnemyPatrolingState(EnemyStateMachine stateMachine, Vector3 destination) : base(stateMachine)
    {
        _destination = destination;
    }

    public override void Enter()
    {

    }
    public override void Tick(float deltaTime)
    {

    }
    public override void Exit()
    {

    }
}
