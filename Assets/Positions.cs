using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Positions : MonoBehaviour
{
    [SerializeField] private UnityEvent timedEvent;
    [SerializeField] private int seconds;
    [SerializeField] private AnimationCurve curve;
    private Quaternion startingPoint = Quaternion.Euler(-180, 0, 0);
    private float duration = 2f;
    private float elapsedTime;
    private Boolean rotate;
    private void Start()
    {
        Shuffle(cards);
        AssignCardPositions();
        StartCoroutine(WaitForStart());
    }

    IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(5);
        rotate = true;
        timedEvent.Invoke();
    }

    public void AssignCardPositions()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.position = positions[i];
        }
    }
    public void Shuffle ( GameObject[] array)
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
    
    
    [SerializeField]
    private GameObject[] cards;
    
    
    private Vector3[] positions = new[]
    {
        new Vector3(-8, 5, 0),
        new Vector3(-4, 5, 0),
        new Vector3(0, 5, 0),
        new Vector3(4, 5, 0),
        new Vector3(8, 5, 0),
        new Vector3(12, 5, 0),
        new Vector3(-8, 0, 0),
        new Vector3(-4, 0, 0),
        new Vector3(0, 0, 0),
        new Vector3(4, 0, 0),
        new Vector3(8, 0, 0),
        new Vector3(12, 0, 0),
        new Vector3(-8, -5, 0),
        new Vector3(-4, -5, 0),
        new Vector3(0, -5, 0),
        new Vector3(4, -5, 0),
        new Vector3(8, -5, 0),
        new Vector3(12, -5, 0),
    };
   

    // Update is called once per frame
    void Update()
    {
        if (rotate)
        {
            
        elapsedTime += Time.deltaTime;
        float percentage = elapsedTime / duration;
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].transform.rotation = Quaternion.Lerp(startingPoint, Quaternion.Euler(-180,180,0),curve.Evaluate(percentage));
        }
        }
        
    }
}
