using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ShowRandomItem : MonoBehaviour
{
    public bool StartLevel = false;

    public string FirstItem;
    public string FirstItemExplain;

    public string SecondItem;
    public string SecondItemExplain;

    public string ThirdItem;
    public string ThirdItemExplain;

    private void OnEnable()
    {
        ItemListSet();
    }
    private void OnDisable()
    {
        StartLevel = false;
    }

    public void ItemListSet()
    {
        //������Ʈ�� Ȱ��ȭ�ϸ� �������� ���õ� �������� �����ͺ��̽��� �ҷ�����, ����â�� �����Ѵ�.
        if (gameObject.activeSelf)
        {
            int[] Num;
            if (StartLevel)
            {
                Debug.Log("����");
                Num = SelectRandom(16);
            }
            else
            {
                Debug.Log("���� ��!");
                Num = SelectRandom(28);
            }

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

                if (int.Parse(data_values[0]) == Num[0])
                {
                    SecondItem = data_values[1];
                    SecondItemExplain = data_values[3];
                }
                if (int.Parse(data_values[0]) == Num[1])
                {
                    FirstItem = data_values[1];
                    FirstItemExplain = data_values[3];
                }
                if (int.Parse(data_values[0]) == Num[2])
                {
                    ThirdItem = data_values[1];
                    ThirdItemExplain = data_values[3];
                }
            }
        }
    }

    public int[] SelectRandom(int End)
    {
        int a = Random.Range(2, End - 1);
        int b = Random.Range(1, a);
        int c = Random.Range(a + 1, End);

        Debug.Log(a + ", " + b + ", " + c);
        int[] Num = new int[] { a, b, c };

        return Num;
    }

    public GameObject GetItem(int T)
    {
        return gameObject;
    }
}
