using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    float _duration = 8f;

    public bool IsVulnarable;

    [SerializeField] Image _image;

    [SerializeField] Sprite _normal;

    [SerializeField] Sprite _volnurable;

    private void Start()
    {
        _image.sprite = _normal;

        //InputReader.UseAbilityEvent += InputReader_UseAbilityEvent;
    }

    

    //private void OnDisable()
    //{
    //    InputReader.UseAbilityEvent -= InputReader_UseAbilityEvent;
    //}

    private void Update()
    {
        if (IsVulnarable)
        {
            _image.sprite = _volnurable;

            _duration -= Time.deltaTime;

            if (_duration <= 0)
            {
                _duration = 8f;

                IsVulnarable = false;

                _image.sprite = _normal;
            }
        }

        CheckForEnemiesAndHandleState();
    }

    void CheckForEnemiesAndHandleState()
    {
        // Find all colliders within the specified detection radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 1.5f);

        // Loop through all the colliders found
        foreach (Collider collider in hitColliders)
        {
            // Check if the collider has the tag "Enemy"
            if (collider.CompareTag("Enemy"))
            {
                // Check if the local boolean is true
                if (IsVulnarable)
                {
                    // Turn off the GameObject
                    gameObject.SetActive(false);
                    return; // Exit the method as the GameObject is now off
                }
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Enemy") && IsVulnarable)
    //    {
    //        gameObject.SetActive(false);
    //    }

    //}

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Enemy") && IsVulnarable)
    //    {
    //        gameObject.SetActive(false);
    //    }
    //}
}
