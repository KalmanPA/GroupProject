using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [Header("Static variables")]
    [Tooltip("These variables are in charge of the levels progress knowledge")]
    private static float percentage;

    [Header("UI Elements")]
    [SerializeField] private GameObject debugText;
    [SerializeField] private Slider slider;

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

        slider.value = 0;

        percentage = 0;
    }

    // Static property for Percentage
    public static float Percentage
    {
        get { return percentage; }
        set
        {
            percentage = Mathf.Clamp01(value); // Clamping the value between 0 and 1

            if (Instance != null) // Ensure that the instance exists
            {
                Instance.UpdateSlider(percentage); // Update the slider in the instance
                Instance.HandleDebugText(); // Call the instance method
            }
        }
    }

    // Method to update the slider
    private void UpdateSlider(float value)
    {
        if (slider != null)
        {
            slider.value = value;
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