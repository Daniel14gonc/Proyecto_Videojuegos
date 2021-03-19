using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausem;
    public bool ispaused;
    
    // Start is called before the first frame update
    void Start()
    {
        pausem.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (ispaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pausem.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }

    public void ResumeGame()
    {
        pausem.SetActive(false);
        Time.timeScale = 1f;
        ispaused = false;
    }

    public void GoMainM()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitG()
    {
        Application.Quit();
    }
}
