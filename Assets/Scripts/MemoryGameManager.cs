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
        print("MEMORY" + memoryButtons.Length);
    }

    void Update()
    {

    }

    public void StartGame()
    {
        print("Game started");
        StartRound();
        // ChangeObjectMaterial(this.memoryButtons[GenerateRandomIndex()]);
    }

    private void StartRound()
    {
        print("ROUND STARTED");
        for (int i = 0; i < this.currentRoundButtons.Count; i++)
        {
            StartCoroutine(DisaplyPreviousObject(currentRoundButtons[i]));
        }

        // int current = 0;
        // while (current < this.roundCounter)
        // {

        StartCoroutine(AddObjectToRound());
        // current++;
        // }
    }

    private IEnumerator DisaplyPreviousObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(1);
        ChangeObjectMaterial(gameObject);
        yield return new WaitForSeconds(1);
    }

    private IEnumerator AddObjectToRound()
    {
        yield return new WaitForSeconds(1);
        var currentButton = this.memoryButtons[GenerateRandomIndex()];
        this.currentRoundButtons.Add(currentButton);
        ChangeObjectMaterial(currentButton);
    }

    public void UserMove(GameObject gameObject)
    {
        this.userRoundButtons.Add(gameObject);

        if (userRoundButtons.Count == currentRoundButtons.Count)
        {
            if (CheckRoundResult())
            {
                StartRound();
                return;
            }
            print("Loser");
        }
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
        print("DEFAULT");
    }
}
