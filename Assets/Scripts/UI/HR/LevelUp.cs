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

                //��� ������Ʈ�� ������ ���� �� ����â ���
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
        //Hpbar�� ����â�� ��ġ�Ƿ� ��Ȱ��ȭ
        Hpbar.SetActive(false);
        //Status�� SelectionWindow�� Ȱ��ȭ
        Status.SetActive(true);
        SelectionWindow.SetActive(true);

        // Button�� ������ SelectionButton.cs�� �Ѿ�� Time.timeScale�� Ǯ��, �������ͽ��� ������Ʈ�Ѵ�.
    }

    public void OnClickStart()
    {
        //������ ��ư�� �������� �ش� ���� �����Ų��
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
