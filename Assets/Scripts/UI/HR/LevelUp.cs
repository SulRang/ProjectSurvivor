using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelUp : MonoBehaviour
{
    bool IsPause;

    Player_Status playerStatus;
    public GameObject Hpbar;
    public GameObject Status;
    public GameObject SelectionWindow;

    public GameObject First;
    public GameObject Second;
    public GameObject Third;

    public float pLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        IsPause = false;
        playerStatus = gameObject.GetComponent<Player_Status>();
    }

    // Update is called once per frame
    void Update()
    {
        if(pLevel != playerStatus.Full_Exp)
        {
            if(!IsPause)
            {
                pLevel = playerStatus.Full_Exp;

                //모든 오브젝트의 움직임 정지 후 선택창 출력
                Time.timeScale = 0;
                Activate_SelectionWindow();
                IsPause = true;
                return;
            }
            if(IsPause)
            {
                return;
            }
        }
    }

    public void Activate_SelectionWindow()
    {
        //Hpbar는 선택창과 겹치므로 비활성화
        Hpbar.SetActive(false);
        //Status와 SelectionWindow를 활성화
        Status.SetActive(true);
        SelectionWindow.SetActive(true);

        // Button을 누르면 SelectionButton.cs로 넘어가서 Time.timeScale을 풀고, 스테이터스를 업데이트한다.
    }

    public void OnClickStart()
    {
        //선택지 버튼을 눌렀을때 해당 값을 실행시킨다
        Time.timeScale = 1;
        IsPause = false;
        DeActivate_SelectionWindow();

        //ItemName = transform.GetChild(0).GetComponent<TextMeshProUGUI>().text;
    }
    public void DeActivate_SelectionWindow()
    {
        Hpbar.SetActive(true);
        SelectionWindow.SetActive(false);
        Status.SetActive(false);
    }
}
