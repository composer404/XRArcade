using UnityEngine;

public class ButtonController : MonoBehaviour
{
    private MemoryGameManager gameManager;

    void Start()
    {
        this.gameManager = GameObject.FindObjectOfType<MemoryGameManager>();
    }

    void OnMouseDown()
    {
        this.gameManager.UserMove(gameObject);
    }
}
