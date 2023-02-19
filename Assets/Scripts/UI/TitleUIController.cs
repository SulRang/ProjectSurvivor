using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("MainGameScene");
        //gameObject.transform.GetChild(0).gameObject.SetActive(false);
    }
    public void OnClickExitBtn()
    {
        Application.Quit();
    }
    public void OnClickTitleBtn()
    {
        SceneManager.LoadScene("TitleScene");
    }
}
