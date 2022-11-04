using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryStartButtonController : MonoBehaviour
{
    private MemoryGameManager gameManager;

    void Start()
    {
        this.gameManager = GameObject.FindObjectOfType<MemoryGameManager>();
    }

    void OnMouseDown()
    {
        this.gameManager.StartGame();
    }
}
