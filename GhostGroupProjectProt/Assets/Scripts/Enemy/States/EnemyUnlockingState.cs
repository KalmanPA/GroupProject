using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyUnlockingState : EnemyBaseState
{
    private Door _door;

    float _duration;
    public EnemyUnlockingState(EnemyStateMachine stateMachine, Door door) : base(stateMachine)
    {
        _door = door;
    }

    public override void Enter()
    {
        _duration = 3f;
        //Debug.Log("UnlockState");

        _stateMachine.Image.sprite = _stateMachine.Textures[1];

        _stateMachine.Agent.isStopped = true;

        _stateMachine.CurrentState = EnemyStates.Unlocking;
    }
    public override void Tick(float deltaTime)
    {
        //Debug.Log("asddasda");

        _duration -= deltaTime;

        if (_duration <= 0)
        {
            //_door.IsDoorOpen = true;
            _stateMachine.SwitchState(new EnemyMovingState(_stateMachine, _stateMachine.GetCurrentWorkPosition()));
        }
    }
    public override void Exit()
    {
        _door.IsDoorOpen = true;
    }
}
