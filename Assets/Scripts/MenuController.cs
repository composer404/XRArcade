using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    [SerializeField]
    private GameObject memoryGameView;

    [SerializeField]
    private GameObject dartGameView;

    [SerializeField]
    private GameObject cardGameView;

    [SerializeField]
    private GameObject menuView;

    private Transform cardGametransform;
    private GameObject cardGameViewInit;

    public void Start()
    {
        // this.cardGametransform = this.cardGameView.transform;
    }

    public void StartMemoryGame()
    {
        this.HideAllGames();

        this.memoryGameView.SetActive(true);
        GameObject.FindObjectOfType<MemoryGameManager>().InitalLoad();
    }

    public void StartDartGame()
    {
        this.HideAllGames();
        this.dartGameView.SetActive(true);
        GameObject.FindObjectOfType<DartManager>().InitalLoad();
    }

    public void StartCardGame()
    {
        this.HideAllGames();
        if (cardGameViewInit != null)
        {
            Destroy(cardGameViewInit);
        }
        this.cardGameViewInit = Instantiate(cardGameView);
        this.cardGameViewInit.SetActive(true);
        // this.cardGameView.SetActive(true);
    }

    public void ShowMenu()
    {
        if (cardGameViewInit != null)
        {
            Destroy(cardGameViewInit);
        }
        this.dartGameView.SetActive(false);
        this.memoryGameView.SetActive(false);
        this.cardGameView.SetActive(false);
        this.menuView.SetActive(true);
    }

    private void HideAllGames()
    {
        if (cardGameViewInit != null)
        {
            Destroy(cardGameViewInit);
        }
        this.cardGameView.SetActive(false);
        this.menuView.SetActive(false);
        this.memoryGameView.SetActive(false);
        this.dartGameView.SetActive(false);
    }
}
