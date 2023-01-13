using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float curTime = 0.0f;
    [SerializeField]
    int damage = 10;
    [SerializeField]
    float size = 2.0f;
    [SerializeField]
    float duration = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(size, size, 1);
    }

    // Update is called once per frame
    void Update()
    {
        curTime += Time.deltaTime;
        if (curTime > duration)
            Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.gameObject.tag == "Monster")
        {
            collision.collider.GetComponent<MonsterData>().hp -= damage;
        }
    }
    public void SetDuration(float _duration)
    {
        duration = _duration;
    }
}
