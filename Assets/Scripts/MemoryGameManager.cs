using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject buttonsGroup;

    private GameObject[] memoryButtons;
    private List<GameObject> currentRoundButtons = new List<GameObject>();
    private List<GameObject> userRoundButtons = new List<GameObject>();

    private int roundCounter = 1;

    void Start()
    {
        this.memoryButtons = GameObject.FindGameObjectsWithTag("MemoryButton");
    }

    void Update()
    {

    }

    public void StartGame()
    {
        ClearGameState();
        StartRound();
    }

    private void StartRound()
    {
        this.userRoundButtons = new List<GameObject>();
        var currentButton = this.memoryButtons[GenerateRandomIndex()];
        this.currentRoundButtons.Add(currentButton);

        StartCoroutine(PresentPreviousObject());
    }

    private IEnumerator PresentPreviousObject()
    {
        for (int i = 0; i < this.currentRoundButtons.Count; i++)
        {
            StartCoroutine(DisaplyPreviousObject(currentRoundButtons[i]));
            yield return new WaitForSeconds(1.5f);
        }
    }

    private IEnumerator DisaplyPreviousObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);
        ChangeObjectMaterial(gameObject);
        yield return new WaitForSeconds(1);
    }

    public void UserMove(GameObject gameObject)
    {
        this.userRoundButtons.Add(gameObject);

        if (userRoundButtons.Count == currentRoundButtons.Count)
        {
            if (CheckRoundResult())
            {
                print("Next round");
                StartRound();
                return;
            }

            print("Game over");
            ClearGameState();
        }
    }

    private void ClearGameState()
    {
        this.currentRoundButtons = new List<GameObject>();
        this.userRoundButtons = new List<GameObject>();
    }

    private bool CheckRoundResult()
    {
        if (currentRoundButtons.Count != userRoundButtons.Count)
        {
            return false;
        }

        for (int i = 0; i < currentRoundButtons.Count; i++)
        {
            if (currentRoundButtons[i] != userRoundButtons[i])
            {
                return false;
            }
        }

        return true;
    }



    private int GenerateRandomIndex()
    {
        return Random.Range(0, this.memoryButtons.Length);
    }

    private void ChangeObjectMaterial(GameObject gameObject)
    {
        var defaultColor = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
        StartCoroutine(SetDefaultObjectMaterial(gameObject, defaultColor));
    }

    private IEnumerator SetDefaultObjectMaterial(GameObject gameObject, Color defaultColor)
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = defaultColor;
    }
}
