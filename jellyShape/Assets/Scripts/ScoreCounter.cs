using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _moneyText;
    void Start()
    {
        _currentScore.text = ScoreManager.instance.GetScore.ToString();
        _moneyText.text = ScoreManager.money.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        _currentScore.text = ScoreManager.instance.GetScore.ToString();
    }
}
