using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
	private Rigidbody rbPlayer;
	private Vector3 direction = Vector3.zero;
	public float speed = 10.0f;
	public GameObject spawnPoint = null;
    // Start is called before the first frame update
    void Start()
    {
    	rbPlayer = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horMov = Input.GetAxis("Horizontal");
        float verMov = Input.GetAxis("Vertical");

        direction = new Vector3(horMov,0,verMov);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
    	//transform.position = new Vector3(transform.position.x + direction, transform.position.y, transform.position.z + direction);
    	transform.Translate(direction * speed);
    	
        //rbPlayer.AddForce(direction * speed, ForceMode.Force);

        if (transform.position.z > 11f)
        {
        	transform.position = new Vector3(transform.position.x, transform.position.y, 11f);
        } else if  (transform.position.z < -11.89f)
        {
        	transform.position = new Vector3(transform.position.x, transform.position.y, -11.89f);
        }

        if (transform.position.x > 12f)
        {
        	transform.position = new Vector3(12f, transform.position.y, transform.position.z);
        } else if (transform.position.x < -12f)
        {
        	transform.position = new Vector3(-12f, transform.position.y, transform.position.z);
        }
        
        
    }

    private void Respawn()
    {
    	rbPlayer.MovePosition(spawnPoint.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
    	if (other.CompareTag("Hazard"))
    	{
    		Respawn();
    	}
    }


}
