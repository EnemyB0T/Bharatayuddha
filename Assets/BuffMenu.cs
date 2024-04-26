using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BuffMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;

    public GameObject buffMenuUI;

/*     void Start()
    {
        Time.timeScale = 1;
    } */
public void BuffMenuUI(){
        buffMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
}

    public void Resume()
    {
        buffMenuUI.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }

    void Pause()
    {
        buffMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}