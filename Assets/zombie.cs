using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class zombie : MonoBehaviour
{
    NavMeshAgent zombiee;
    public GameObject lugares;
    public GameObject pers;
    List<Vector3> listlug;
    int pos = 0;

    // Start is called before the first frame update
    void Start()
    {
        zombiee = GetComponent<NavMeshAgent>();
        listlug = new List<Vector3>();
        if (lugares)
            foreach (Transform child in lugares.transform)
                listlug.Add(child.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (zombiee)
        {
            zombiee.SetDestination(pers.transform.position);
            /*if (zombiee.remainingDistance < 0.5f)
            {
                pos++;
                pos = pos % listlug.Count;
                zombiee.SetDestination(pers.transform.position);
            }*/
        }

    }
}
