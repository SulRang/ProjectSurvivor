using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowRandomItem : MonoBehaviour
{
    [SerializeField]
    public List<string[]> Data = new List<string[]>();
    public List<string[]> originData;
    public bool StartLevel = false;

    public string FirstItem;
    public string FirstItemExplain;

    public string SecondItem;
    public string SecondItemExplain;

    public string ThirdItem;
    public string ThirdItemExplain;


    bool firstFlag = true;
    public bool itemFlag = false;

    private void OnEnable()
    {
        FirstSetting();
        ItemListSet();
    }
    private void OnDisable()
    {
        StartLevel = false;
    }

    public void FirstSetting()
    {
        if (gameObject.activeSelf && firstFlag)
        {
            int[] Num;

            Debug.Log("시작");
            Num = SelectRandom(16);

            StreamReader sr = new StreamReader(Application.dataPath + "/" + "ItemDatabase.csv");

            bool endOfFile = false;
            int Count = 0;

            while (!endOfFile)
            {
                Count += 1;
                string data_String = sr.ReadLine();

                if (data_String == null)
                {
                    endOfFile = true;
                    break;
                }

                var data_values = data_String.Split(',');
                Data.Add(data_values);

                //csv 파일 : 숫자, 이름, 레벨, 설명

                if (int.Parse(data_values[0]) == Num[0])
                {
                    SecondItem = Data[Num[0] - 1][1];
                    SecondItemExplain = Data[Num[0] - 1][3];
                }
                if (int.Parse(data_values[0]) == Num[1])
                {
                    FirstItem = Data[Num[1] - 1][1];
                    FirstItemExplain = Data[Num[1] - 1][3];
                }
                if (int.Parse(data_values[0]) == Num[2])
                {
                    ThirdItem = Data[Num[2] - 1][1];
                    ThirdItemExplain = Data[Num[2] - 1][3];
                }
            }
            firstFlag = false;

            originData = Data;
        }
    }
    public void ItemListSet()
    {
        //오브젝트가 활성화하면 랜덤으로 선택된 아이템의 데이터베이스를 불러오고, 선택창에 저장한다.
        if (gameObject.activeSelf && itemFlag)
        {
            itemFlag = false;
            int[] Num;
            /*
            foreach (var item in Data)
            {
                Debug.Log(item[1]);
            }*/
            Debug.Log(Data.Count);
            Debug.Log("레벨 업!");
            Num = SelectRandom(Data.Count);
            

            StreamReader sr = new StreamReader(Application.dataPath + "/" + "ItemDatabase.csv");

            bool endOfFile = false;
            int Count = 0;

            while(!endOfFile)
            {
                Count += 1;
                string data_String = sr.ReadLine();

                if (data_String == null)
                {
                    endOfFile = true;
                    break;
                }

                var data_values = data_String.Split(',');

                //csv 파일 : 숫자, 이름, 레벨, 설명

                if (int.Parse(data_values[0]) == Num[0])
                {
                    SecondItem = Data[Num[0] - 1][1];
                    SecondItemExplain = Data[Num[0] - 1][3];
                }
                if (int.Parse(data_values[0]) == Num[1])
                {
                    FirstItem = Data[Num[1] - 1][1];
                    FirstItemExplain = Data[Num[1] - 1][3];
                }
                if (int.Parse(data_values[0]) == Num[2])
                {
                    ThirdItem = Data[Num[2] - 1][1];
                    ThirdItemExplain = Data[Num[2] - 1][3];
                }
            }
        }
    }

    public int[] SelectRandom(int End)
    {
        int a = Random.Range(2, End - 1);
        int b = Random.Range(1, a);
        int c = Random.Range(a + 1, End);

        //Debug.Log(a + ", " + b + ", " + c);
        int[] Num = new int[] { a, b, c };

        return Num;
    }

    public GameObject GetItem(int T)
    {
        return gameObject;
    }
}
