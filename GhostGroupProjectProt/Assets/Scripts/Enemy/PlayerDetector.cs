using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] EnemyStateMachine _enemyStateMachine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemyStateMachine.PlayerDetected(other.gameObject);
            //if (other.gameObject.GetComponent<PlayerStatus>().IsVulnarable)
            //{
            //    _enemyStateMachine.PlayerDetected(other.gameObject);
            //}
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemyStateMachine.PlayerDetected(other.gameObject);
            //if (other.gameObject.GetComponent<PlayerStatus>().IsVulnarable)
            //{
            //    _enemyStateMachine.PlayerDetected(other.gameObject);
            //}
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = Color.red;
    //    Gizmos.DrawWireSphere(transform.position, 5);
    //}
}
