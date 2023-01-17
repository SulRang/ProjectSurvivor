using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaphoneCenter : MonoBehaviour
{
    [SerializeField]
    Transform player;

    [SerializeField]
    ArrayList targetList = new ArrayList();

    [SerializeField]
    Transform closeTarget;
    [SerializeField]
    float height;

    float distanceA = 0;
    float distanceB = 0;

    [SerializeField]
    Transform randomTarget;
    void FixedUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, height, 0);
    }

    /// <summary>
    /// ���� ���� �� �� ���� ����� ���� Ÿ������ �ϴ� �Լ�
    /// </summary>
    void FindCloseTarget()
    {
        if (targetList.Count <= 0)
        {
            closeTarget = null;
            return;
        }
        distanceA = float.MaxValue;
        foreach (Transform target in targetList)
        {
            distanceB = Vector3.Distance(transform.position, target.position);
            if (distanceA > distanceB)
            {
                closeTarget = target;
                distanceA = distanceB;
            }
        }
    }

    /// <summary>
    /// ���� ���� �� �� ������ ���� Ÿ������ �ϴ� �Լ�
    /// </summary>
    void FindRandomTarget()
    {
        if (targetList.Count <= 0)
        {
            randomTarget = null;
            return;
        }
        int randomIdx = Random.Range(0, targetList.Count);
        randomTarget = (Transform)targetList[randomIdx];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            targetList.Add(collision.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Monster")
        {
            targetList.Remove(collision.transform);
        }
    }

    //����� �� ����
    public Transform GetCloseTarget()
    {
        FindCloseTarget();
        return closeTarget;
    }
    //������ �� ����
    public Transform GetRandomTarget()
    {
        FindRandomTarget();
        return randomTarget;
    }

}
