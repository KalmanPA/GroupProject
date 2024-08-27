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
    public static float AbilityOneDuration = 5f;
    public static float AbilityTwoDuration = 5f;
    public static float AbilityThreeDuration = 5f;
    public static float AbilityFourDuration = 5f;

    public static float _oneDuration;
    public static float _twoDuration;
    public static float _threeDuration;
    public static float _fourDuration;

    static bool _isAbilityOneActive = true;
    static bool _isAbilityTwoActive = true;
    static bool _isAbilityThreeActive = true;
    static bool _isAbilityFourActive = true;

    static int _AbilityOneUsage = 2;
    static int _AbilityTwoUsage = 2;
    static int _AbilityThreeUsage = 2;
    static int _AbilityFourUsage = 2;

    private void Start()
    {
        _oneDuration = AbilityOneDuration;
        _twoDuration = AbilityTwoDuration;
        _threeDuration = AbilityThreeDuration;
        _fourDuration = AbilityFourDuration;

        _isAbilityOneActive = true;
        _isAbilityTwoActive = true;
        _isAbilityThreeActive = true;
        _isAbilityFourActive = true;

        _AbilityOneUsage = 2;
        _AbilityTwoUsage = 2;
        _AbilityThreeUsage = 2;
        _AbilityFourUsage = 2;
    }

    public static void ResetAbilities()
    {
        _AbilityOneUsage = 2;
        _AbilityTwoUsage = 2;
        _AbilityThreeUsage = 2;
        _AbilityFourUsage = 2;
    }
    public static bool IsAbilityOneActive()
    {
        if (_AbilityOneUsage <= 0) return false;

        if (_isAbilityOneActive)
        {
            _isAbilityOneActive = false;

            _AbilityOneUsage--;

            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsAbilityTwoActive()
    {
        if (_AbilityTwoUsage <= 0) return false;

        if (_isAbilityTwoActive)
        {
            _isAbilityTwoActive = false;

            _AbilityTwoUsage--;

            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsAbilityThreeActive()
    {
        if (_AbilityThreeUsage <= 0) return false;

        if (_isAbilityThreeActive)
        {
            _isAbilityThreeActive = false;

            _AbilityThreeUsage--;

            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool IsAbilityFourActive()
    {
        if (_AbilityFourUsage <= 0) return false;

        if (_isAbilityFourActive)
        {
            _isAbilityFourActive = false;

            _AbilityFourUsage--;

            return true;
        }
        else
        {
            return false;
        }
    }
    private void Update()
    {
        if (!_isAbilityOneActive)
        {
            _oneDuration -= Time.deltaTime;

            if (_oneDuration <= 0)
            {
                _oneDuration = AbilityOneDuration;

                _isAbilityOneActive = true;
            }
        }

        if (!_isAbilityTwoActive)
        {
            _twoDuration -= Time.deltaTime;

            if (_twoDuration <= 0)
            {
                _twoDuration = AbilityTwoDuration;

                _isAbilityTwoActive = true;
            }
        }

        if (!_isAbilityThreeActive)
        {
            _threeDuration -= Time.deltaTime;

            if (_threeDuration <= 0)
            {
                _threeDuration = AbilityThreeDuration;

                _isAbilityThreeActive = true;
            }
        }

        if (!_isAbilityFourActive)
        {
            _fourDuration -= Time.deltaTime;

            if (_fourDuration <= 0)
            {
                _fourDuration = AbilityFourDuration;

                _isAbilityFourActive = true;
            }
        }
    }

    //public static AbilityType CurrentAbility { get; private set; }

    //public static void StartOfAbility(Vector3 pos)
    //{

    //}
    //public static void EndOfAbility(Vector3 pos)
    //{

    //}

    //private void Start()
    //{
    //    InputReader.AbilityOneEvent += InputReader_AbilityOneEvent;
    //    InputReader.AbilityTwoEvent += InputReader_AbilityTwoEvent;
    //    InputReader.AbilityThreeEvent += InputReader_AbilityThreeEvent;
    //    InputReader.AbilityFourEvent += InputReader_AbilityFourEvent;

    //    CurrentAbility = AbilityType.Fog;
    //}

    //private void OnDisable()
    //{
    //    InputReader.AbilityOneEvent -= InputReader_AbilityOneEvent;
    //    InputReader.AbilityTwoEvent -= InputReader_AbilityTwoEvent;
    //    InputReader.AbilityThreeEvent -= InputReader_AbilityThreeEvent;
    //    InputReader.AbilityFourEvent -= InputReader_AbilityFourEvent;
    //}

    //private void InputReader_AbilityFourEvent()
    //{
    //    CurrentAbility = AbilityType.Trap;
    //}

    //private void InputReader_AbilityThreeEvent()
    //{
    //    CurrentAbility = AbilityType.Fish;
    //}

    //private void InputReader_AbilityTwoEvent()
    //{
    //    CurrentAbility = AbilityType.Mother;
    //}

    //private void InputReader_AbilityOneEvent()
    //{
    //    CurrentAbility = AbilityType.Fog;
    //}
}
