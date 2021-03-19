using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fadeUI : MonoBehaviour
{
    private bool mfaded;
    public float duration = 0.4f;
    public GameObject canv;
    // Start is called before the first frame update
    void Start()
    {
        //canv.SetActive(false);
    }
    public void Fade()
    {
        var canvGroup = GetComponent<CanvasGroup>();
        StartCoroutine(Fade(canvGroup, canvGroup.alpha, mfaded ? 0: 1));
        mfaded = !mfaded;
        print("hola");
    }

    public IEnumerator Fade(CanvasGroup canvg, float start, float end)
    {
        float counter = 0f;
        while(counter < duration)
        {
            counter += Time.deltaTime;
            canvg.alpha = Mathf.Lerp(start, end, counter / duration);
            yield return null;
        }
    }
}
