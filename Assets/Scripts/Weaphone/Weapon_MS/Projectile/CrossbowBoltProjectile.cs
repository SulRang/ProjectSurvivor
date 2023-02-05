using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossbowBoltProjectile : Projectile
{
    bool isUpgrade = false;
    float speed = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isUpgrade && collision.gameObject.tag == "Trigger")
        {
            if (collision.name == "Trigger_up" || collision.name == "Trigger_right")
            {
                if (gameObject.transform.rotation.eulerAngles.z < 180)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * 10 * speed);
                    gameObject.transform.Rotate(new Vector3(0, 0, 90));
                }
                else
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 10 * speed);
                    gameObject.transform.Rotate(new Vector3(0, 0, -90));
                }

            }
            if (collision.name == "Trigger_down" || collision.name == "Trigger_left")
            {
                if (gameObject.transform.rotation.eulerAngles.z > 180)
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.left * 10 * speed);
                    gameObject.transform.Rotate(new Vector3(0, 0, 90));
                }
                else
                {
                    gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                    gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.right * 10 * speed);
                    gameObject.transform.Rotate(new Vector3(0, 0, -90));
                }

            }
        }
        if(collision.tag == "Monster")
        {
            collision.GetComponent<Rigidbody2D>().AddForce((collision.transform.position - transform.position).normalized * power, ForceMode2D.Impulse);
            collision.GetComponent<Monster>().GetDamage(damage);
        }
    }

    public void Upgrade()
    {
        isUpgrade = true;
    }
}
