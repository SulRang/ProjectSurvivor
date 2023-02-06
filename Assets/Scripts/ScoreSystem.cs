using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField]
    Text scoreText;

    [SerializeField]
    int standard = 10;

    public static int score = 0;

    float time;

    float cal_Value = 0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        cal_Value = time * standard;
        scoreText.text = (score + (int)cal_Value).ToString();

        // 5분마다 점수 증가
        if (((int)time / 60 % 60) != 0 && ((int)time / 60 % 60) % 5 == 0) 
        {
            standard += 20;
        }

    }

    public int FinalScore()
    {
        cal_Value += score;
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
