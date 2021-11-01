using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelAdditionalControls : MonoBehaviour
{
    private Vector3 rotDir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {

        //transform.parent.GetComponent(Slash).health -= 3;
        rotDir = gameObject.transform.parent.gameObject.GetComponent<Player>().lastDirection;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, rotDir, 10, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }
}
