using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorDetector : MonoBehaviour
{
    [SerializeField] EnemyStateMachine _stateMachine;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Door"))
        {
            Door door = other.gameObject.GetComponent<Door>();

            if (!door.IsDoorOpen)
            {
                _stateMachine.BumpedIntoClosedDoor(door);
            }
            
        }
    }
}
