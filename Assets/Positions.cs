using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Positions : MonoBehaviour
{
    private float duration = 2f;
    private float elapsedTime;
    private int someint = 0;
    private Boolean rotate;
    private void Start()
    {
        this.cards = GameObject.FindGameObjectsWithTag("Card");
        print("cards" + cards);
        LoadPostions();
        Shuffle(cards);
        AssignCardPositions();
        StartCoroutine(WaitForStart());
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(5);
        RotateBack();
        // timedEvent.Invoke();
    }

    public void AssignCardPositions()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            //cards[i].GetComponent<FruitCard>().enabled = false;
            cards[i].transform.position = positions[i];
        }
    }
    public void Shuffle(GameObject[] array)
    {
        var rand = new System.Random();
        int n = array.Length;
        while (n > 1)
        {
            int k = rand.Next(n--);
            GameObject temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }


    // [SerializeField]
    private GameObject[] cards;

    private Vector3[] positions = new Vector3[18];

    public GameObject[] getCards()
    {
        return cards;
    }

    void LoadPostions()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            positions[i] = cards[i].transform.position;

        }
    }

    void RotateBack()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<FruitCard>().RotateBack();


        }
    }



}
