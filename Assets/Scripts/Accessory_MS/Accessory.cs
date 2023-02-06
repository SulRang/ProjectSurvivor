using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessory : MonoBehaviour
{
    [SerializeField]
    protected string statusName;
    [SerializeField]
    protected float statusValue;
    [SerializeField]
    int level = 1;
    // Start is called before the first frame update
    void Start()
    {
        Player_Status.instance.UpgradeStatus(statusName, statusValue);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void LevelUp()
    {
        level++;
        Player_Status.instance.UpgradeStatus(statusName, statusValue);
    }
}
