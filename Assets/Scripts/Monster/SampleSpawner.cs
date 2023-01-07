using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        var monster = Instantiate(monsterPrefab, new Vector3(Random.Range(-1, 1), 2.5f, 1.5f), Quaternion.identity);
        monster.GetComponent<Monster>().monsterData = monsterDataList[index];
        monster.GetComponent<Monster>().MonsterInfo();
        player.GetComponent<PlayerController>().PlayerMove();
    }

}
