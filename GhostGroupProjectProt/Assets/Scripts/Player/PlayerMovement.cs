using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] CharacterController _characterController;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(CalculateMovement() * 5, Time.deltaTime);

        FaceMovementDirection(CalculateMovement(), Time.deltaTime);
    }
    private void Move(Vector3 motion, float deltaTime)
    {
        _characterController.Move(motion * deltaTime);
    }

    private Vector3 CalculateMovement()
    {
        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        forward.Normalize();
        right.Normalize();

        return forward * Input.GetAxis("Vertical") + right * Input.GetAxis("Horizontal");
    }

    private void FaceMovementDirection(Vector3 movement, float deltaTime)
    {
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation(movement),
            deltaTime * 12);
    }
}
