using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnviromentalObjectDetector : MonoBehaviour
{
    private IInteractable _selectedInteractable;

    private void Start()
    {
        InputReader.UseAbilityEvent += InputReader_UseAbilityEvent;
    }

    private void OnDisable()
    {
        InputReader.UseAbilityEvent -= InputReader_UseAbilityEvent;
    }

    private void InputReader_UseAbilityEvent()
    {
        if (_selectedInteractable == null) return;

        _selectedInteractable.Interact();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactableObject))
        {
            interactableObject.Selecet();

            _selectedInteractable = interactableObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent<IInteractable>(out IInteractable interactableObject))
        {
            interactableObject.DeSelecet();

            _selectedInteractable = null;
        }
    }
}
