using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoScreen : MonoBehaviour
{
    private static bool _wasShownOnce = true;

    private bool _isPaused = true; // Track if the game is paused

    [SerializeField] private GameObject _infoScreen;

    private void Start()
    {
        InputReader.InfoEvent += InputReader_InfoEvent;

        _isPaused = _wasShownOnce;
        _infoScreen.SetActive(_wasShownOnce);

        if (_wasShownOnce)
        {
            PauseGame();
        }
    }

    private void InputReader_InfoEvent()
    {
        if (_isPaused)
        {
            ResumeGame();
            _infoScreen.SetActive(false);
            _wasShownOnce = false;
        }
        else
        {
            _infoScreen.SetActive(true);
            PauseGame();
        }
    }

    // Function to pause the game
    private void PauseGame()
    {
        Time.timeScale = 0;  // Set the time scale to 0 to pause the game
        _isPaused = true;     // Set the pause state to true
        // Optionally: Disable any UI elements or scripts that should not be active when paused
    }

    // Function to resume the game
    private void ResumeGame()
    {
        Time.timeScale = 1;  // Set the time scale to 1 to resume the game
        _isPaused = false;    // Set the pause state to false
        // Optionally: Re-enable any UI elements or scripts that were disabled
    }

    private void OnDisable()
    {
        InputReader.InfoEvent -= InputReader_InfoEvent;
    }
}
