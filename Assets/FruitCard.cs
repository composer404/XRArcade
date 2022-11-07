using System.Collections;
using System.Collections.Generic;
using System.IO.Pipes;
using UnityEngine;
using UnityEngine.Events;

public class FruitCard : MonoBehaviour
{
    private bool rotate=false;
   // [SerializeField] private UnityEvent checkCardId;
    [SerializeField] private AnimationCurve curve;
    private Quaternion startingPoint = Quaternion.Euler(-180, 0, 0);
    private float duration = 5f;
    [SerializeField] private CheckCards checkCards;
    private float elapsedTime=0;
    private float percentage =0;
    private bool waitforStart;
    [SerializeField] private  int cardId;
    void Start()
    {
        
    }
  
    void Update()
    {
        elapsedTime += Time.deltaTime;
        percentage = elapsedTime / duration;
        if (rotate)
        {
            transform.rotation = Quaternion.Lerp(startingPoint, Quaternion.Euler(-180,180,0),curve.Evaluate(percentage));
        }
        else
        { 
            transform.rotation = Quaternion.Lerp(Quaternion.Euler(-180,180,0),startingPoint ,curve.Evaluate(percentage));
            //rotate back unlock controls
        }
    }
    
    public void onClick()
    {
        elapsedTime = 0;
        percentage = 0;
        rotate = true;
        checkCards.check(cardId);
        
    }
    public void RotateBack()
    {
        percentage = 0;
        elapsedTime = 0;
        rotate = false;
        
    }
}
