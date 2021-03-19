using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class magia : MonoBehaviour
{
    public Image negro;
    public Button menu;
    // Start is called before the first frame update
    void Start()
    {
        negro.canvasRenderer.SetAlpha(0.0f);
        fadeIn();
        menu.enabled = true;

    }

    // Update is called once per frame
    void fadeIn()
    {
        negro.CrossFadeAlpha(1, 4, false);
        
        
    }

  
}
