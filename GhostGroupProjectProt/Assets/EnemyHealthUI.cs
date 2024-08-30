using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthUI : MonoBehaviour
{
    public EnemyStateMachine Enemy;
    public Slider Slider;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Slider>().value = gameObject.GetComponent<Slider>().maxValue - Enemy.MentalHealth;
    }
}
