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
        //���� ���� ������ ��� �ϴ� Duration ����߽��ϴ�.
        player.UpgradeStatus("Duration", Upgrade);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
