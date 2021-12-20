using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject pauseMenuUI;
    public GameObject remover;
    public GameObject option;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && option.activeInHierarchy == false)
        {
        if(isPaused)
        {
            Continue();
        } else
        {
            pauseM();
        }
        }  
    }

    public void Continue()
    {
        remover.SetActive(true);
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void pauseM()
    {
        remover.SetActive(false);  
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void Exit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
    public void levelLoad(int level){
        SceneManager.LoadScene(level);
    }
    public void menu(){
        SceneManager.LoadScene(0);
    }
}
