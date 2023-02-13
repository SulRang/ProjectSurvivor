using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    protected float curTime = 0.0f;
    [SerializeField]
    protected float damage = 1;
    [SerializeField]
    protected float size = 1.0f;
    [SerializeField]
    protected float duration = 3.0f;
    [SerializeField]
    protected float power = 1.0f;
    [SerializeField]
    protected float criticalChance = 1.0f;
    [SerializeField]
    protected float criticalDamage = 1.0f;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        damage *= Player_Status.instance.DMG;         //임시 데미지 수치
        size *= Player_Status.instance.SIZE;
        criticalChance += Player_Status.instance.CRITICAL;
        criticalDamage *= Player_Status.instance.CRITICAL_DMG;

        transform.localScale = new Vector3(size, size, 1);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > duration)
            Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            Attack(collision);
        }
    }
    public void SetDuration(float _duration)
    {
        duration = _duration;
    }
    public void SetSize(float _size)
    {
        size *= _size;
    }

    protected void Attack(Collider2D coll)
    {
        //coll.GetComponent<Rigidbody2D>().AddForce((coll.transform.position - transform.position).normalized * power, ForceMode2D.Impulse);
        if(CriticalHit())
            coll.GetComponent<Monster>().GetDamage(damage * criticalDamage, power);

        coll.GetComponent<Monster>().GetDamage(damage, power);
    }
    
    private bool CriticalHit()
    {
        int n = 0;
        n = Random.Range(0, 1000);
        criticalChance *= 1000;
        return n <= criticalChance;
    }
}
