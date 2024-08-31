using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour,IInteractable
{
    public bool IsDoorOpen
    {
        get => _isDoorOpen; set
        {
            if (value == _isDoorOpen) return;

            ToggleDoor(value);

            _isDoorOpen = value;
        }
    }

    [SerializeField] bool _isClosedOnStart;

    public float UnlockTime = 3f;

    private bool _isDoorOpen = true;

    private Collider _collider;

    [SerializeField] private GameObject _selectVisual;

    [SerializeField] private GameObject _openedVisual;

    [SerializeField] private GameObject _closedVisual;

    private void Start()
    {
        _collider = GetComponent<Collider>();

        IsDoorOpen = !_isClosedOnStart;
    }
    private void ToggleDoor(bool isOpen)
    {
        _openedVisual.SetActive(isOpen);

        _closedVisual.SetActive(!isOpen);

        _collider.isTrigger = isOpen;

        _isDoorOpen = isOpen;
    }

    public void Interact()
    {
        if (IsDoorOpen)
        {
            IsDoorOpen = false;

        }
        else
        {
            IsDoorOpen = true;
        }
    }

    public void Selecet()
    {
        _selectVisual.SetActive(true);
    }

    public void DeSelecet()
    {
        _selectVisual.SetActive(false);
    }
}
