using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using Oculus.Interaction;
using TMPro;
// using UnityEngine.XR.Interaction.Toolkit;

public class CheckCards : MonoBehaviour
{
    [SerializeField] private UnityEvent winning;
    [SerializeField] private GameObject scoreText;

    private int card1 = 0;
    private int card1GameObjID = 0;
    private int card2 = 0;
    private int card2GameObjID = 0;
    private int score = 0;
    [SerializeField] private Positions positions;


    public void checkBothIds()
    {
        //match
        if (card1 == card2)
        {
            //good
            score++;
            scoreText.GetComponent<TMP_Text>().SetText("SCORE: " + score);
            checkScore();
            for (int i = 0; i < positions.getCards().Length; i++)
            {
                if (card1 == positions.getCards()[i].GetComponent<FruitCard>().cardId)
                {
                    //positions.cards[i].GetComponent<FruitCard>().enabled = false;
                    positions.getCards()[i].GetComponent<RayInteractable>().enabled = false;
                }
            }

            card1 = 0;
            card2 = 0;

        }
        else
        {
            for (int i = 0; i < positions.getCards().Length; i++)
            {
                if (card1GameObjID == positions.getCards()[i].GetComponent<FruitCard>().instanceID || card2GameObjID == positions.getCards()[i].GetComponent<FruitCard>().instanceID)
                {
                    positions.getCards()[i].GetComponent<RayInteractable>().enabled = false;
                    StartCoroutine(WaitForStart(positions.getCards()[i].GetComponent<FruitCard>(), positions.getCards()[i].GetComponent<RayInteractable>()));

                }
            }

            card1 = 0;
            card2 = 0;

        }
    }

    IEnumerator WaitForStart(FruitCard card, RayInteractable interactable)
    {
        yield return new WaitForSeconds(2);
        card.RotateBack();
        interactable.enabled = true;
    }
    public void check(int cardId, int gameObjId)
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
        if (score == 24 / 2)
        {
            winning.Invoke();
        }
    }

    // public void resetScene()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    // }

    // public void mainMenu()
    // {
    //     SceneManager.LoadScene(0);//menu should be the first scene in order the script to work =D
    // }


}
