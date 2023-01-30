using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowRandomItem : MonoBehaviour
{
    public string FirstItem;
    public string FirstItemLevel;
    public string FirstItemExplain;

    public string SecondItem;
    public string SecondItemLevel;
    public string SecondItemExplain;

    public string ThirdItem;
    public string ThirdItemLevel;
    public string ThirdItemExplain;

    // Update is called once per frame
    void Start()
    {
        //오브젝트가 활성화하면 랜덤으로 선택된 아이템의 데이터베이스를 불러오고, 선택창에 저장한다.
        if(gameObject.activeSelf)
        {
            int[] Num = SelectRandom();

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
                for (int i = 0; i < data_values.Length; i++)
                {
                    Debug.Log("v: " + i.ToString() + " " + data_values[i].ToString());
                }

                if (int.Parse(data_values[0]) == Num[0])
                {
                    SecondItem = data_values[1];
                    SecondItemLevel = data_values[4];
                    SecondItemExplain = data_values[3];
                }
                if (int.Parse(data_values[0]) == Num[1])
                {
                    FirstItem = data_values[1];
                    FirstItemLevel = data_values[4];
                    FirstItemExplain = data_values[3];
                }
                if (int.Parse(data_values[0]) == Num[2])
                {
                    ThirdItem = data_values[1];
                    ThirdItemLevel = data_values[4];
                    ThirdItemExplain = data_values[3];
                }
            }
        }
    }
    public int[] SelectRandom()
    {
        int a = Random.Range(0, 28);
        int b = Random.Range(0, a);
        int c = Random.Range(a, 28);

        int[] Num = new int[] { a, b, c };

        return Num;
    }

    public GameObject GetItem(int T)
    {
        return gameObject;
    }
}
