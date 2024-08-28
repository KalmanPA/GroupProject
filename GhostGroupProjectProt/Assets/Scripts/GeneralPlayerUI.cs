using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class GeneralPlayerUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _healthText;

    [SerializeField] GameObject _leftGray;
    [SerializeField] TextMeshProUGUI _leftGrayText;

    [SerializeField] GameObject _toptGray;
    [SerializeField] TextMeshProUGUI _topGrayText;

    [SerializeField] GameObject _righttGray;
    [SerializeField] TextMeshProUGUI _rightGrayText;

    [SerializeField] GameObject _bottomGray;
    [SerializeField] TextMeshProUGUI _bottomGrayText;
    

    public static int PlayerHealth;

    public static bool IsAbilityOneActive;
    public static bool IsAbilityTwoActive;
    public static bool IsAbilityThreeActive;
    public static bool IsAbilityFourActive;

    //public void AbilityOneUseage(bool isActive)
    //{

    //}

    private void Update()
    {
        _healthText.text = PlayerHealth.ToString();
        
        _leftGrayText.text = System.Math.Round(AbilitySystem._oneDuration, 1).ToString() + " s";
        _topGrayText.text = System.Math.Round(AbilitySystem._twoDuration, 1).ToString() + " s";
        _rightGrayText.text = System.Math.Round(AbilitySystem._threeDuration, 1).ToString() + " s";
        _bottomGrayText.text = System.Math.Round(AbilitySystem._fourDuration, 1).ToString() + " s";

        _leftGray.SetActive(IsAbilityOneActive);
        _toptGray.SetActive(IsAbilityTwoActive);
        _righttGray.SetActive(IsAbilityThreeActive);
        _bottomGray.SetActive(IsAbilityFourActive);

        if (AbilitySystem._AbilityOneUsage <= 0)
        {
            _leftGrayText.gameObject.SetActive(false);
            _leftGray.SetActive(true);
        }

        if (AbilitySystem._AbilityTwoUsage <= 0)
        {
            _topGrayText.gameObject.SetActive(false);
            _toptGray.SetActive(true);
        }

        if (AbilitySystem._AbilityThreeUsage <= 0)
        {
            _rightGrayText.gameObject.SetActive(false);
            _righttGray.SetActive(true);
        }

        if (AbilitySystem._AbilityFourUsage <= 0)
        {
            _bottomGrayText.gameObject.SetActive(false);
            _bottomGray.SetActive(true);
        }
    }
}
