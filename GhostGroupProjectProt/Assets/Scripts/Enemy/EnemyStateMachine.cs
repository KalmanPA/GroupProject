using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//using UnityEngine.UI;
//using UnityEngine.UIElements;

public class EnemyStateMachine : StateMachine
{
    [SerializeField] Transform[] _workPositions;

    [SerializeField] int _mentalHealth = 3;

    public Image Image;

    public Sprite[] Textures;

    public NavMeshAgent Agent;

    private int _workPosIndex = 0;

    public EnemyStates CurrentState;

    private void Start()
    {
        Agent.updateRotation = false;

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

    public void PlayerDetected(GameObject player)
    {
        if (CurrentState == EnemyStates.Scared) return;
        if (CurrentState == EnemyStates.Death) return;
        if (CurrentState == EnemyStates.Chaseing) return;

        SwitchState(new EnemyChaseingState(this, player));
    }

    public void HearScream(Vector3 screemLocation)
    {
        if (CurrentState == EnemyStates.Scared) return;
        if (CurrentState == EnemyStates.Death) return;
        if (CurrentState == EnemyStates.Chaseing) return;

        SwitchState(new EnemyInvestigatingState(this, screemLocation));
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
