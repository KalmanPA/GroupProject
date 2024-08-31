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

    protected void MoveToDestenation(Vector3 pos, float speed)
    {
        //_stateMachine.Agent.SetDestination(pos);
        _stateMachine.Agent.destination = pos;

        Move(_stateMachine.Agent.desiredVelocity.normalized * speed, Time.deltaTime);
    }

    protected void Move(float deltaTime)
    {
        Move(Vector3.zero, deltaTime);
    }

    protected void Move(Vector3 motion, float deltaTime)
    {
        if (!_stateMachine.CharacterController.enabled) return;

        _stateMachine.CharacterController.Move((motion) * deltaTime);
    }

    protected void Scream()
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

    //private void MoveToPlayer(float deltaTime)
    //{
    //    if (_stateMachine.Agent.isOnNavMesh)// It chekc if the enemy is able to move
    //    {
    //        _stateMachine.Agent.destination = _stateMachine.Player.transform.position;//We give the agent the destination

    //        Move(_stateMachine.Agent.desiredVelocity.normalized * _stateMachine.MovementSpeed, deltaTime);// We get the velocty the agent wants but we normalise it and apply our own speed
    //    }

    //    _stateMachine.Agent.velocity = _stateMachine.CharacterController.velocity;// Need to update the velocity of the Agent in case we did not move how it inteended
    //}
}
