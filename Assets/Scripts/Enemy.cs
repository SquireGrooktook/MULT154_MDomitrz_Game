using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject aura;
    public GameObject playerTarget;
    public GameObject CanvasKeeper;
    private GameObject auraControl;

    private NavMeshAgent agent;

    //public Score otherA;
    // Start is called before the first frame update
    void Start()
    {
        auraControl = Instantiate(aura, transform.position, transform.rotation); //as GameObject;
        GameObject child = auraControl;
        child.transform.SetParent(gameObject.transform);

        playerTarget = GameObject.Find("Player");
        CanvasKeeper = GameObject.Find("Canvas");


        agent = GetComponent<NavMeshAgent>();

        agent.speed = Random.Range(3.5f, 15f);
        agent.angularSpeed = Random.Range(100f, 1000f);
        agent.acceleration = Random.Range(8, 30);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, playerTarget.transform.position.z), move_speed);
        agent.SetDestination(playerTarget.transform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player Attack"))
        {
            //GameObject go = GameObject.Find("Canvas");
            //Score otherA = (Score) go.GetComponent(typeof(Score));
            //otherA.addScore(100);

            Score otherA = CanvasKeeper.GetComponent<Score>();
            otherA.addScore(100);
            Destroy(gameObject);
        }
    }
}
