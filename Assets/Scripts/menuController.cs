using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class menuController : MonoBehaviour
{
    Text HighScoreText;
    public Animator transitionAnim;
    Scene m_Scene;
    string sceneName;

    void Start() {
        HighScoreText = GameObject.Find("HighScoreText").GetComponent<Text>();
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        if(sceneName=="menu")
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }    
    }

    void Update() {
        HighScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore",0).ToString();
        if(sceneName!="menu")
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                StartCoroutine(LoadScene("menu"));
            }   
        }
    }

    public void changeScene(string scenename)
    {
        StartCoroutine(LoadScene(scenename));
    }

    IEnumerator LoadScene(string scenename)
    {
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(scenename);
    }

    public void openFacebook()
    {
        Application.OpenURL ("https://www.facebook.com/999.Monsters");
    }

    public void openYoutube()
    {
        Application.OpenURL ("https://www.youtube.com/channel/UCw-W_EJlrk2bWcqQWjUh7KA");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
