using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * �÷��� �ð��� ���� �� ������ �޸��ϱ� ���� ��ũ��Ʈ.
 * spawnerList�� ���� Ư�� index�� enemySpawner ���� ����.
 * �� enemySpawner�� ������Ʈ Ǯ������ �����Ǿ�����.
 * TimeCheck �Լ��� ���� �ʴ����� ���� �����ϵ��� ����.
 */

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject spawnerPrefab;

    [SerializeField]
    List<MonsterData> enemyList = new List<MonsterData>();

    //spawner ������ ���� ����Ʈ
    [SerializeField]
    List<GameObject> spawnerList = new List<GameObject>();

    [SerializeField]
    GameObject player;

    [SerializeField]
    Camera player_Camera;

    // �÷��� �ð� �ؽ�Ʈ
    [SerializeField]
    Text[] timeTexts; // 0 : ��, 1 : ��

    private void Awake()
    {
        InitSpawner();

    }

    // Start is called before the first frame update
    void Start()
    {
        spawnerList[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        TimeCheker();
    }

    void InitSpawner()
    {
        for (int i = 0; i < enemyList.Count; i++)
        {
            GameObject spawner = Instantiate(spawnerPrefab);
            spawner.transform.SetParent(this.gameObject.transform);
            spawner.SetActive(false);
            spawner.GetComponent<SampleSpawner>().SetPlayer(player);
            spawner.GetComponent<SampleSpawner>().SetPlayerCamera(player_Camera);
            spawner.GetComponent<SampleSpawner>().SetMonsterData(enemyList[i]);
            spawner.name = enemyList[i].monsterName + " Spawner";

            spawnerList.Add(spawner);
        }
    }

    // �ð��� ���� spawner ���� �Լ�
    void TimeCheker()
    {
        if (timeTexts[0].text == "10")
        {
            spawnerList[1].GetComponent<SampleSpawner>().SetMaximum(5);
            spawnerList[1].SetActive(true);
        }
    }
}
