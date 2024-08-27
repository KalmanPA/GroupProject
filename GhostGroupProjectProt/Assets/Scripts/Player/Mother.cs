using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mother : MonoBehaviour
{
    //public float Speed = 5f;
    //void Update()
    //{
    //    transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    //}

    public Vector3 Dir = Vector3.forward;

    public float speed = 8f;  // Speed of the movement
    private Rigidbody rb;     // Reference to the Rigidbody component

    void Start()
    {
        // Get the Rigidbody component attached to this GameObject
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Move the Rigidbody forward based on its local forward direction
        rb.MovePosition(rb.position + Dir * speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyStateMachine>().ScareEnemy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
    }
}
