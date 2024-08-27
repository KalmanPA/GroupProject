using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public static Vector2 MovementValue { get; private set; }
    public static Vector2 AimValue { get; private set; }

    public static event Action AbilityOneEvent;
    public static event Action AbilityTwoEvent;
    public static event Action AbilityThreeEvent;
    public static event Action AbilityFourEvent;

    public static event Action UseAbilityEvent;

    public static event Action StartEvent;

    private Controls _controls;

    private void Awake()
    {
        _controls = new Controls();
        _controls.Player.SetCallbacks(this);

        //_controls.Player.Enable();
    }
    //private void Start()
    //{
    //    _controls = new Controls();
    //    _controls.Player.SetCallbacks(this);

    //    _controls.Player.Enable();
    //}

    private void OnDestroy()
    {
        if (_controls != null)
        {
            _controls.Player.Disable();
            _controls.Dispose();
        }

        // Clear all event subscribers to avoid null references and memory leaks
        AbilityOneEvent = null;
        AbilityTwoEvent = null;
        AbilityThreeEvent = null;
        AbilityFourEvent = null;
        UseAbilityEvent = null;
    }

    private void OnEnable()
    {
        _controls.Player.Enable();
    }

    private void OnDisable()
    {
        _controls.Player.Disable();
    }

    //private void OnDestroy()
    //{
    //    _controls.Player.Disable();
    //}

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

    public void OnAim(InputAction.CallbackContext context)
    {
        AimValue = context.ReadValue<Vector2>();
    }

    public void OnStart(InputAction.CallbackContext context)
    {
        if (!context.performed) return;

        StartEvent?.Invoke();
    }
}
