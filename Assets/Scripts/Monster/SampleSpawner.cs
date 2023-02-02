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
    MonsterData curMonster;

    [SerializeField]
    GameObject monsterPrefab;

    [SerializeField]
    GameObject player;

    [SerializeField]
    Camera player_Camera;

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
        monsterPrefab = curMonster.prefab;
        StartCoroutine(SpawnCoroutine());
    }

    public void Spawn()
    {
        //monsterPrefab = monsterDataList[index].prefab;
        var monster = pool.Get();
        monster.GetComponent<Monster>().monsterData = curMonster;
        //monster.GetComponent<Monster>().ReadyDestroy();
        ++monster_Num;
    }

    // �� ���� �ڷ�ƾ
    IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSeconds(0.5f);


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
        Vector3 position = Positioning();

        monster = Instantiate(monsterPrefab, position, Quaternion.identity).GetComponent<Monster>();
        monster.SetManagedPool(pool);
        return monster;
    }

    // Ǯ�κ��� ������Ʈ�� ������
    void GetMonster(Monster monster)
    {
        InitMonster(monster);
        monster.gameObject.SetActive(true);
    }

    // Ǯ�� ������Ʈ�� ��ȯ
    void ReleaseMonster(Monster monster)
    {
        monster.gameObject.SetActive(false);
        --monster_Num;
        //Debug.Log("��ȯ. " + monster_Num);
    }

    //Ǯ���� ������Ʈ�� �ı�
    void DestroyMonster(Monster monster)
    {
        Destroy(monster.gameObject);
    }

    // ī�޶� ȭ�� ���� ��ǥ�� ���
    float ScreenPosition()
    {
        float distance = Vector3.Distance(player.transform.position, player_Camera.transform.position); // ī�޶󿡼� �÷��̾������ ��
        float frustumHeight = distance * Mathf.Tan(player_Camera.fieldOfView * 0.5f * Mathf.Deg2Rad) * 1.2f + 
            (player.transform.position.y > 0 ? player.transform.position.y : player.transform.position.y * -1f) * 1.5f; // ī�޶� ȭ�� ������ ����

        return frustumHeight;
        
    }

    Vector3 Positioning()
    {
        // ��, ���� : 0, �Ʒ�, ������ : 1
        int posIndex = Random.Range(0, 2);

        int insIndex = Random.Range(0, 2);

        Vector3 calPos;
        float screenPoint = ScreenPosition();

        if (posIndex == 0) // ��, ����
        {
            calPos = (insIndex == 0) ? new Vector3(Random.Range(-15f, 15f), screenPoint, 0f) : new Vector3(screenPoint * 1.5f, Random.Range(-10f, 10f), 0f);

        }
        else // �Ʒ�, ������
        {
            calPos = (insIndex == 0) ? new Vector3(Random.Range(-15f, 15f), -screenPoint, 0f) : new Vector3(-screenPoint * 1.5f, Random.Range(-10f, 10f), 0f);
        }

        return calPos;
    }

    void InitMonster(Monster _monster)
    {
        _monster.gameObject.transform.position = Positioning();
    }

    public void SetPlayer(GameObject _player)
    {
        player = _player;
    }

    public void SetPlayerCamera(Camera _playercamera)
    {
        player_Camera = _playercamera;
    }

    public void SetMonsterData(MonsterData _monsterData)
    {
        curMonster = _monsterData;
    }

    public void SetMaximum(int _maximum)
    {
        maximum = _maximum;
    }
}
