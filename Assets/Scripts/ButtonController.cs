using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private MemoryGameManager gameManager;
    void Start()
    {
        this.gameManager = GameObject.FindObjectOfType<MemoryGameManager>();
    }

    public void Debug()
    {
        print("Selected");
    }

    void OnMouseDown()
    {
        this.gameManager.UserMove(gameObject);
    }
}
