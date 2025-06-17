using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
   private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject gameOverui;
    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScore();
        gameOverui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Addsroce(int points)
    {
        score += points;
        UpdateScore();
    }
    private void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    public void Gameover()
    {
        isGameOver = true;
        score = 0;
        Time.timeScale = 0;
        gameOverui.SetActive(true);
    }
    public void restartgame()
    {
        isGameOver = false;
        score = 0;
        UpdateScore();
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }
    public bool IsGameOver()
    {
        return isGameOver;  
    }

}
