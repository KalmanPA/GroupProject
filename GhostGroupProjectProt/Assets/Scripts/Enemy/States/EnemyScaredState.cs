using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaredState : EnemyBaseState
{
    float _duration = 4f;

    Vector3 _randomPos;
    public EnemyScaredState(EnemyStateMachine stateMachine, Vector3 randomPos) : base(stateMachine)
    {
        _randomPos = randomPos;
    }

    public override void Enter()
    {
        _stateMachine.Agent.isStopped = false;
        _stateMachine.Agent.speed = 6f;

        _stateMachine.Image.sprite = _stateMachine.Textures[1];

        //Debug.Log("Scared");
    }
    public override void Tick(float deltaTime)
    {
        _duration -= deltaTime;

        if (_duration < 0 )
        {
            _stateMachine.SwitchState(new EnemyMovingState(_stateMachine, _stateMachine.GetNextWorkPosition()));
        }

        MoveToDestenation(_randomPos);

        //if (_duration > 3f)
        //{
        //    MoveToDestenation(_randomPos);
        //}

        //if (_duration < 3f)
        //{
        //    MoveToDestenation(SharedPositionsHolder.GetScarePos());
        //}

        
    }

    public override void Exit()
    {
        _stateMachine.Agent.speed = 4f;
    }
}
