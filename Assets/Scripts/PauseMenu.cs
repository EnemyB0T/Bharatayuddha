using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject buffMenuUI;
    private WaveManager wm;
    private BuffMenu bm;
  
/*     void Start()
    {
        Time.timeScale = 1;
    } */
    void Start(){
         wm = FindObjectOfType<WaveManager>();
          bm = FindObjectOfType<BuffMenu>();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        wm.BuffMenu.SetActive(false);
        Time.timeScale = 1.0f;
        GameIsPaused = false;
    }
public void Pause()
    {
        
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
       

    }
    public IEnumerator PauseBuff()
    {
        
        wm.BuffMenu.SetActive(true);
        Time.timeScale = 0.0f;
        GameIsPaused = true;
      
         yield return new WaitForSeconds(1.5f);
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            
            if(GameIsPaused)
            {
                Resume();
            }else
            {
                Pause();
            }
        } 
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
