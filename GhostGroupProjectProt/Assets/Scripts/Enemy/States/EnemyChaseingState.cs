using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseingState : EnemyBaseState
{
    GameObject _player;

    

    public EnemyChaseingState(EnemyStateMachine stateMachine, GameObject player) : base(stateMachine)
    {
        _player = player;
    }
    public override void Enter()
    {
        _stateMachine.CurrentState = EnemyStates.Chaseing;

        _stateMachine.Image.sprite = _stateMachine.Textures[3];

        //_stateMachine.Agent.speed = 10f;
    }
    public override void Tick(float deltaTime)
    {
        MoveToDestenation(_player.transform.position, _stateMachine.ChaseingSpeed);

        if (!_player.GetComponent<PlayerStatus>().IsVulnarable)
        {
            _stateMachine.SwitchState(new EnemyMovingState(_stateMachine, _stateMachine.GetNextWorkPosition()));
        }
    }
    public override void Exit()
    {

    }
}
