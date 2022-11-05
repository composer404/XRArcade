using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FruitCard : MonoBehaviour
{
    [SerializeField] private int cardId;
    [SerializeField] private UnityEvent click;
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    
    
    public void onClick()
    {
        click.Invoke();
    }
}
