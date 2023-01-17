using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    float curTime = 0.0f;
    [SerializeField]
    float damage = 1;
    [SerializeField]
    float size = 2.0f;
    [SerializeField]
    float duration = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(size, size, 1);
        damage *= Player_Status.instance.DMG;         //임시 데미지 수치
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
            collision.GetComponent<Monster>().GetDamage((int)damage);
        }
    }
    public void SetDuration(float _duration)
    {
        duration = _duration;
    }
}
