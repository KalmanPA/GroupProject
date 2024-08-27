using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AbilityType
{
    Fog,
    Mother,
    Fish,
    Trap
}

public class AbilitySystem : MonoBehaviour
{
    public static AbilityType CurrentAbility { get; private set; }

    public static void StartOfAbility(Vector3 pos)
    {

    }
    public static void EndOfAbility(Vector3 pos)
    {

    }

    private void Start()
    {
        InputReader.AbilityOneEvent += InputReader_AbilityOneEvent;
        InputReader.AbilityTwoEvent += InputReader_AbilityTwoEvent;
        InputReader.AbilityThreeEvent += InputReader_AbilityThreeEvent;
        InputReader.AbilityFourEvent += InputReader_AbilityFourEvent;

        CurrentAbility = AbilityType.Fog;
    }

    private void OnDisable()
    {
        InputReader.AbilityOneEvent -= InputReader_AbilityOneEvent;
        InputReader.AbilityTwoEvent -= InputReader_AbilityTwoEvent;
        InputReader.AbilityThreeEvent -= InputReader_AbilityThreeEvent;
        InputReader.AbilityFourEvent -= InputReader_AbilityFourEvent;
    }

    private void InputReader_AbilityFourEvent()
    {
        CurrentAbility = AbilityType.Trap;
    }

    private void InputReader_AbilityThreeEvent()
    {
        CurrentAbility = AbilityType.Fish;
    }

    private void InputReader_AbilityTwoEvent()
    {
        CurrentAbility = AbilityType.Mother;
    }

    private void InputReader_AbilityOneEvent()
    {
        CurrentAbility = AbilityType.Fog;
    }
}
