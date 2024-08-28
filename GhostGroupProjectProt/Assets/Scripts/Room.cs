using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Room : MonoBehaviour
{
    private List<EnemyStateMachine> _enemies = new List<EnemyStateMachine>();

    [SerializeField] private GameObject _motherPrefab;

    [SerializeField] private GameObject _fogVisual;

    [SerializeField] private GameObject _selectVisual;

    Vector3 _motherDir = Vector3.forward;

    bool _isFogActive;

    //bool _isMouseIn;

    float _fogDuration = 2f;

    bool _isPlayerInRoom;

    GameObject _player;

    private void Start()
    {
        _player = GameObject.FindWithTag("Player");

        //InputReader.UseAbilityEvent += InputReader_UseAbilityEvent;

        InputReader.AbilityFourEvent += InputReader_AbilityFourEvent;
        InputReader.AbilityThreeEvent += InputReader_AbilityThreeEvent; ;
    }

    private void InputReader_AbilityThreeEvent()
    {
        if (!_isPlayerInRoom) return;

        if (AbilitySystem.IsAbilityThreeActive())
        {
            SummonMother();
        }
    }

    private void InputReader_AbilityFourEvent()
    {
        if (!_isPlayerInRoom) return;

        if (AbilitySystem.IsAbilityFourActive())
        {
            SummonFog();
        }
    }

    //private void InputReader_UseAbilityEvent()
    //{
    //    if (!_isPlayerInRoom) return;

    //    if (AbilitySystem.CurrentAbility == AbilityType.Fog)
    //    {
    //        SummonFog();
    //    }

    //    if (AbilitySystem.CurrentAbility == AbilityType.Mother)
    //    {
    //        SummonMother();
    //    }

    //}

    

    private void Update()
    {
        //_motherDir = FindClosestTarget(InputReader.AimValue);

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

        //if (AbilitySystem.CurrentAbility != AbilityType.Fog)
        //{
        //    _selectVisual.SetActive(false);
        //}
        //else
        //{
        //    if (_isPlayerInRoom)
        //    {
        //        _selectVisual.SetActive(true);
        //    }
        //}

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

    private void SummonMother()
    {
        _player.GetComponent<PlayerStatus>().IsVulnarable = true;

        //_motherDir = FindClosestTarget(InputReader.AimValue);       

        Mother mom = Instantiate(_motherPrefab, transform.position, Quaternion.identity).GetComponent<Mother>();

        mom.Dir = _motherDir; 
    }

    public Vector3 FindClosestTarget(Vector2 vector)
    {
        // Define the target vectors
        Vector2[] targets = new Vector2[]
        {
            new Vector2(0, 1),   // Target vector (0, 1)
            new Vector2(0, -1),  // Target vector (0, -1)
            new Vector2(1, 0),   // Target vector (1, 0)
            new Vector2(-1, 0)   // Target vector (-1, 0)
        };

        // Initialize the closest vector and minimum distance
        Vector2 closestVector = targets[0];
        float minDistance = Vector2.Distance(vector, closestVector);

        // Loop through all target vectors to find the closest one
        foreach (Vector2 target in targets)
        {
            float distance = Vector2.Distance(vector, target);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestVector = target;
            }
        }

        if (closestVector == new Vector2(0, 1))
        {
            closestVector = Vector3.forward;
        }
        else if(closestVector == new Vector2(0, -1))
        {
            closestVector = -Vector3.forward;
        }
        else if (closestVector == new Vector2(1, 0))
        {
            closestVector = Vector3.right;
        }
        else if (closestVector == new Vector2(-1, 0))
        {
            closestVector = -Vector3.right;
        }


        return closestVector;
    }

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

            //if (AbilitySystem.CurrentAbility == AbilityType.Fog)
            //{
            //    _selectVisual.SetActive(true);
            //}
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

            _selectVisual.SetActive(false);
            
        }
    }

    private void OnDisable()
    {
        InputReader.AbilityFourEvent -= InputReader_AbilityFourEvent;
        InputReader.AbilityThreeEvent -= InputReader_AbilityThreeEvent;
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
