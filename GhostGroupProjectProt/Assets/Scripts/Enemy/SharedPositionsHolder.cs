using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SharedPositionsHolder : MonoBehaviour
{
    [SerializeField] Transform[] _randomPositions;

    [SerializeField] Transform _deathPosition;

    private static Transform _deathPos;

    private static Transform[] _randomPos;

    private void Start()
    {
        _deathPos = _deathPosition;

        _randomPos = new Transform[_randomPositions.Length];

        for (int i = 0; i < _randomPositions.Length; i++)
        {
            _randomPos[i] = _randomPositions[i];
        }
    }
    public static Vector3 GetScarePos()
    {
        int randomIndex = UnityEngine.Random.Range(0, _randomPos.Length);

        return _randomPos[randomIndex].position;
    }

    public static Vector3 GetDeathPos()
    {
        return _deathPos.position;
    }
}
