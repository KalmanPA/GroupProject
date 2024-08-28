using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;

    public static int PlayerHealth;

    private void Update()
    {
        _text.text = PlayerHealth.ToString();
    }
}
