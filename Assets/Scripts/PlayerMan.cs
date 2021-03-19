using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMan : MonoBehaviour
{
    public GameObject p1;
    public GameObject p2;

    // Start is called before the first frame update
    void Start()
    {
        print(Prueba.pr());
        if (Prueba.pr() == 1)
            p1.SetActive(true);
        else
            p2.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
