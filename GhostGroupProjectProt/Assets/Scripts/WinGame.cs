using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField] GameObject[] _enemies;

    [SerializeField] GameObject _winScreen;

    // Update is called once per frame
    void Update()
    {

        foreach (GameObject enemy in _enemies)
        {
            if (enemy.activeSelf)
            {
                return;
            }
        }

        _winScreen.SetActive(true);
    }
}
