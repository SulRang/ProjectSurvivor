using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaphone : MonoBehaviour
{
    [SerializeField]
    protected GameObject projectile;
    protected float speed = 10.0f;
    protected float cooldown = 5.0f;
    protected float cooltime = 0;
    protected int projectileNum = 1;
    protected float range = 2.0f;

    IEnumerator AttackCoroutine = null;
    // Start is called before the first frame update
    protected virtual void Start()
    {
        if (AttackCoroutine == null)
        {
            AttackCoroutine = AttackCoolDown();
            StartCoroutine(AttackCoroutine);
        }
    }

    IEnumerator AttackCoolDown()
    {
        Debug.Log("Start Attack Coroutine");
        while (true)
        {
            cooltime += Time.deltaTime;
            if (cooltime >= cooldown)
            {
                cooltime -= cooldown;
                Attack();
            }
            yield return new WaitForSeconds(0);
        }
    }


    public virtual void Attack()
    {

    }

    public void SetProjectileNum(int value)
    {
        projectileNum = value;
    }
    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetCoolDown(float value)
    {
        cooldown = value;
    }
}
