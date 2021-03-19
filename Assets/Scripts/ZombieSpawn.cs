using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ZombieSpawn : MonoBehaviour
{
    public GameObject spawns;
    public GameObject zombie;
    public GameObject rounds;

    Text round;
    List<Vector3> spawn;
    int lastSpawn;
    int count;
    float timePeriod;
    float timeCount;
    int roundCount;
    int[] cantidad = { 20, 50};
    bool upload;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        spawn = new List<Vector3>();
        if (spawns)
        {
            foreach (Transform sp in spawns.transform){
                spawn.Add(sp.position);
            }
        }

        timeCount = 0;
        timePeriod = 200;
        count = 0;
        roundCount = 0;
        round = rounds.GetComponent<Text>();
        upload = false;
    }

    // Update is called once per frame
    void Update()
    {
        //print(ScoreManager.getScore());
        round.text = "ROUND " + (roundCount+1);
        if(ScoreManager.getScore() < cantidad[roundCount])
        {
            if (count < cantidad[roundCount])
            {
                print(count);
                if (timeCount == timePeriod)
                {
                    int sp = Random.Range(0, spawn.Count);
                    while (sp == lastSpawn)
                        sp = Random.Range(0, spawn.Count);

                    lastSpawn = sp;

                    if (zombie)
                    {
                        Instantiate(zombie, spawn[lastSpawn], Quaternion.identity);
                        count++;
                        timeCount = 0;
                    }
                }
            }
            timeCount++;
            upload = false;
        }
        else if(ScoreManager.getScore() == cantidad[roundCount] && !upload)
        {
            count = cantidad[roundCount];
            timeCount = 0;
            roundCount++;
            print(roundCount +" round" );
            upload = true;
        }

        if(roundCount==2 && level==1)
        {
            level++;
            SceneManager.LoadScene(5);
        }else if(roundCount == 2 && level==2)
        {
            SceneManager.LoadScene(6);
        }




    }

    private void FixedUpdate()
    {

    }

    public int getRoundCount()
    {
        return roundCount;
    }
}
