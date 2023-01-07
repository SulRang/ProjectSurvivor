using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField]
    public MonsterData monsterData;

    [SerializeField]
    Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos.position, monsterData.moveSpeed*Time.deltaTime);
    }

    public void MonsterInfo()
    {
        Debug.Log("------------------------------");
        Debug.Log("�̸� :: " + monsterData.monsterName);
        Debug.Log("ü�� :: " + monsterData.hp);
        Debug.Log("���ݷ� :: " + monsterData.damage);
        Debug.Log("�̵��ӵ� :: " + monsterData.moveSpeed);
        Debug.Log("������ :: " + monsterData.size);
    }

}
