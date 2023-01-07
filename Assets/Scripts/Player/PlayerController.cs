using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayerMove()
    {
        transform.position = new Vector3(Random.Range(-7f, 7f), Random.Range(-7f, 7f), 1.5f);
    }

}
