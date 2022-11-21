using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Oculus.Interaction;

public class DartManager : MonoBehaviour
{
    [SerializeField]
    private GameObject currentScore;

    [SerializeField]
    private GameObject bestScore;

    [SerializeField]
    private GameObject startDart;

    private TMP_Text bestScoreText;
    private TMP_Text currentScoreText;
    private TMP_Text startText;

    private int savedBestScore;

    private int points;

    void Start()
    {
      this.points = 501;
      this.savedBestScore = PlayerPrefs.GetInt("DartGameBestScore");
      this.currentScoreText = currentScore.GetComponent<TMP_Text>();
      this.bestScoreText = bestScore.GetComponent<TMP_Text>();
      this.startText = startDart.GetComponent<TMP_Text>();

      AssignDefultValues();
    }

    void Update()
    {
      UpdateTexts();
    }

    public void StartGame()
    {
      print("Start Game");
      ClearGameState(true);
    }

    public void ResetPoints()
    {
      this.points = 501;
    }

    public void SubtractPoints(int subtractedPoints)
    {
      this.points -= subtractedPoints;
    }

    private void ClearGameState(bool restart)
    {
        this.currentScoreText.SetText("0");
        if (restart)
        {
            this.startText.SetText("Restart");
            return;
        }
        this.startText.SetText("Start");
    }

    private void AssignDefultValues()
    {
        if (!currentScoreText.text.Equals("501"))
        {
            currentScoreText.SetText("501");
        }

        if (!bestScoreText.text.Equals("0"))
        {
            currentScoreText.SetText("501");
        }

        bestScoreText.SetText(savedBestScore.ToString());
    }

    private void UpdateTexts()
    {
        int currentScore = int.Parse(currentScoreText.text);
        int newScore = currentScore + 1;
        currentScoreText.SetText(newScore.ToString());

        if (newScore > savedBestScore)
        {
            PlayerPrefs.SetInt("DartGameBestScore", newScore);
            bestScoreText.SetText(newScore.ToString());
        }
    }
}
