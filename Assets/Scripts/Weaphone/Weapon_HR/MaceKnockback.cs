using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaceKnockback : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Monster")
        {
            Vector3 interV = collision.transform.position - transform.position;
            collision.GetComponent<Rigidbody2D>().AddForce(new Vector3(interV.normalized.x, interV.normalized.y) * 1, ForceMode2D.Impulse);
        }
    }
}
