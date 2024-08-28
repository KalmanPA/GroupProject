using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using VHierarchy.Libs;

public class PlayerStatus : MonoBehaviour
{
    float _duration = 8f;

    public int Health = 3;

    public bool IsVulnarable;

    [SerializeField] private GameObject _deathScreen;

    [SerializeField] Image _image;

    [SerializeField] Sprite _normal;

    [SerializeField] Sprite _volnurable;

    //[SerializeField] private InputAction _inputAction;

    private void Start()
    {
        _image.sprite = _normal;

        //InputReader.UseAbilityEvent += InputReader_UseAbilityEvent;
    }

    private void OnEnable()
    {
        
    }



    //private void OnDisable()
    //{
    //    InputReader.UseAbilityEvent -= InputReader_UseAbilityEvent;
    //}

    private void Update()
    {
        CheckForEnemiesAndHandleState();

        if (IsVulnarable)
        {
            _image.sprite = _volnurable;

            _duration -= Time.deltaTime;

            if (_duration <= 0)
            {
                BecomeNormal();
            }
        }

        
    }

    private void BecomeNormal()
    {
        _duration = 8f;

        IsVulnarable = false;

        _image.sprite = _normal;
    }

    void CheckForEnemiesAndHandleState()
    {
        // Find all colliders within the specified detection radius
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 2f);

        // Loop through all the colliders found
        foreach (Collider collider in hitColliders)
        {
            // Check if the collider has the tag "Enemy"
            if (collider.CompareTag("Enemy"))
            {

                // Check if the local boolean is true
                if (IsVulnarable && collider.gameObject.GetComponent<EnemyStateMachine>().CurrentState == EnemyStates.Chaseing)
                {
                    Health--;

                    BecomeNormal();

                    if (Health <= 0)
                    {
                        if (_deathScreen != null)
                        {
                            _deathScreen.SetActive(true);
                        }


                        // Turn off the GameObject
                        gameObject.SetActive(false);
                        //gameObject.Destroy();
                        //return; // Exit the method as the GameObject is now off
                    }


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
