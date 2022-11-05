using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCards : MonoBehaviour
{
    private int card1 = 0;
    private int card2 = 0;

    public void checkBothIds()
    {
        if (card1 == card2)
        {
            //good
            // add a func to unflip 
            card1 = 0;
            card2 = 0;
        }
        else
        {
            //bad
            // add a func to flip both back
            card1 = 0;
            card2 = 0;
        }
    }
    public void check(int cardId)
    {
        if (card1 == 0)
        {
            card1 = cardId;
        }
        else
        {
            card2 = cardId;
            checkBothIds();
        }
        
    }
}
