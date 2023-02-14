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
        //����ü �θ� ������Ʈ ����
        ProjectileObject.transform.parent = null;
        ProjectileObject.SetActive(true);
        //����ü ���� �ð� ����
        ProjectileObject.GetComponent<Projectile>().SetDuration(1.5f);
        Destroy(gameObject);
    }
}
