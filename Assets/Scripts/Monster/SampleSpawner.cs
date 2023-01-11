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
    IObjectPool<Monster> pool;

    private void Awake()
    {
        pool = new ObjectPool<Monster>(CreateMonster, GetMonster, ReleaseMonster, DestroyMonster, maxSize:20);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        int index = Random.Range(0, monsterDataList.Count);
        Debug.Log("index : " + index);
        monsterPrefab = monsterDataList[index].prefab;
        // var monster = Instantiate(monsterPrefab, new Vector3(Random.Range(-1, 1), 2.5f, 1.5f), Quaternion.identity);
        var monster = pool.Get();
        monster.GetComponent<Monster>().monsterData = monsterDataList[index];
        monster.GetComponent<Monster>().MonsterInfo();
        player.GetComponent<PlayerController>().PlayerMove();
    }

    // ������Ʈ ����
    Monster CreateMonster()
    {
        Monster monster = Instantiate(monsterPrefab).GetComponent<Monster>();
        monster.SetManagedPool(pool);
        return monster;
    }

    // Ǯ�κ��� ������Ʈ�� ������
    void GetMonster(Monster monster)
    {
        monster.gameObject.SetActive(true);
    }

    // Ǯ�� ������Ʈ�� ��ȯ
    void ReleaseMonster(Monster monster)
    {
        monster.gameObject.SetActive(false);
    }

    //Ǯ���� ������Ʈ�� �ı�
    void DestroyMonster(Monster monster)
    {
        Destroy(monster.gameObject);
    }


}
