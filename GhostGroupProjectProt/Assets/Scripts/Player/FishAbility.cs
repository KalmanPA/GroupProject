using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAbility : MonoBehaviour
{
    [SerializeField] GameObject _fishPrefab;
    [SerializeField] PlayerStatus _playerStatus;

    private void Start()
    {
        InputReader.AbilityThreeEvent += InputReader_AbilityThreeEvent;
    }

    private void InputReader_AbilityThreeEvent()
    {
        if (AbilitySystem.IsAbilityThreeActive())
        {
            Instantiate(_fishPrefab, transform.position, Quaternion.identity);

            _playerStatus.IsVulnarable = true;
        }
    }

    private void OnDisable()
    {
        InputReader.AbilityThreeEvent -= InputReader_AbilityThreeEvent;
    }
}
