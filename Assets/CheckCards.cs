using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCards : MonoBehaviour
{
    private int card1 = 0;
    private int card2 = 0;
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
                    positions.cards[i].GetComponent<FruitCard>().enabled = false;
                }
            }
            
            card1 = 0;
            card2 = 0;
            
        }
        else
        {
            for (int i = 0; i < positions.cards.Length; i++)
            {
                if (card1 == positions.cards[i].GetComponent<FruitCard>().cardId || card2 == positions.cards[i].GetComponent<FruitCard>().cardId)
                {
                    positions.cards[i].GetComponent<FruitCard>().RotateBack();
                }
            }
            
            //bad
            // add a func to flip both back
            card1 = 0;
            card2 = 0;
            
            
            
        }
    }
    public void check(int cardId)
    {
        if (card1 == 0) {
            card1 = cardId;
        }
        else
        {
            card2 = cardId;
            checkBothIds();
        }
        
    }

    public void checkScore()
    {
        if (score == 24/2)
        {
            //winning screen
        }
    }
    
}
