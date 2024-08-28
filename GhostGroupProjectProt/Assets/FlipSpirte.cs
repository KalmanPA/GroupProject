using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlipSpirte : MonoBehaviour
{

    [Header("Input Settings")]
    [SerializeField] private InputActionReference moveAction;
    [SerializeField] private GameObject _toRotate;

    private bool isFacingRight = true;

    private void OnEnable()
    {
        // Enable the input action
        moveAction.action.Enable();

        // Subscribe to the input action
        moveAction.action.performed += OnMovePerformed;
    }

    private void OnDisable()
    {
        // Unsubscribe from the input action
        moveAction.action.performed -= OnMovePerformed;

        // Disable the input action
        moveAction.action.Disable();
    }

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        Vector2 moveInput = context.ReadValue<Vector2>();

        // Check if the input direction requires a flip
        if (moveInput.x > 0 && !isFacingRight)
        {
            FlipCharacterRight();
        }
        else if (moveInput.x < 0 && isFacingRight)
        {
            FlipCharacterLeft();
        }
    }

    private void FlipCharacterRight()
    {
        isFacingRight = true;

        // Animate the flip using DOTween
        _toRotate.transform.DORotate(new Vector3(0, 0, 0), 0.3f).SetEase(Ease.InOutSine);
    }

    private void FlipCharacterLeft()
    {
        isFacingRight = false;

        // Animate the flip using DOTween
        _toRotate.transform.DORotate(new Vector3(0, 180, 0), 0.3f).SetEase(Ease.InOutSine);
    }
}
