using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAura : MonoBehaviour
{
    //Monster쪽이 (int)damage 여서 데미지를 1 이하로 설정할 수 없음. 수정 필요.
    [SerializeField]
    float damage = 1f;

    [SerializeField]
    int level = 1;

    [SerializeField]
    Player_Move player;

    void Start()
    {
        //damage *= Player_Status.instance.DMG;
        this.gameObject.transform.SetParent(player.transform);
    }

    /*
    //테스트용. 실제로는 LevelUp을 사용해야함
    private void Update()
    {
        if (level != 1)
        {
            transform.localScale = new Vector2(level * 2f, level * 2f);
        }
    }
    */

    void LevelUp()
    {
        ++level;
        transform.localScale = new Vector2(level * 1.5f, level * 1.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.GetComponent<Monster>().GetDamage((int)damage);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            collision.GetComponent<Monster>().GetDamage((int)damage);
        }
    }
}
