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
    TMP_Text gameOverText;

    [SerializeField]
    ScoreSystem scoreSystem;

    [SerializeField]
    GameObject timerObj;

    Timer timer;

    bool isClear = false;
    int cal_gold = 0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        timer = timerObj.GetComponent<Timer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Player_Status.instance.Current_Hp <= 0)
        {
            scoreSystem.isEnd = true;
            GameOver();
        }
        else if (timer.ClearCheck())
        {
            scoreSystem.isEnd = true;
            isClear = true;
            GameOver();
        }
    }

    void GameOver()
    {
        if (isClear)
        {
            isClear = false;
            gameOverText.text = "Game Clear!";
        }
        Player_Status.instance.Current_Hp = 1;
        Time.timeScale = 0f;
        gameoverUI.SetActive(true);
        int finalScore = scoreSystem.FinalScore();
        scoreText.text = finalScore.ToString();
        cal_gold = GoldSystem.instance_gold.CalGold(finalScore);
        goldText.text = cal_gold.ToString();
        GoldSystem.instance_gold.SetGold(cal_gold);
    }

    public void Retry()
    {
        gameoverUI.SetActive(false);
        Time.timeScale = 1f;
        scoreSystem.InitScore();
        timer.InitTrigger();
        SceneManager.LoadScene("MainGameScene");
    }

    public void ToTitle()
    {
        gameoverUI.SetActive(false);
        scoreSystem.InitScore();
        timer.InitTrigger();
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleSceneDummy");
        GameObject.Find("Canvas (Title)").transform.GetChild(0).gameObject.SetActive(true);
    }
}
