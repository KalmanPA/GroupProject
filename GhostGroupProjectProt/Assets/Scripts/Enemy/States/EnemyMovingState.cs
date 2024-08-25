using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovingState : EnemyBaseState
{
    Vector3 _destination;
    public EnemyMovingState(EnemyStateMachine stateMachine, Transform destination) : base(stateMachine)
    {
        _destination = destination.position;
    }

    public override void Enter()
    {
        _stateMachine.Agent.isStopped = false;

        _stateMachine.Agent.speed = 4f;

        
    }
    public override void Tick(float deltaTime)
    {
        //Debug.Log("InMoving");

        MoveToDestenation(_destination);

        CheckForReachingDestination();

        if (Input.GetKeyDown(KeyCode.Q))
        {
             _stateMachine.ScareEnemy();
        }
    }
    public override void Exit()
    {
        //Debug.Log("ExitMovingState");
    }

    private void CheckForReachingDestination()
    {
        if (Vector3.Distance(_stateMachine.transform.position, _destination) < 2.5f)
        {
            _stateMachine.Agent.isStopped = true;
            
            _stateMachine.SwitchState(new EnemyWorkingState(_stateMachine));
        }
    }
}
