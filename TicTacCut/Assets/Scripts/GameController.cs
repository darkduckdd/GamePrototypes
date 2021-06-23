using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public int whoseTurn;//0=x 1=o
    public int turnCount;
    public GameObject[] turnIcons;
    public Sprite[] playIcons;
    public Image[] tictactoeSpaces;
    public ItemSlot[] ItemSlots;
    [Header("Win elements")]
    public Text winnerText;
    public GameObject[] winningLines;
    [Header("Score Elements")]
    public int playerOneScore;
    public int playerTwoScore;
    public Text playerOneScoreText;
    public Text playerTwoScoreText;

    [SerializeField] private GameObject initializationObj;
    [SerializeField] private Canvas canvas;

    public List<GameObject> playerOneHands;
    public List<GameObject> playerTwoHands;

    private int[] solutions;
    private GameObject currentInisObj;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    void GameSetup()
    {
        whoseTurn = 0;
        turnCount = 0;
        turnIcons[0].SetActive(true);
        turnIcons[1].SetActive(false);
        for (int i = 0; i < tictactoeSpaces.Length; i++)
        {
            tictactoeSpaces[i].GetComponent<Image>().sprite = null;
        }

       
        GameObject objIns= Instantiate(initializationObj);
        objIns.transform.SetParent(canvas.transform,false);
        currentInisObj = objIns;
        objIns.GetComponent<RectTransform>().anchoredPosition = initializationObj.GetComponent<RectTransform>().anchoredPosition;
        objIns.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);
        if (objIns.CompareTag("checker")){
            for (int i = 0; i < objIns.transform.childCount / 2; i++)
            {
                playerOneHands.Add(objIns.transform.GetChild(i).gameObject);
                playerTwoHands.Add(objIns.transform.GetChild(i + 6).gameObject);
            }

            foreach (GameObject obj in playerTwoHands)
            {
                obj.SetActive(false);
            }
        }
        else {
            for (int i = 0; i < objIns.transform.childCount / 2; i++)
            {
                playerOneHands.Add(objIns.transform.GetChild(i).gameObject);
                playerTwoHands.Add(objIns.transform.GetChild(i + 9).gameObject);
            }

            foreach (GameObject obj in playerTwoHands)
            {
                obj.SetActive(false);
            }
        }

    }
    public void TicTacToe()
    {
        turnCount++;
        if (turnCount > 0)
        {
            WinnerCheck();
        }

        if (whoseTurn == 0)
        {
            whoseTurn = 1;
            turnIcons[0].SetActive(false);
            turnIcons[1].SetActive(true);
            foreach (GameObject obj in playerOneHands)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in playerTwoHands)
            {
                obj.SetActive(true);
            }
        }
        else
        {
            whoseTurn = 0;
            turnIcons[0].SetActive(true);
            turnIcons[1].SetActive(false);
            foreach (GameObject obj in playerTwoHands)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in playerOneHands)
            {
                obj.SetActive(true);
            }

        }
    }

    void WinnerCheck()
    {
        int s1 = (int)ItemSlots[0].GetPlayer + (int)ItemSlots[1].GetPlayer + (int)ItemSlots[2].GetPlayer;
        int s2 = (int)ItemSlots[3].GetPlayer + (int)ItemSlots[4].GetPlayer + (int)ItemSlots[5].GetPlayer;
        int s3 = (int)ItemSlots[6].GetPlayer + (int)ItemSlots[7].GetPlayer + (int)ItemSlots[8].GetPlayer;
        int s4 = (int)ItemSlots[0].GetPlayer + (int)ItemSlots[3].GetPlayer + (int)ItemSlots[6].GetPlayer;
        int s5 = (int)ItemSlots[1].GetPlayer + (int)ItemSlots[4].GetPlayer + (int)ItemSlots[7].GetPlayer;
        int s6 = (int)ItemSlots[2].GetPlayer + (int)ItemSlots[5].GetPlayer + (int)ItemSlots[8].GetPlayer;
        int s7 = (int)ItemSlots[0].GetPlayer + (int)ItemSlots[4].GetPlayer + (int)ItemSlots[8].GetPlayer;
        int s8 = (int)ItemSlots[2].GetPlayer + (int)ItemSlots[4].GetPlayer + (int)ItemSlots[6].GetPlayer;

        solutions = new int[] { s1, s2, s3, s4, s5, s6, s7, s8 };
        for (int i = 0; i < solutions.Length; i++)
        {
            if (solutions[i] == 3 * (whoseTurn + 1))
            {
                WinnerDisplay(i);
                return;
            }
        }
    }

    void WinnerDisplay(int indexIn)
    {
        winnerText.gameObject.SetActive(true);
        if (whoseTurn == 0)
        {
            playerOneScore++;
            playerTwoScoreText.text = playerOneScore.ToString();
            winnerText.text = "Player One Wins";
        }
        else if (whoseTurn == 1)
        {
            playerTwoScore++;
            playerTwoScoreText.text = playerTwoScore.ToString();
            winnerText.text = "Player Two Wins";
        }

        winningLines[indexIn].SetActive(true);
    }
    
    public void Rematch()
    {
        Destroy(currentInisObj);
        playerOneHands.Clear();
        playerTwoHands.Clear();
        GameSetup();
        for(int i = 0; i < winningLines.Length; i++)
        {
            winningLines[i].SetActive(false);
        }   
        foreach(ItemSlot item in ItemSlots)
        {
            item.ReSetup();
        }
     
    }

    public void Restart()
    {
        Rematch();
        playerOneScore = 0;
        playerTwoScore = 0;
        playerOneScoreText.text = "0";
        playerTwoScoreText.text = "0";
    }
}
