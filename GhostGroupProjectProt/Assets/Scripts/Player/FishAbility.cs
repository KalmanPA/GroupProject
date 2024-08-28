using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAbility : MonoBehaviour
{
    [SerializeField] GameObject _fishPrefab;
    [SerializeField] PlayerStatus _playerStatus;

    private void Start()
    {
        InputReader.AbilityOneEvent += InputReader_AbilityOneEvent;
    }

    private void InputReader_AbilityOneEvent()
    {
        if (AbilitySystem.IsAbilityOneActive())
        {
            Instantiate(_fishPrefab, transform.position, Quaternion.identity);

            _playerStatus.IsVulnarable = true;
        }
    }

    private void OnDisable()
    {
        InputReader.AbilityOneEvent -= InputReader_AbilityOneEvent;
    }
}
