using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainLightning : Projectile
{
    [SerializeField]
    GameObject ChainLightningObj;
    [SerializeField]
    Collider2D[] colls;
    [SerializeField]
    bool isUpgrade = true;
    float radius = 5.0f;
    int count = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            OnHitMonster(collision);
        }
    }

    private void OnHitMonster(Collider2D collision)
    {
        colls = Physics2D.OverlapCircleAll(collision.transform.position, radius);
        for(int i = 0; i < colls.Length; i++)
        {
            if (colls[i].gameObject.tag == "Monster" && colls[i] != collision)
            {
                ActiveChain(colls[i].gameObject);
                count++;
                if (count > 3)
                    break;
            }
        }
    }

    private void ActiveChain(GameObject col)
    {
        Vector3 difVec3 = transform.position - col.transform.position;
        GameObject gameobject = Instantiate(ChainLightningObj, transform);
        gameobject.transform.parent = null;

        gameobject.GetComponent<Projectile>().SetDuration(2.0f);
        //투사체 각도 및 이동 설정
        gameobject.transform.Rotate(new Vector3(0, 0, Quaternion.FromToRotation(Vector3.up, difVec3).eulerAngles.z));
        gameobject.GetComponent<Rigidbody2D>().AddForce(difVec3.normalized * -600);

        
    }
}
