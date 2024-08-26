using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Room : MonoBehaviour, IPointerDownHandler
{
    private List<EnemyStateMachine> _enemies = new List<EnemyStateMachine>();

    [SerializeField] private GameObject _fogVisual;

    bool _isFogActive;

    float _fogDuration = 2f;

    //bool _isPlayerInRoom;

    GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (_isFogActive)
        {
            _fogDuration -= Time.deltaTime;

            if (_fogDuration <= 0)
            {
                _fogDuration = 3f;

                _isFogActive = false;

                _fogVisual.SetActive(false);
            }
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        //Debug.Log("ClickWorks");

        //if (!_isPlayerInRoom) return;

        if (Vector3.Distance(transform.position, _player.transform.position) < 10)
        {
            SummonFog();
        }

        
    }

    private void SummonFog()
    {
        _isFogActive = true;

        _fogVisual.SetActive(true);

        foreach (var enemie in _enemies)
        {
            enemie.ScareEnemy();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("EnemyEntered");

            if(_isFogActive)
            {
                other.gameObject.GetComponent<EnemyStateMachine>().ScareEnemy();

                //return;
            }
            else
            {
                _enemies.Add(other.gameObject.GetComponent<EnemyStateMachine>());
            }

            
        }

        //if (other.gameObject.CompareTag("Player"))
        //{
        //    _isPlayerInRoom = true;
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("removed");

            _enemies.Remove(other.gameObject.GetComponent<EnemyStateMachine>());
        }

        //if (other.gameObject.CompareTag("Player"))
        //{
        //    _isPlayerInRoom = false;
        //}
    }
}
