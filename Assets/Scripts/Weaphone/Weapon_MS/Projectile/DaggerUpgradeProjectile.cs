using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerUpgradeProjectile : Projectile
{
    bool isUpgrade = false;
    float count = 0;
    float curT = 0;
    bool isBack = false;
    float speed = 4;

    private void FixedUpdate()
    {
        curT++;
        gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.down * speed * Mathf.Log10(curT));
        if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude > 10f)
        {
            isBack = true;
        }
        else if(isBack)
        {
            if (gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 0.2f)
            {
                transform.Rotate(new Vector3(0, 0, 180));
                isBack = false;
                speed *= -1;
            }
        }
        else
        {
        }
    }

    public void Upgrade()
    {
        isUpgrade = true;
    }
}
