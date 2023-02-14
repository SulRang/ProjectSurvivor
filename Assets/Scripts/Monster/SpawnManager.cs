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

    // 몬스터 체력 배열.
    int[] monsterHp = { 20, 20, 60, 60, 60, 60, 80, 150, 120 };

    private void Awake()
    {
        InitSpawner();
    }

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
            spawner.GetComponent<SampleSpawner>().SetMonsterData(enemyList[i]);
            spawner.GetComponent<SampleSpawner>().SetMonsterHp(monsterHp[i]);
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
            //시작
            if (min / 4 == 0)
            {
                spawnerList[0].GetComponent<SampleSpawner>().SetCooltime(1.0f);
                spawnerList[1].GetComponent<SampleSpawner>().SetCooltime(1.5f);
                spawnerList[1].GetComponent<SampleSpawner>().SetMaximum(30);
                ChangeMob(0);
                ChangeMob(1);
            }
            // 4분 경과
            else if (min / 4 == 1)
            {
                // 고블린 제거. 골렘 추가
                spawnerList[0].SetActive(false);
                spawnerList[1].SetActive(false);
                spawnerList[4].GetComponent<SampleSpawner>().SetCooltime(2f);
                spawnerList[5].GetComponent<SampleSpawner>().SetCooltime(2f);
                ChangeMob(2);
                ChangeMob(3);
                ChangeMob(4);
                ChangeMob(5);
            }
            // 8분 경과
            else if (min / 4 == 2)
            {
                // kerberos 추가
                ChangeMob(6);

                // 골렘 생성시간 단축, 수 감소, hp 증가
                for (int i = 2; i < 6; i++)
                {
                    spawnerList[i].GetComponent<SampleSpawner>().SetCooltime(1f);
                    spawnerList[i].GetComponent<SampleSpawner>().SetMaximum(30);
                    spawnerList[i].GetComponent<SampleSpawner>().SetMonsterHp(80);
                }
            }
            // 12분 경과
            else if (min / 4 == 3)
            {
                // kerberos, 골렘 2종류 제거. mino 추가
                ChangeMob(7);

                spawnerList[4].GetComponent<SampleSpawner>().SetMaximum(50);
                spawnerList[5].GetComponent<SampleSpawner>().SetMaximum(50);

                spawnerList[2].SetActive(false);
                spawnerList[3].SetActive(false);
                spawnerList[6].SetActive(false);

            }
            // 16분 경과
            else if (min / 4 == 4)
            {
                // mino제거. troll 추가
                ChangeMob(8);
                spawnerList[7].SetActive(false);
                spawnerList[4].GetComponent<SampleSpawner>().SetMaximum(40);
                spawnerList[5].GetComponent<SampleSpawner>().SetMaximum(40);
                spawnerList[4].GetComponent<SampleSpawner>().SetMonsterHp(120);
                spawnerList[5].GetComponent<SampleSpawner>().SetMonsterHp(120);
            }
        }

        SpawnBoss();
    }

    void ChangeMob(int idx)
    {
        //spawnerList[idx].GetComponent<SampleSpawner>().SetMaximum(20);
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
