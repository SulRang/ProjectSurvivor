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
        Debug.Log("이름 :: " + monsterData.monsterName);
        Debug.Log("체력 :: " + monsterData.hp);
        Debug.Log("공격력 :: " + monsterData.damage);
        Debug.Log("이동속도 :: " + monsterData.moveSpeed);
        Debug.Log("사이즈 :: " + monsterData.size);
    }

}
