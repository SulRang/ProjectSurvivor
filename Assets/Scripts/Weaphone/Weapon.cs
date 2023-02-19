using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weaphone : MonoBehaviour
{
    public float level = 0f;
    [SerializeField]
    protected GameObject projectile;
    protected float speed = 10.0f;
    protected float cooldown = 5.0f;
    protected float cooltime = 0;
    protected float projectileNum = 1;
    protected float prevProjectileCount = 0;
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
        //°ø°Ý Äð´Ù¿î
        SetCoolDown(cooldown * (1.0f - Player_Status.instance.COOLDOWN));
        SetProjectileNum(projectileNum);
    }

    protected void FixedUpdate()
    {
        if (prevProjectileCount != Player_Status.instance.PROJECTILE_COUNT)
        {
            projectileNum += Player_Status.instance.PROJECTILE_COUNT - prevProjectileCount;
            prevProjectileCount = Player_Status.instance.PROJECTILE_COUNT;
        }
    }

    IEnumerator AttackCoolDown()
    {
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

    public void SetProjectileNum(float value)
    {
        projectileNum = value + Player_Status.instance.PROJECTILE_COUNT;
    }
    public void SetSpeed(float value)
    {
        speed = value;
    }

    public void SetCoolDown(float value)
    {
        cooldown = value * (1.0f - Player_Status.instance.COOLDOWN);
    }
}
