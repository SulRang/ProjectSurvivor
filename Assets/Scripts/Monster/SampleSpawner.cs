using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public enum MonsterType
{
    Goblin, Golem, Kerberos, Minotauros, Troll
}

public class SampleSpawner : MonoBehaviour
{
    [SerializeField]
    List<MonsterData> monsterDataList;

    [SerializeField]
    GameObject monsterPrefab;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Camera player_Camera;

    [SerializeField]
    int index = 0;

    [SerializeField]
    IObjectPool<Monster> pool;

    public int monster_Num = 0;

    public int maximum = 0;

    private void Awake()
    {
        pool = new ObjectPool<Monster>(CreateMonster, GetMonster, ReleaseMonster, DestroyMonster, maxSize:maximum);
    }

    // Start is called before the first frame update
    void Start()
    {
        monsterPrefab = monsterDataList[index].prefab;
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Spawn()
    {
        //index = Random.Range(0, monsterDataList.Count);
        //Debug.Log("index : " + index);
        monsterPrefab = monsterDataList[index].prefab;
        // var monster = Instantiate(monsterPrefab, new Vector3(Random.Range(-1, 1), 2.5f, 1.5f), Quaternion.identity);
        var monster = pool.Get();
        monster.GetComponent<Monster>().monsterData = monsterDataList[index];
        monster.GetComponent<Monster>().MonsterInfo();
        //player.GetComponent<PlayerController>().PlayerMove();
        ++monster_Num;
    }

    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(1f);

        if (monster_Num < maximum)
        {
            Spawn();
            StartCoroutine(SpawnCoroutine());
        }
        else
        {
            //Debug.Log("최대 생성" + monster_Num);
            StopCoroutine(SpawnCoroutine());
        }
    }

    // 오브젝트 생성
    Monster CreateMonster()
    {
        float screenPoint = ScreenPosition(player_Camera);

        Monster monster = Instantiate(monsterPrefab, new Vector3(Random.Range(-40, 40), screenPoint, 0f),
                            Quaternion.identity).GetComponent<Monster>();
        monster.SetManagedPool(pool);
        return monster;
    }

    // 풀로부터 오브젝트를 가져옴
    void GetMonster(Monster monster)
    {
        monster.gameObject.SetActive(true);
    }

    // 풀에 오브젝트를 반환
    void ReleaseMonster(Monster monster)
    {
        monster.gameObject.SetActive(false);
    }

    //풀에서 오브젝트를 파괴
    void DestroyMonster(Monster monster)
    {
        Destroy(monster.gameObject);
    }

    // 카메라 화면 높이 좌표를 계산
    float ScreenPosition(Camera _camera)
    {
        float distance = Vector3.Distance(player.transform.position, player_Camera.transform.position); // 카메라에서 플레이어까지의 거리
        
        float frustumHeight = distance * Mathf.Tan(player_Camera.fieldOfView * 0.5f * Mathf.Deg2Rad); // 카메라 화면 높이의 절반

        return frustumHeight;
    }


}
