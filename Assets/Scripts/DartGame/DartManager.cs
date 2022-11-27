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

    [SerializeField]
    private GameObject trowsContainer;

    [SerializeField]
    private GameObject basket;

    [SerializeField]
    private GameObject dartPrefab;

    private TMP_Text bestScoreText;
    private TMP_Text currentScoreText;
    private TMP_Text startText;

    private GameObject dartOne;
    private GameObject dartTwo;
    private GameObject dartThree;

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

    public void InitalLoad()
    {
        Destroy(dartOne);
        Destroy(dartTwo);
        Destroy(dartThree);
        this.dartOne = Instantiate(dartPrefab, new Vector3(this.basket.transform.position.x - 0.1f, this.basket.transform.position.y, this.basket.transform.position.z), Quaternion.identity);
        this.dartTwo = Instantiate(dartPrefab, this.basket.transform.position, Quaternion.identity);
        this.dartThree = Instantiate(dartPrefab, new Vector3(this.basket.transform.position.x + 0.1f, this.basket.transform.position.y, this.basket.transform.position.z), Quaternion.identity);

        this.dartOne.transform.SetParent(this.trowsContainer.transform);
        this.dartTwo.transform.SetParent(this.trowsContainer.transform);
        this.dartThree.transform.SetParent(this.trowsContainer.transform);
    }

    void Update()
    {

    }

    public void ResetGame()
    {
        Destroy(dartOne);
        Destroy(dartTwo);
        Destroy(dartThree);

        this.InitalLoad();
        this.ClearGameState();
    }

    public void ResetPoints()
    {
        this.points = 501;
    }

    public void SubtractPoints(int subtractedPoints)
    {
        this.points -= subtractedPoints;
        UpdateTexts();
        print("Subtracted points XXX");
    }

    private void ClearGameState()
    {
        this.currentScoreText.SetText("501");
        this.points = 501;
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
        currentScoreText.SetText(points.ToString());

        if (points < savedBestScore && points >= 0)
        {
            PlayerPrefs.SetInt("DartGameBestScore", points);
            bestScoreText.SetText(points.ToString());
        }
    }
}
