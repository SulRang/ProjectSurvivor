using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * 플레이 시간에 따른 적 생성을 달리하기 위한 스크립트.
 * spawnerList를 통해 특정 index의 enemySpawner 제어 가능.
 * 각 enemySpawner는 오브젝트 풀링으로 구현되어있음.
 * TimeCheck 함수를 통해 초단위로 제어 가능하도록 구현.
 */

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject spawnerPrefab;

    [SerializeField]
    List<MonsterData> enemyList = new List<MonsterData>();

    //spawner 조작을 위한 리스트
    [SerializeField]
    List<GameObject> spawnerList = new List<GameObject>();

    [SerializeField]
    GameObject player;

    [SerializeField]
    Camera player_Camera;

    [SerializeField]
    List<GameObject> BossList = new List<GameObject>();

    [SerializeField]
    GameObject[] Triggers;

    // 플레이 시간 텍스트
    [SerializeField]
    Text[] timeTexts; // 0 : 분, 1 : 초

    [SerializeField]
    List<bool> flagBoss = new List<bool>();

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

    // 시간에 따른 spawner 조정 함수
    void TimeCheker()
    {
        int min = int.Parse(timeTexts[0].text);
        int sec = int.Parse(timeTexts[1].text);
        if (min % 4 == 0 && sec == 0)
        {
            if (min / 4 == 0)
            {
                ChangeMob(1);
            }
            else if (min / 4 == 1)
            {
                spawnerList[1].SetActive(false);
                ChangeMob(2);
                ChangeMob(3);
                ChangeMob(4);
                ChangeMob(5);
            }
            else if (min / 4 == 2)
            {
                ChangeMob(6);
                spawnerList[2].SetActive(false);
                spawnerList[3].SetActive(false);
                spawnerList[4].SetActive(false);
                spawnerList[5].SetActive(false);
            }
            else if (min / 4 == 3)
            {
                ChangeMob(7);
                spawnerList[6].SetActive(false);
            }
            else if (min / 4 == 4)
            {
                ChangeMob(8);
                spawnerList[7].SetActive(false);
            }

        }
        /*
        if (timeTexts[0].text == "10")
        {
            spawnerList[1].GetComponent<SampleSpawner>().SetMaximum(20);
            spawnerList[1].SetActive(true);
        }*/
        SpawnBoss();
    }

    void ChangeMob(int idx)
    {
        spawnerList[idx].GetComponent<SampleSpawner>().SetMaximum(20);
        spawnerList[idx].SetActive(true);
    }

    void SpawnBoss()
    {
        float radius = 12f;
        int min = int.Parse(timeTexts[0].text);
        int sec = int.Parse(timeTexts[1].text);
        if (min % 5 == 4 && sec == 0)
        {
            float xRange = Random.Range(-6f, 6f);
            float degree = Random.Range(0, 360);
            float yRange = Mathf.Pow(radius * radius - xRange * xRange, 0.5f);
            if (flagBoss[min / 5])
            {
                Instantiate(BossList[min / 5], (player.transform.position) + new Vector3(xRange, yRange, 0), Quaternion.identity);
                flagBoss[min / 5] = false;
            }
                
        }
    }
}
