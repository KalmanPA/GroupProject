using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Static variables")]
    [Tooltip("These variables are in charge of the levels progress knowledge")]
    private static float percentage;

    [Header("Debug")]
    [SerializeField] private GameObject debugText;

    // Static property for Percentage
    public static float Percentage
    {
        get { return percentage; }
        set
        {
            percentage = Mathf.Clamp01(value); // Clamping the value between 0 and 1
            if (Instance != null) // Ensure that the instance exists
            {
                Instance.HandleDebugText(); // Call the instance method
            }
        }
    }

    // Singleton instance
    public static LevelManager Instance { get; private set; }

    private void Awake()
    {
        // Ensure that there's only one instance of LevelManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Method to handle the debugText based on the percentage
    private void HandleDebugText()
    {
        if (debugText != null)
        {
            debugText.SetActive(percentage >= 0.99f);
        }
    }
}
