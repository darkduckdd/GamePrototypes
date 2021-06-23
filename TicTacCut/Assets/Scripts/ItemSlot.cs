using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private TypeOfHands handsOfItemSlot = TypeOfHands.NONE;
    [SerializeField] private TypeOfPlayer playerOfItemSlot = TypeOfPlayer.NONE;
    [SerializeField] private TypeOfCheckers checkersOfItemSlot = TypeOfCheckers.NONE;

    [SerializeField] private int Remarked = 0;

    public TypeOfPlayer GetPlayer
    {
        get { return playerOfItemSlot; }
    }

    public void ReSetup()
    {
        handsOfItemSlot = TypeOfHands.NONE;
        playerOfItemSlot = TypeOfPlayer.NONE;
        checkersOfItemSlot = TypeOfCheckers.NONE;
        GetComponent<Image>().color = new Color(255, 255, 255, 0);
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            if (eventData.pointerDrag.GetComponent<DragDrop>().HandsOfDragDrop != TypeOfHands.NONE)
            {
                if (handsOfItemSlot == TypeOfHands.NONE && playerOfItemSlot == TypeOfPlayer.NONE)
                {
                    if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == TypeOfPlayer.PlayerOne)
                    {
                        Setup(eventData, TypeOfPlayer.PlayerOne);
                    }
                    else if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == TypeOfPlayer.PlayerTwo)
                    {
                        Setup(eventData, TypeOfPlayer.PlayerTwo);
                    }
                    GameController.instance.TicTacToe();
                }
                else if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == playerOfItemSlot || eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop != playerOfItemSlot)
                {
                    WinnerCheckRSP(eventData);
                }
            }
            else if (eventData.pointerDrag.GetComponent<DragDrop>().CheckersOFDragDrop != TypeOfCheckers.NONE)
            {
                if (checkersOfItemSlot == TypeOfCheckers.NONE && playerOfItemSlot == TypeOfPlayer.NONE)
                {
                    if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == TypeOfPlayer.PlayerOne)
                    {
                        Setup(eventData, TypeOfPlayer.PlayerOne);
                    }
                    else if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == TypeOfPlayer.PlayerTwo)
                    {
                        Setup(eventData, TypeOfPlayer.PlayerTwo);
                    }
                    GameController.instance.TicTacToe();
                }
                else if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == playerOfItemSlot || eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop != playerOfItemSlot)
                {
                    WinnerCheckChecker(eventData);
                }
            }
        }
    }

    void Setup(PointerEventData eventData, TypeOfPlayer player)
    {
        playerOfItemSlot = player;
        GetComponent<Image>().sprite = eventData.pointerDrag.GetComponent<Image>().sprite;
        Color color = eventData.pointerDrag.GetComponent<Image>().color;
        GetComponent<Image>().color = color;
        GetComponent<RectTransform>().localScale = eventData.pointerDrag.GetComponent<RectTransform>().localScale;
        handsOfItemSlot = eventData.pointerDrag.GetComponent<DragDrop>().HandsOfDragDrop;
        checkersOfItemSlot = eventData.pointerDrag.GetComponent<DragDrop>().CheckersOFDragDrop;
        int removeObj = 0;
        bool removeOne = false;
        for (int i = 0; i < GameController.instance.playerOneHands.Count; i++)
        {
            if (eventData.pointerDrag.gameObject.name.Equals(GameController.instance.playerOneHands[i].name))
            {
                removeObj = i;
                removeOne = true;
            }
        }
        for (int i = 0; i < GameController.instance.playerTwoHands.Count; i++)
        {
            if (eventData.pointerDrag.gameObject.name.Equals(GameController.instance.playerTwoHands[i].name))
            {
                removeObj = i;
                removeOne = false;
            }
        }
        if (removeOne)
        {
            GameController.instance.playerOneHands.RemoveAt(removeObj);
        }
        else
        {
            GameController.instance.playerTwoHands.RemoveAt(removeObj);
        }
        Destroy(eventData.pointerDrag.gameObject);
    }

    void WinnerCheckRSP(PointerEventData eventData)
    {
        if (Remarked != 2)
        {
            if (eventData.pointerDrag.GetComponent<DragDrop>().HandsOfDragDrop == handsOfItemSlot || eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == playerOfItemSlot)
            {
                eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
            }
            //player1
            else if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == TypeOfPlayer.PlayerOne && playerOfItemSlot == TypeOfPlayer.PlayerTwo)
            {
                ChangePlayer(eventData, TypeOfPlayer.PlayerOne);
            }

            //player 2
            else if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == TypeOfPlayer.PlayerTwo && playerOfItemSlot == TypeOfPlayer.PlayerOne)
            {
                ChangePlayer(eventData, TypeOfPlayer.PlayerTwo);
            }
        }
        else if (Remarked == 2)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
        }
    }

    void WinnerCheckChecker(PointerEventData eventData)
    {
        if (eventData.pointerDrag.GetComponent<DragDrop>().CheckersOFDragDrop == checkersOfItemSlot || eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == playerOfItemSlot)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
        }
        //player1
        else if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == TypeOfPlayer.PlayerOne && playerOfItemSlot == TypeOfPlayer.PlayerTwo)
        {
            ChangePlayerChecker(eventData, TypeOfPlayer.PlayerOne);

        }

        //player 2
        else if (eventData.pointerDrag.GetComponent<DragDrop>().PlayerOfDragDrop == TypeOfPlayer.PlayerTwo && playerOfItemSlot == TypeOfPlayer.PlayerOne)
        {
            ChangePlayerChecker(eventData, TypeOfPlayer.PlayerTwo);
        }
    }

    private void ChangePlayer(PointerEventData eventData, TypeOfPlayer playerType)
    {
        DragDrop player = eventData.pointerDrag.GetComponent<DragDrop>();
        if (player.HandsOfDragDrop == TypeOfHands.ROCK && handsOfItemSlot == TypeOfHands.PAPER)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
        }
        else if (player.HandsOfDragDrop == TypeOfHands.PAPER && handsOfItemSlot == TypeOfHands.ROCK)
        {
            Setup(eventData, playerType);
            GameController.instance.TicTacToe();
            Remarked++;
        }
        else if (player.HandsOfDragDrop == TypeOfHands.ROCK && handsOfItemSlot == TypeOfHands.SCISSORS)
        {
            Setup(eventData, playerType);
            GameController.instance.TicTacToe();
            Remarked++;
        }
        else if (player.HandsOfDragDrop == TypeOfHands.SCISSORS && handsOfItemSlot == TypeOfHands.ROCK)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
        }
        else if (player.HandsOfDragDrop == TypeOfHands.SCISSORS && handsOfItemSlot == TypeOfHands.PAPER)
        {
            Setup(eventData, playerType);
            GameController.instance.TicTacToe();
            Remarked++;
        }
        else if (player.HandsOfDragDrop == TypeOfHands.PAPER && handsOfItemSlot == TypeOfHands.SCISSORS)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
        }
    }

    private void ChangePlayerChecker(PointerEventData eventData, TypeOfPlayer typeOfPlayer)
    {
        DragDrop player = eventData.pointerDrag.GetComponent<DragDrop>();
        if (player.CheckersOFDragDrop == TypeOfCheckers.SMALL && (checkersOfItemSlot == TypeOfCheckers.MEDIUM && checkersOfItemSlot == TypeOfCheckers.LARGE))
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
        }
        else if (player.CheckersOFDragDrop == TypeOfCheckers.MEDIUM && checkersOfItemSlot == TypeOfCheckers.SMALL)
        {
            Setup(eventData, typeOfPlayer);
            GameController.instance.TicTacToe();
        }
        else if (player.CheckersOFDragDrop == TypeOfCheckers.MEDIUM && checkersOfItemSlot == TypeOfCheckers.LARGE)
        {
            eventData.pointerDrag.GetComponent<DragDrop>().ResetPosition();
        }
        else if (player.CheckersOFDragDrop == TypeOfCheckers.LARGE && (checkersOfItemSlot == TypeOfCheckers.SMALL || checkersOfItemSlot == TypeOfCheckers.MEDIUM))
        {
            Setup(eventData, typeOfPlayer);
            GameController.instance.TicTacToe();
        }
    }
}
