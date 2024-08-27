using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Room : MonoBehaviour
{
    private List<EnemyStateMachine> _enemies = new List<EnemyStateMachine>();

    [SerializeField] private GameObject _fogVisual;

    [SerializeField] private GameObject _selectVisual;

    bool _isFogActive;

    //bool _isMouseIn;

    float _fogDuration = 2f;

    bool _isPlayerInRoom;

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

        //if (_isMouseIn)
        //{
        //    if (Vector3.Distance(transform.position, _player.transform.position) < 10)
        //    {
        //        _selectVisual.SetActive(true);
        //    }
        //    else
        //    {
        //        _selectVisual.SetActive(false);
        //    }
        //}
        //else
        //{
        //    _selectVisual.SetActive(false);
        //}
    }
    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    //Debug.Log("ClickWorks");

    //    //if (!_isPlayerInRoom) return;

    //    if (Vector3.Distance(transform.position, _player.transform.position) < 15)
    //    {
    //        SummonFog();
    //    }

        
    //}

    private void SummonFog()
    {
        _player.GetComponent<PlayerStatus>().IsVulnarable = true;

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

        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerInRoom = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("removed");

            _enemies.Remove(other.gameObject.GetComponent<EnemyStateMachine>());
        }

        if (other.gameObject.CompareTag("Player"))
        {
            _isPlayerInRoom = false;
        }
    }

    //public void OnPointerEnter(PointerEventData eventData)
    //{
    //    _isMouseIn = true;
        
    //}

    //public void OnPointerExit(PointerEventData eventData)
    //{
    //    _isMouseIn = false;
    //}
}
