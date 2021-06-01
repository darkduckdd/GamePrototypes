using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ScoreManager : MonoBehaviour
{
   
    private int _plumber;
    private static int  _score = 0;
    private static int _lastScore;
    public static int money;
    
    public static ScoreManager instance = null;

    public int GetScore
    {
        get
        {
            return _score;
        }
    }
    public int Plumber
    {
        set
        {
            if (value == 0)
            {
                _lastScore = _score;
                _score = 0;
                _plumber = 0;
            }
            else
            {
                _plumber += value;
                ScoreChanger();
            }
        }
    }
    private void Awake()
    {
        if (instance == null)
        { 
            instance = this; 
        }
        else if (instance == this)
        { 
            Destroy(gameObject); 
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        instance.Plumber = 0;
        if (PlayerPrefs.HasKey("moneys"))
        {
            money = PlayerPrefs.GetInt("moneys");
        }
        else
        {
            Debug.Log("Doesn't exist");
        }
    }

    private void ScoreChanger()
    {
        _score += _plumber;
    }

    public static void SaveMoney()
    {
        money += _lastScore;
        PlayerPrefs.SetInt("moneys", money);
        PlayerPrefs.Save();
    } 
}
