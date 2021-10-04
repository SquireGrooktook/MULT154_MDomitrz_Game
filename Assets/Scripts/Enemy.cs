using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject aura;
    public GameObject playerTarget;
    public GameObject CanvasKeeper;
    private GameObject auraControl;
    private float move_speed = .08f;



    //public Score otherA;
    // Start is called before the first frame update
    void Start()
    {
        auraControl = Instantiate(aura, transform.position, transform.rotation); //as GameObject;
        GameObject child = auraControl;
        child.transform.SetParent(gameObject.transform);

        playerTarget = GameObject.Find("Player");
        CanvasKeeper = GameObject.Find("Canvas");

        move_speed = Random.Range(.05f, .25f);


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        //auraControl.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTarget.transform.position.x, playerTarget.transform.position.y, playerTarget.transform.position.z), move_speed);

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
