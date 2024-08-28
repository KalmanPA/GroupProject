using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayBackgroundMusic : MonoBehaviour
{
    [SerializeField] private float _timeBeforeStart;
    void Start()
    {
        // Play the initial music immediately
        AudioManager.Instance.Play("AwakeMusic");

        // Start the coroutine to play the background ambience after a delay
        StartCoroutine(PlayBackgroundAmbienceAfterDelay(_timeBeforeStart));
    }

    private IEnumerator PlayBackgroundAmbienceAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);

        // Play the background ambience after the delay
        AudioManager.Instance.Play("BackgroundAmbience");
        AudioManager.Instance.Play("BackgroundMusic");
    }
}
