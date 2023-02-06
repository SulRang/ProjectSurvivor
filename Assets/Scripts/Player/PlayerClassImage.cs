using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClassImage : MonoBehaviour
{
    SkinnedMeshRenderer skinnedMesh;
    [SerializeField]
    List<Texture2D> texture2D = new List<Texture2D>();
    // Start is called before the first frame update
    void Start()
    {
        skinnedMesh = gameObject.transform.GetChild(1).GetComponent<SkinnedMeshRenderer>();
        ChangeClass(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeClass(int idx)
    {
        skinnedMesh.sharedMaterial.mainTexture = texture2D[idx];
    }
}
