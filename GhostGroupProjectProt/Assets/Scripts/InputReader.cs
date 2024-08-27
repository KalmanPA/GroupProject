using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public static Vector2 MovementValue { get; private set; }

    public static event Action AbilityOneEvent;
    public static event Action AbilityTwoEvent;
    public static event Action AbilityThreeEvent;
    public static event Action AbilityFourEvent;

    public static event Action UseAbilityEvent;

    private Controls _controls;

    private void Start()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);

        _controls.Player.Enable();
    }

    private void OnDestroy()
    {
        _controls.Player.Disable();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        MovementValue = context.ReadValue<Vector2>();
    }

    public void OnAbilityFour(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        AbilityFourEvent?.Invoke();
    }

    public void OnAbilityOne(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        AbilityOneEvent?.Invoke();
    }

    public void OnAbilityThree(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        AbilityThreeEvent?.Invoke();
    }

    public void OnAbilityTwo(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        AbilityTwoEvent?.Invoke();
    }

    public void OnUseAbility(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        UseAbilityEvent?.Invoke();
    }

    //private Vector3 CalculateMovement(float deltaTime)
    //{
    //    Vector3 movement = new Vector3();

    //    movement += _stateMachine.transform.right * _stateMachine.InputReader.MovementValue.x;

    //    movement += _stateMachine.transform.forward * _stateMachine.InputReader.MovementValue.y;


    //    return movement;
    //}
}
