using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody rbPlayer;
	private Vector3 direction = Vector3.zero;
    private Vector3 lastDirection = Vector3.zero;
	public float speed = 10.0f;
    public float sensitivity = 1;
    public EnemyWaveManager other1;
    //public EnemyWaveManager other2;
    //public EnemyWaveManager other3;
    //public EnemyWaveManager other4;
    //public List<EnemyWaveManager> other = new List<EnemyWaveManager>();

    public int attack_recovery = 0;
    

    public GameObject projectile;
    public GameObject spawnPoint = null;
    public GameObject CanvasKeeper;

    private int input = 0;
    private bool slashTrigger;

    private GameObject newProjectile;
    // Start is called before the first frame update
    void Start()
    {
        //lastDirection = new Vector3()
        rbPlayer = GetComponent<Rigidbody>();
        CanvasKeeper = GameObject.Find("Canvas");
    }

    void Update()
    {
        /*
        float horMov = Input.GetAxisRaw("Horizontal");
        float verMov = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horMov, 0, verMov);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            lastDirection = direction;
        }

        //direction = new Vector3(horMov,0,verMov);
        */

        float horMov = Input.GetAxisRaw("Horizontal");
        float verMov = Input.GetAxisRaw("Vertical");
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
        if (attack_recovery > 0)
        {
            attack_recovery--;
        }
        else
        {

            transform.Translate(direction * speed);

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

    /*
    private void OnTriggerExit(Collider other)
    {
    	if (other.CompareTag("Hazard"))
    	{
    		Respawn();
    	}
    }

    void onCollisionEnter(Collision col)
    {
        // When target is hit
        if (col.gameObject.tag == "Hazard")
        {
            Respawn();
        }
    }
    */
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hazard"))
        {
            Respawn();
        }
    }
    


    private void Respawn()
    {
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
}
