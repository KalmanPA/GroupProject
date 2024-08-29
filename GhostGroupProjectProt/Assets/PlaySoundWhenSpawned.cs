using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundWhenSpawned : MonoBehaviour
{
    [SerializeField] private float _destroyDelay;

    void Start()
    {
        AudioManager.Instance.Play("Splash");
    }

    // Update is called once per frame
    void Update()
    {
        if(_destroyDelay >= 0)
        {
            _destroyDelay -= Time.deltaTime;

        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
