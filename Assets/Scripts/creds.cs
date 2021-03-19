using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class creds : MonoBehaviour
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
            pausem.SetActive(true);

        }
    }


    public void GoMainM()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

}
