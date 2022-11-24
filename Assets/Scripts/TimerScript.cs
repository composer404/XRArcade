using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{
    private float currentTime;

    [SerializeField] 
    private UnityEvent losing;

    [SerializeField]
    private int startingTime;

    [SerializeField] 
    private TextMeshProUGUI countdownText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -=  Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime= 0;
            losing.Invoke();
        }
    }
}
