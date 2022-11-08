using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject memoryGameView;

    [SerializeField]
    private GameObject dartGameView;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartMemoryGame()
    {
        this.memoryGameView.SetActive(true);
    }

    public void StartDartGame()
    {
        this.dartGameView.SetActive(true);
    }
}
