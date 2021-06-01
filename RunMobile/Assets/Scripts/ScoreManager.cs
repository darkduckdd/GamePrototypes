using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static  ScoreManager instance;
    public Text score;

    private int IntScore = 0;
    public int Score
    {
        set
        {
            IntScore += value;
            score.text = IntScore.ToString();
        }
        
    }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }else if(instance == this)
        {
            Destroy(gameObject);
        }

        score.text = IntScore.ToString();
    }
}
