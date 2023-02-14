using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightningProjectile : Projectile
{
    [SerializeField]
    int count = 0;
    [SerializeField]
    GameObject projectile;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            count++;
            if (count > 1)
                OnHitMonster(collision);
        }
    }

    private void OnHitMonster(Collider2D collision)
    {
        Attack(collision);
        GameObject ProjectileObject = Instantiate(projectile, collision.transform);
        //투사체 부모 오브젝트 제거
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);
        //투사체 지속 시간 설정
        ProjectileObject.GetComponent<Projectile>().SetDuration(1.5f);
        Destroy(gameObject);
    }
}
