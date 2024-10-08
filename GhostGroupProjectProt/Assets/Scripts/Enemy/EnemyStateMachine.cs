using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
//using UnityEngine.UI;
//using UnityEngine.UIElements;

public class EnemyStateMachine : StateMachine
{
    public bool IsPatrolling;

    public float MovingSpeed = 4f;
    public float ScaredSpeed = 6f;
    public float InvestigatingSpeed = 6f;
    public float ChaseingSpeed = 10f;
    public float DeathSpeed = 10f;
    public float WorkProgressAmmount = 2f;

    public CharacterController CharacterController;

    [SerializeField] Transform[] _workPositions;

    public int MentalHealth = 3;

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

    public Transform GetCurrentWorkPosition()
    {
        //_workPosIndex++;

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
        if (CurrentState == EnemyStates.Chasing) return;
        if (CurrentState == EnemyStates.Unlocking) return;

        if (player.GetComponent<PlayerStatus>().IsVulnarable || IsPatrolling)
        {
            SwitchState(new EnemyChasingState(this, player));
        }

        
    }

    public void BumpedIntoClosedDoor(Door door)
    {
        if (CurrentState == EnemyStates.Scared) return;
        if (CurrentState == EnemyStates.Death) return;
        if (CurrentState == EnemyStates.Unlocking) return;

        //if (!door.IsDoorOpen)
        //{
        //    SwitchState(new EnemyUnlockingState(this, door));
        //}


    }

    public void HearScream(Vector3 screamLocation)
    {
        if (CurrentState == EnemyStates.Scared) return;
        if (CurrentState == EnemyStates.Death) return;
        if (CurrentState == EnemyStates.Chasing) return;
        if (CurrentState == EnemyStates.Unlocking) return;

        SwitchState(new EnemyInvestigatingState(this, screamLocation));
    }

    public void ScareEnemy()
    {
        if (CurrentState == EnemyStates.Scared) return;
        if (CurrentState == EnemyStates.Death) return;

        MentalHealth--;

        if (MentalHealth <= 0)
        {
            SwitchState(new EnemyDeathState(this, SharedPositionsHolder.GetDeathPos()));
        }
        else
        {
            SwitchState(new EnemyScaredState(this, SharedPositionsHolder.GetScarePos()));
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    Debug.Log("Clo detect");

    //    if (collision.gameObject.CompareTag("Door"))
    //    {
    //        BumpedIntoClosedDoor(collision.gameObject.GetComponent<Door>());
    //    }
    //}
}
