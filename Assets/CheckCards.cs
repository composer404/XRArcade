using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class CheckCards : MonoBehaviour
{
    [SerializeField] private UnityEvent winning;
    
    private int card1 = 0;
    private int card1GameObjID = 0;
    private int card2 = 0;
    private int card2GameObjID = 0;
    private int score = 0;
    [SerializeField]private Positions positions;
    

    public void checkBothIds()
    {
        //match
        if (card1 == card2)
        {
            //good
            score++;
            checkScore();
            for (int i = 0; i < positions.cards.Length; i++)
            {
                if (card1 == positions.cards[i].GetComponent<FruitCard>().cardId)
                {
                    //positions.cards[i].GetComponent<FruitCard>().enabled = false;
                    positions.cards[i].GetComponent<XRSimpleInteractable>().enabled = false;
                }
            }
            
            card1 = 0;
            card2 = 0;
            
        }
        else
        {
            for (int i = 0; i < positions.cards.Length; i++)
            {
                if (card1GameObjID == positions.cards[i].GetComponent<FruitCard>().instanceID || card2GameObjID == positions.cards[i].GetComponent<FruitCard>().instanceID)
                {
                    positions.cards[i].GetComponent<XRSimpleInteractable>().enabled = false;
                    StartCoroutine(WaitForStart(positions.cards[i].GetComponent<FruitCard>(),positions.cards[i].GetComponent<XRSimpleInteractable>()));
                   
                }
            }
            
            card1 = 0;
            card2 = 0;
            
        }
    }
    
    IEnumerator WaitForStart(FruitCard card,XRSimpleInteractable interactable)
    {
        yield return new WaitForSeconds(2);
        card.RotateBack();
        interactable.enabled = true;
    }
    public void check(int cardId,int gameObjId)
    {
        if (card1 == 0)
        {
            card1GameObjID = gameObjId;
            card1 = cardId;
        }
        else
        {
            
            card2GameObjID = gameObjId;
            card2 = cardId;
            checkBothIds();
        }
    }

    public void checkScore()
    {
        if (score == 24/2)
        {
            winning.Invoke();
        }
    }

    public void resetScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void mainMenu()
    {
        SceneManager.LoadScene(0);//menu should be the first scene in order the script to work =D
    }


}
