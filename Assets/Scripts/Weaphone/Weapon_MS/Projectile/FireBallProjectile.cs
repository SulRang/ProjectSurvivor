using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallProjectile : Projectile
{
    [SerializeField]
    GameObject ExplosionObj;
    [SerializeField]
    GameObject projectileObj;
    [SerializeField]
    bool isUpgrade = false;

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            OnHitMonster();
            Attack(collision);
        }
    }

    private void OnHitMonster()
    {
        GameObject Explosion = Instantiate(ExplosionObj, transform);
        Explosion.transform.parent = null;
        if (isUpgrade)
        {
            for (int i = 0; i < 8; i++)
            {
                //투사체 개수에 따른 각도 설정
                float degree = 360 / 8 * i;
                float radian = Mathf.Deg2Rad * degree;
                //투사체 생성
                GameObject ProjectileObject = Instantiate(projectileObj, transform);
                ProjectileObject.transform.localPosition = Vector3.zero;
                ProjectileObject.SetActive(true);
                ProjectileObject.transform.parent = null;
                //투사체 지속시간 설정
                ProjectileObject.GetComponent<Projectile>().SetDuration(1.0f);
                //투사체 각도 및 이동 설정
                ProjectileObject.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, degree));
                Vector3 dirVec3 = new Vector3(Mathf.Sin(radian), Mathf.Cos(radian));
                ProjectileObject.GetComponent<Rigidbody2D>().AddForce(dirVec3.normalized * 100);
            }
        }
        Destroy(gameObject);
    }

    public void Upgrade()
    {
        isUpgrade = true;
    }
}
