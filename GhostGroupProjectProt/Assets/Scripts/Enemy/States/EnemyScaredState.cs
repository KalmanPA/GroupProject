using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaredState : EnemyBaseState
{
    //private List<EnemyStateMachine> enemyStateMachines = new List<EnemyStateMachine>();

    float _duration = 4f;

    Vector3 _randomPos;
    public EnemyScaredState(EnemyStateMachine stateMachine, Vector3 randomPos) : base(stateMachine)
    {
        _randomPos = randomPos;
    }

    public override void Enter()
    {
        _stateMachine.CurrentState = EnemyStates.Scared;

        _stateMachine.Agent.isStopped = false;
        _stateMachine.Agent.speed = 6f;

        _stateMachine.Image.sprite = _stateMachine.Textures[1];

        Scream();

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

    private void Scream()
    {
        // Clear the list to ensure no duplicate entries
        //enemyStateMachines.Clear();

        // Get all colliders within the detection radius
        Collider[] collidersInRange = Physics.OverlapSphere(_stateMachine.transform.position, 100f);

        // Iterate over all colliders
        foreach (Collider collider in collidersInRange)
        {
            // Check if the collider's GameObject has the enemy tag
            if (collider.CompareTag("Enemy"))
            {
                // Try to get the EnemyStateMachine component on the GameObject
                EnemyStateMachine enemyStateMachine = collider.GetComponent<EnemyStateMachine>();

                // If the component exists, add it to the list
                if (enemyStateMachine != null && enemyStateMachine != _stateMachine)
                {
                    //enemyStateMachines.Add(enemyStateMachine);
                    enemyStateMachine.HearScream(_stateMachine.transform.position);
                }
            }
        }
    }
}
