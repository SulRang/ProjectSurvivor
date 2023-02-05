using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerTurning : MonoBehaviour
{
    int max = 1;
    int count = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Monster")
        {
            Collider2D[] Cols;
            int Radius = 5;
            Cols = Physics2D.OverlapCircleAll(transform.position, Radius);

            if (count++ < max)
            {
                for (int i = 0; i < Cols.Length; i++)
                {
                    if (Cols[i].tag == "Monster")
                    {
                        Vector3 interV = Cols[i].transform.position - transform.position;
                        float theta = Mathf.Acos(interV.normalized.x);
                        float degree = interV.normalized.y > 0 ? Mathf.Rad2Deg * theta : Mathf.Rad2Deg * theta * (-1);

                        gameObject.GetComponent<Rigidbody2D>().velocity = Vector3.zero;

                        gameObject.transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree));
                        gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector3(interV.normalized.x, interV.normalized.y) * 500);
                        break;
                    }
                }
            }
        }
    }

    public void SetMax(int num)
    {
        max = num;
    }
}
