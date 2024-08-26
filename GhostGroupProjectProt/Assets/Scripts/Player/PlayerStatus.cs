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
    }

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
    }
}
