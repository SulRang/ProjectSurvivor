using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Monster Data", menuName = "Scriptable Object/Monster Data", order = 1)]
public class MonsterData : ScriptableObject
{
    [SerializeField]
    public string monsterName;

    [SerializeField]
    public int hp;

    [SerializeField]
    public float moveSpeed;

    [SerializeField]
    public int damage;

    [SerializeField]
    public float size;

    [SerializeField]
    public GameObject prefab;
}
