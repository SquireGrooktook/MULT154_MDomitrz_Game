using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public List<GameObject> EnemySpawns = new List<GameObject>();
    //private GameObject[] EnemySpawns = null;
    public GameObject EnemyType;
    bool enemyCheck = false;
    // Start is called before the first frame update
    void Start()
    {
        spawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (GameObject.FindGameObjectWithTag("Hazard") == null)
        {
            spawnEnemies();
        }
    }

    public void spawnEnemies()
    {
        int move_amount = 10;
        //GameObject[] EnemySpawns = new GameObject[4];
        EnemySpawns.Add(Instantiate(EnemyType, new Vector3(transform.position.x + move_amount, transform.position.y, transform.position.z + move_amount), transform.rotation) as GameObject);
        EnemySpawns.Add(Instantiate(EnemyType, new Vector3(transform.position.x + move_amount, transform.position.y, transform.position.z - move_amount), transform.rotation) as GameObject);
        EnemySpawns.Add(Instantiate(EnemyType, new Vector3(transform.position.x - move_amount, transform.position.y, transform.position.z + move_amount), transform.rotation) as GameObject);
        EnemySpawns.Add(Instantiate(EnemyType, new Vector3(transform.position.x - move_amount, transform.position.y, transform.position.z - move_amount), transform.rotation) as GameObject);
    }
    /*
    private void FixedUpdate()
    {
        enemyCheck = false;
        foreach (GameObject Enemy in EnemySpawns)
        {
            if (Enemy == null)
            {
                enemyCheck = true;
            }

        }
        if (enemyCheck == true)
        {
            EnemySpawns[0] = Instantiate(EnemyType);
            EnemySpawns[1] = Instantiate(EnemyType);
            EnemySpawns[2] = Instantiate(EnemyType);
            EnemySpawns[3] = Instantiate(EnemyType);
        }
    }
    */
}
