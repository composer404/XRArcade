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
    private GameObject menuView;

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
    }

    public void ShowMenu()
    {
        this.dartGameView.SetActive(false);
        this.memoryGameView.SetActive(false);
        this.menuView.SetActive(true);
    }

    private void HideAllGames()
    {
        this.menuView.SetActive(false);
        this.memoryGameView.SetActive(false);
        this.dartGameView.SetActive(false);
    }
}
