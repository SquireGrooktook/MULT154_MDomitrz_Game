using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveManager : MonoBehaviour
{
    public List<GameObject> EnemySpawns = new List<GameObject>();
    public GameObject SpawnPoint1;
    public GameObject SpawnPoint2;
    public GameObject SpawnPoint3;
    public GameObject SpawnPoint4;
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
        Instantiate(EnemyType, SpawnPoint1.transform.position, SpawnPoint1.transform.rotation);
        Instantiate(EnemyType, SpawnPoint2.transform.position, SpawnPoint2.transform.rotation);
        Instantiate(EnemyType, SpawnPoint3.transform.position, SpawnPoint3.transform.rotation);
        Instantiate(EnemyType, SpawnPoint4.transform.position, SpawnPoint4.transform.rotation);
    }

}
