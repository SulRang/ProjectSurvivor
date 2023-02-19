using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    int[] standards = { 10, 30, 50 };

    [SerializeField]
    int standard = 10;

    public static int score = 0;

    float time;

    float cal_Value = 0f;

    public bool isEnd = false;

    void Start()
    {
        standard = standards[0];
    }

    void Update()
    {        
        // 10분에 점수 증가
        if (((int)time / 60 % 60) == 10 && ((int)time % 60) == 0)
        {
            standard = standards[1];
        }
        // 15분에 점수 증가
        else if (((int)time / 60 % 60) == 15 && ((int)time % 60) == 0)
        {
            standard = standards[2];
        }

        if (!isEnd)
        {
            cal_Value += Time.deltaTime * standard;
            scoreText.text = (score + (int)cal_Value).ToString();
        }

    }

    public int FinalScore()
    {
        cal_Value += score;
        scoreText.text = "";
        return (int)cal_Value;
    }

    public void InitScore()
    {
        score = 0;
        cal_Value = 0f;
        scoreText.text = null;
        standard = 10;
    }

}
