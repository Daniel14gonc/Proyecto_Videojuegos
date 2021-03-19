using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Zombie : MonoBehaviour
{

    GameObject player;
    NavMeshAgent agent;
    Animator animator;
    public float life;
   
    

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        life = 10.0f;
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        print(life);
        if (agent && player)
        {
            NavMeshHit hits;
            if(NavMesh.SamplePosition(player.transform.position,out hits, 2f, NavMesh.AllAreas))
                agent.SetDestination(hits.position);

        }
            

        if (life <= 0)
        {
            ScoreManager.setScore(ScoreManager.getScore() + 1);
            Destroy(gameObject);
            
        }
    }

    private void FixedUpdate()
    {
        
    }

    public void decreaseLife()
    {
        life-=5.0f;
    }
}
