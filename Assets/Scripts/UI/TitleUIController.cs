using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void OnClickExitBtn()
    {

    }
    public void OnClickTitleBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
