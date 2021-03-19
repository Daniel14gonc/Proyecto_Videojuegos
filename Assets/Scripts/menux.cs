using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menux : MonoBehaviour
{
    // Start is called before the first frame update
    public void Openscene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
