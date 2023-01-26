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

    // 플레이 시간 텍스트
    [SerializeField]
    Text[] timeTexts; // 0 : 초, 1 : 분

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
        if (timeTexts[0].text == "10")
        {
            spawnerList[1].GetComponent<SampleSpawner>().SetMaximum(5);
            spawnerList[1].SetActive(true);
        }
    }
}
