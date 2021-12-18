using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody rbPlayer;
	private Vector3 direction = Vector3.zero;
    public Vector3 lastDirection = Vector3.zero;
    public float speed = 0.25f;
    public float sensitivity = 1;
    //public EnemyWaveManager other1;
    //public EnemyWaveManager other2;
    //public EnemyWaveManager other3;
    //public EnemyWaveManager other4;
    //public List<EnemyWaveManager> other = new List<EnemyWaveManager>();

    public int attack_recovery = 0;
    private int death_timer = 0;
    

    public GameObject projectile;
    //public GameObject spawnPoint = null;
    //public GameObject CanvasKeeper;

    public GameManager Game_Manager;
    //public GameObject model;

    private int input = 0;
    private bool slashTrigger;

    private GameObject newProjectile;

    //new

    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        //lastDirection = new Vector3()
        rbPlayer = GetComponent<Rigidbody>();
        //CanvasKeeper = GameObject.Find("Canvas");
        anim = GetComponentInChildren<Animator>();
        //model = GameObject.Find("BasicMotionsDummyModel");
    }

    void Update()
    {


        float horMov = Input.GetAxisRaw("Horizontal");
        float verMov = Input.GetAxisRaw("Vertical");
        anim.SetFloat("speed", 1);
        if (Mathf.Abs(horMov) >= 1) //sensitivity is a float between 1 and 0
        {
            horMov = Mathf.Sign(horMov);
        }
        if (Mathf.Abs(verMov) >= 1)
        {
            verMov = Mathf.Sign(verMov);
        }
        direction = new Vector3(horMov, 0, verMov).normalized;

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lastDirection = direction;
        }
        else
        {
            anim.SetFloat("speed", 0);
        }

        //

        if (Input.GetButton("Fire1"))
        {
            //newProjectile = Instantiate(projectile, transform.position, transform.rotation) as GameObject;
            slashTrigger = true;
        } else slashTrigger = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (death_timer > 0)
        {
            death_timer--;

            if (death_timer == 1)
            {
                //Respawn();
                Game_Manager.SceneTransition("EndScene");
            }
        }
        else
        {


            if (attack_recovery > 0)
            {
                attack_recovery--;
            }
            else
            {

                transform.Translate(direction * speed);
                //transform.rotation = Quaternion.LookRotation(direction);
                //anim.SetFloat("speed",Translation);
                //transform.GetChild(BasicMotionsDummyModel).GetComponent<TheComponent>().theVariable = theValue;

                if (transform.position.z > 11f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, 11f);
                }
                else if (transform.position.z < -11.89f)
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, -11.89f);
                }

                if (transform.position.x > 12f)
                {
                    transform.position = new Vector3(12f, transform.position.y, transform.position.z);
                }
                else if (transform.position.x < -12f)
                {
                    transform.position = new Vector3(-12f, transform.position.y, transform.position.z);
                }

                //

                if (slashTrigger == true)
                {
                    newProjectile = Instantiate(projectile, transform.position, transform.rotation); //as GameObject;
                    newProjectile.transform.Translate(lastDirection * 2f);
                    Destroy(newProjectile, .1f);
                    attack_recovery = 10;
                }
            }
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            if (death_timer == 0)
            {
                death_timer = 60;
            }
            //Respawn();
        }
    }


    /*
    private void Respawn()
    {
        death_timer = 0;
        GameObject[] all_enemies = GameObject.FindGameObjectsWithTag("Hazard");

        for (var i = 0; i < all_enemies.Length; i++)
        {
            Destroy(all_enemies[i]);
        }

        other1.spawnEnemies();
        //other2.spawnEnemies();
        //other3.spawnEnemies();
        //other4.spawnEnemies();

        transform.position = new Vector3(spawnPoint.transform.position.x, spawnPoint.transform.position.y, spawnPoint.transform.position.z);

        Score otherA = CanvasKeeper.GetComponent<Score>();
        otherA.clearScore();
    }
    */
}
