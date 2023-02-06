using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;



public class GameManager_JS : MonoBehaviour
{
    [SerializeField]
    GameObject gameoverUI;

    [SerializeField]
    TMP_Text scoreText;

    [SerializeField]
    TMP_Text goldText;

    [SerializeField]
    ScoreSystem scoreSystem;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Status.instance.Current_Hp <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        Player_Status.instance.Current_Hp = 1;
        Time.timeScale = 0f;
        gameoverUI.SetActive(true);
        scoreText.text = scoreSystem.FinalScore().ToString();
        int cal_gold = scoreSystem.FinalScore() / 1000;
        goldText.text = cal_gold.ToString();
        GoldSystem.instance_gold.SetGold(cal_gold);
    }

    public void Retry()
    {
        gameoverUI.SetActive(false);
        Time.timeScale = 1f;
        scoreSystem.InitScore();
        SceneManager.LoadScene("InGameTestScene_JS");
    }

    public void ToTitle()
    {
        gameoverUI.SetActive(false);
        scoreSystem.InitScore();
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene_JS");
    }
}
