using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Puntos : MonoBehaviour
{
    public static AudioSource muere;

    public Text puntostext;

    // Start is called before the first frame update
    void Start()
    {
        muere = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (puntostext)
            puntostext.text = ScoreManager.getScore().ToString();
    }

    public static void sonmuere()
    {
        muere.Play();
    }
}
