using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Box : MonoBehaviour
{

    public GameObject boxes;
    List<GameObject> bx;
    GameObject actualBox;
    List<GameObject> childs;
    int election;
    bool done;
    public static AudioSource caja;
    

    // Start is called before the first frame update
    void Start()
    {
        
        caja = GetComponent<AudioSource>();
        childs = new List<GameObject>();
        bx = new List<GameObject>();
        foreach (Transform box in boxes.transform)
            bx.Add(box.gameObject);

        done = false;
    }

    // Update is called once per frame
    void Update()
    {
        setBox();
    }

    private void setBox()
    {
        int score = ScoreManager.getScore();
        if ((ScoreManager.getScore()%10 == 0) && !done)
        {
            //print("entra");
            election = Random.Range(0, bx.Count);
            actualBox = bx[election];
            foreach (Transform child in bx[election].transform)
            {
                if (child.gameObject.CompareTag("BoxLight") || child.gameObject.CompareTag("TriggerBox"))
                {
                    childs.Add(child.gameObject);
                    child.gameObject.SetActive(true);
                }
            }

            done = true;
            showBox();
        }
        else if(ScoreManager.getScore() % 10 != 0)
            done = false;


    }

    private void showBox()
    {
        for (int i = 0; i < boxes.transform.childCount; i++)
        {
            if (i != election)
            {
                foreach (Transform child in bx[i].transform)
                {
                    if (child.gameObject.CompareTag("BoxLight") || child.gameObject.CompareTag("TriggerBox"))
                    {
                        child.gameObject.SetActive(false);
                    }
                }
            }
        }
    }

    public static void soncaja()
    {
        caja.Play();
    }

 

    public GameObject getActualBox()
    {
        return actualBox;
    }

    public void looted()
    {
        foreach (GameObject child in childs)
        {
            child.SetActive(false);
        }
    }
}
