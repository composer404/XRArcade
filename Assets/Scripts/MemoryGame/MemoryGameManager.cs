using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;

public class MemoryGameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject currentScore;

    [SerializeField]
    private GameObject bestScore;

    [SerializeField]
    private GameObject startLabel;

    [SerializeField]
    private GameObject gameOverLabel;

    private TMP_Text bestScoreText;
    private TMP_Text currentScoreText;
    private TMP_Text startText;

    private int savedBestScore;

    private GameObject[] memoryButtons;
    private Dictionary<GameObject, AudioSource> buttonWithSoudDic = new Dictionary<GameObject, AudioSource>();

    private List<GameObject> currentRoundButtons = new List<GameObject>();
    private List<GameObject> userRoundButtons = new List<GameObject>();

    void Start()
    {
        this.memoryButtons = GameObject.FindGameObjectsWithTag("MemoryButton");

        this.savedBestScore = PlayerPrefs.GetInt("MemoryGameBestScore");
        this.currentScoreText = currentScore.GetComponent<TMP_Text>();
        this.bestScoreText = bestScore.GetComponent<TMP_Text>();
        this.startText = startLabel.GetComponent<TMP_Text>();

        AssignDefultValues();
        MapButtonsWithSounds();
    }

    public void StartGame()
    {
        StopAllCoroutines();
        ClearGameState(true);
        StartRound();
    }

    private void StartRound()
    {
        ChangeButtonsPokeStatus(false);
        this.userRoundButtons = new List<GameObject>();
        var currentButton = this.memoryButtons[Random.Range(0, this.memoryButtons.Length)];
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
        yield return new WaitForSeconds(1f);
        ChangeButtonsPokeStatus(true);
    }

    private void ChangeButtonsPokeStatus(bool status)
    {
        for (int i = 0; i < this.memoryButtons.Length; i++)
        {
            PokeInteractable pokeInteractable = memoryButtons[i].GetComponent<PokeInteractable>();
            pokeInteractable.enabled = status;
        }
    }

    private IEnumerator DisaplyPreviousObject(GameObject gameObject)
    {
        yield return new WaitForSeconds(1.5f);
        ChangeObjectMaterial(gameObject);
        yield return new WaitForSeconds(1);
    }

    public void UserMove(GameObject gameObject)
    {
        buttonWithSoudDic.GetValueOrDefault(gameObject).Play();
        this.userRoundButtons.Add(gameObject);
        if (userRoundButtons.Count == currentRoundButtons.Count)
        {
            if (CheckRoundResult())
            {

                UpdateTexts();
                StartRound();
                return;
            }

            /* -------------------------------- GAME OVER ------------------------------- */

            gameOverLabel.SetActive(true);
            ClearGameState(false);
        }
    }

    private void MapButtonsWithSounds()
    {
        AudioSource[] audioForButtons = AudioManager.GetInstance().GetMemoryButtonSounds();

        for (int i = 0; i < memoryButtons.Length; i++)
        {
            buttonWithSoudDic.Add(memoryButtons[i], audioForButtons[i]);
        }
    }

    private void AssignDefultValues()
    {
        if (!currentScoreText.text.Equals("0"))
        {
            currentScoreText.SetText("0");
        }

        if (!bestScoreText.text.Equals("0"))
        {
            currentScoreText.SetText("0");
        }

        bestScoreText.SetText(savedBestScore.ToString());
        gameOverLabel.SetActive(false);
    }

    private void ClearGameState(bool restart)
    {
        this.currentRoundButtons = new List<GameObject>();
        this.userRoundButtons = new List<GameObject>();
        this.currentScoreText.SetText("0");
        if (restart)
        {
            gameOverLabel.SetActive(false);
            this.startText.SetText("Restart");
            return;
        }
        this.startText.SetText("Start");
    }

    private void UpdateTexts()
    {
        int currentScore = int.Parse(currentScoreText.text);
        int newScore = currentScore + 1;
        currentScoreText.SetText(newScore.ToString());

        if (newScore > savedBestScore)
        {
            PlayerPrefs.SetInt("MemoryGameBestScore", newScore);
            bestScoreText.SetText(newScore.ToString());
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

    private void ChangeObjectMaterial(GameObject gameObject)
    {
        buttonWithSoudDic.GetValueOrDefault(gameObject).Play();
        Color defaultColor = gameObject.GetComponentInChildren<MeshRenderer>().material.color;
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
        StartCoroutine(SetDefaultObjectMaterial(gameObject, defaultColor));
    }

    private IEnumerator SetDefaultObjectMaterial(GameObject gameObject, Color defaultColor)
    {
        yield return new WaitForSeconds(1);
        gameObject.GetComponentInChildren<MeshRenderer>().material.color = defaultColor;
    }
}
