using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
public class MainCharacter : MonoBehaviour
{
    public GameObject pressF;
    public GameObject powerUps;
    public GameObject shot;
    public GameObject life;
    
    AudioSource disparo;
    List<GameObject> power;
    Animator animator;
    Animator temp;
    Rigidbody rb;
    ParticleSystem shots;
    float force = 5.0f;
    bool boxTrigg;
    bool inmune;
    int inmuneTime;
    int inmuneCont;
    bool closed;
    Slider bar;
    Image image;

    // Start is called before the first frame update
    void Start()
    {

        disparo = GetComponent<AudioSource>();
        power = new List<GameObject>();
        ScoreManager.setScore(0);
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        foreach (Transform child in powerUps.transform)
            power.Add(child.gameObject);
        inmune = false;
        inmuneTime = 20;
        inmuneCont = 20;
        Animator temp = animator;
        closed = true;
        shots = shot.GetComponent<ParticleSystem>();
        bar = life.GetComponent<Slider>();
        LifeManager.setLife(300);

        foreach (Transform child in life.transform)
        {
            if (child.gameObject.CompareTag("Life"))
            {
                image = child.gameObject.GetComponent<Image>();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inmuneCont < inmuneTime)
        {
            image.color = Color.blue;
        }

        bar.value = LifeManager.getLife()/300.0f;

        if(inmuneCont >= inmuneTime && inmune)
        {
            image.color = Color.green;
            inmune = false;
        }

        if (rb)
            rb.AddForce(Input.GetAxis("Vertical") * force, 0, Input.GetAxis("Horizontal") * force);
        //animator.SetFloat("Run", Mathf.Abs(rb.velocity.x));

        Ray myRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if(Physics.Raycast(myRay, out hitInfo, 20.0f) && Input.GetMouseButtonDown(0))
        {

            animator.SetBool("Shooting", true);
            shots.Play();
            disparo.Play();
            if (hitInfo.collider.CompareTag("Zombie"))
            {

                hitInfo.collider.gameObject.GetComponent<Zombie>().decreaseLife();
            }
        }

        //animator.SetBool("Shooting", false);

        if (Input.GetKeyDown(KeyCode.F) && boxTrigg)
        {
            pressF.SetActive(false);
            int eleccion = Random.Range(0, 2);
            GameObject boxSup = GameObject.FindGameObjectWithTag("BoxSupplies").GetComponent<Box>().getActualBox();
            temp = boxSup.GetComponent<Animator>();
            temp.SetBool("Open", true);
            Box.soncaja();
            if (eleccion == 0)
            {
                LifeManager.setLife(30);
            }
            else
            {
                inmune = true;
                inmuneCont = 0;
            }
            power[eleccion].SetActive(true);
            closed = false;
            GameObject.FindGameObjectWithTag("BoxSupplies").GetComponent<Box>().looted();
        }


        if (!closed && Input.GetKeyDown(KeyCode.Escape))
        {
            foreach(GameObject child in power)
            {
                child.SetActive(false);
            }
            temp.SetBool("Open", false);
            closed = true;
  
        }

        if(LifeManager.getLife() < 0)
        {
            Puntos.sonmuere();
            Destroy(gameObject);
        }

        inmuneCont++;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TriggerBox"))
        {
            boxTrigg = true;
            pressF.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("TriggerBox"))
        {
            boxTrigg = false;
            pressF.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zombie") && !inmune)
        {
            LifeManager.setLife(-5);
        }
    }
}
