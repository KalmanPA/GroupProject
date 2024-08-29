using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKillBox : MonoBehaviour
{
    [SerializeField] GameObject _splashPrefab;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.SetActive(false);

            Instantiate(_splashPrefab, transform.position, Quaternion.identity);
        }
    }
}
