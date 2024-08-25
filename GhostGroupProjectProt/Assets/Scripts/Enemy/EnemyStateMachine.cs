using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] Transform[] _workPositions;

    [SerializeField] int _mentalHealth = 3;

    public NavMeshAgent Agent;

    private int _workPosIndex = 0;

    private void Start()
    {
        SwitchState(new EnemyMovingState(this, _workPositions[_workPosIndex]));
    }

    public Transform GetNextWorkPosition()
    {
        _workPosIndex++;

        if (_workPosIndex < _workPositions.Length)
        {
            return _workPositions[_workPosIndex];
        }
        else
        {
            _workPosIndex = 0;

            return _workPositions[_workPosIndex];
        }
    }

    public void ScareEnemy()
    {
        _mentalHealth--;

        if (_mentalHealth < 0)
        {
            SwitchState(new EnemyDeathState(this, SharedPositionsHolder.GetDeathPos()));
        }
        else
        {
            SwitchState(new EnemyScaredState(this, SharedPositionsHolder.GetScarePos()));
        }
    }
}
