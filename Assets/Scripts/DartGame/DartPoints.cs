using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartPoints : MonoBehaviour
{
    [SerializeField]
    private GameObject text; 

    private int points;

    void Start()
    {
        points = 501;
        UpdateText();
    }

    void Update()
    {
        
    }

    public void ResetPoints()
    {
        this.points = 501;
        this.UpdateText();
    }

    public void SubtractPoint()
    {
        this.points--;
        this.UpdateText();
    }

    private void UpdateText()
    {
        this.text.GetComponent<UnityEngine.UI.Text>().text = "Points: " + this.points;
    }
}
