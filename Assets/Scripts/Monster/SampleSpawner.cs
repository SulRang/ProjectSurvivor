using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class SampleSpawner : MonoBehaviour
{
    [SerializeField]
    List<MonsterData> monsterDataList;

    [SerializeField]
    MonsterData curMonster;

    [SerializeField]
    GameObject monsterPrefab;

    [SerializeField]
    IObjectPool<Monster> pool;

    [SerializeField]
    float cooltime = 1.5f;

    [SerializeField]
    public GameObject[] triggers;

    [SerializeField]
    int monster_Num = 0;

    // �ִ� ���� ���� ��. �⺻ 40����
    [SerializeField]
    int maximum = 40;

    private void Awake()
    {
        pool = new ObjectPool<Monster>(CreateMonster, GetMonster, ReleaseMonster, DestroyMonster, maxSize:maximum);
    }

    void Start()
    {
        monsterPrefab = curMonster.prefab;
        StartCoroutine(SpawnCoroutine());
    }

    public void Spawn()
    {
        var monster = pool.Get();
        monster.GetComponent<Monster>().monsterData = curMonster;
        ++monster_Num;
    }

    // �� ���� �ڷ�ƾ
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(cooltime); // ��Ÿ�� �⺻ 1.5��


        if (monster_Num < maximum)
        {
            Spawn();
        }

        StartCoroutine(SpawnCoroutine()); // ������ �ð����� ����
    }

    // ������Ʈ ����
    Monster CreateMonster()
    {        
        Monster monster;
        monster = Instantiate(monsterPrefab, transform.position, Quaternion.identity).GetComponent<Monster>();
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
        --monster_Num;
    }

    //Ǯ���� ������Ʈ�� �ı�
    void DestroyMonster(Monster monster)
    {
        Destroy(monster.gameObject);
    }

    public void SetMonsterData(MonsterData _monsterData)
    {
        curMonster = _monsterData;
    }

    public void SetMaximum(int _maximum)
    {
        maximum = _maximum;
    }

    public void SetCooltime(float _cooltime)
    {
        cooltime = _cooltime;
    }

    public void SetMonsterHp(int _hp)
    {
        curMonster.hp = _hp;
    }
}
