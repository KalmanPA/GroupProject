using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapAbility : MonoBehaviour
{
    [SerializeField] PlayerStatus _playerStatus;
    [SerializeField] GameObject _trap;
    // Start is called before the first frame update
    void Start()
    {
        InputReader.AbilityFourEvent += InputReader_AbilityFourEvent;
    }

    private void InputReader_AbilityFourEvent()
    {
        if (AbilitySystem.IsAbilityFourActive())
        {
            Instantiate(_trap, transform.position, Quaternion.identity);

            _playerStatus.IsVulnarable = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnDisable()
    {
        InputReader.UseAbilityEvent -= InputReader_AbilityFourEvent;
    }
}
