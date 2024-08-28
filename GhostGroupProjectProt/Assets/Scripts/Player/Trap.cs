using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [Header("Sound settings")]
    [SerializeField] private float _soundDelay;
    private void Start()
    {
        StartCoroutine(PlayAfterDelay(_soundDelay));
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<EnemyStateMachine>().ScareEnemy();

            gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        AudioManager.Instance.Play("LemonStop");
    }

    private IEnumerator PlayAfterDelay(float delay)
    {
        // Wait for the specified amount of time
        yield return new WaitForSeconds(delay);
        AudioManager.Instance.Play("LemonStart");
    }
}
