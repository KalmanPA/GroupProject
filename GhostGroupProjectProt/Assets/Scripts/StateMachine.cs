using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachine : MonoBehaviour
{
    private State _currentState;

    public void SwitchState(State nextState)
    {
        _currentState?.Exit();

        _currentState = nextState;

        _currentState?.Enter();

        //_currentState?.Tick(Time.deltaTime);
    }

    private void Update()
    {
        //if (_currentState == null) return;
        _currentState?.Tick(Time.deltaTime);
    }
}
