using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryRing : MonoBehaviour
{
    Player_Status player;

    public int Upgrade = 1;

    // Start is called before the first frame update
    void Start()
    {
        //공격 범위 증가가 없어서 일단 Duration 사용했습니다.
        player.UpgradeStatus("Duration", Upgrade);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
