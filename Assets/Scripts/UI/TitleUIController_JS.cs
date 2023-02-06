using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleUIController_JS : MonoBehaviour
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
        SceneManager.LoadScene("InGameTestScene_JS");
        gameObject.transform.GetChild(0).gameObject.SetActive(false);
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
