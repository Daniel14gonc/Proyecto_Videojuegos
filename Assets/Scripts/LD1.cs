using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LD1 : MonoBehaviour
{
    public GameObject slider;
    public int scene;
    Image bar;

    // Start is called before the first frame update
    void Start()
    {
        bar = slider.GetComponent<Image>();
        StartCoroutine(LoadAsyncOperation());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadAsyncOperation()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scene);

        while (operation.progress < 1)
        {
            bar.fillAmount = operation.progress;

            yield return new WaitForEndOfFrame();
        }
    }
}
