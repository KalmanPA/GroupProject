using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InputReader.StartEvent += InputReader_StartEvent;
    }

    private void InputReader_StartEvent()
    {
        //AbilitySystem.ResetAbilities();
        // Get the current active scene's name
        string currentSceneName = SceneManager.GetActiveScene().name;

        // Reload the scene using the scene name
        SceneManager.LoadScene(currentSceneName);
    }

    private void OnDisable()
    {
        InputReader.StartEvent -= InputReader_StartEvent;
    }
}
