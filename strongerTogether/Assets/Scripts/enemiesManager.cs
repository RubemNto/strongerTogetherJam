using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemiesManager : MonoBehaviour
{
    public List<GameObject> enemiesPrefabs = new List<GameObject>();
    public List<Transform> enemiesSpawnPos = new List<Transform>();
    public List<GameObject> enemiesOnScreen = new List<GameObject>();
    public int maxEnemiesOnScreen;
    public float timeToSpawn;
    float spawnTime;
    int EnemiesOnScreen; 

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemiesOnScreen < maxEnemiesOnScreen)
        {
            if(spawnTime <= 0)
            {
                //instantiate random enemy at random location
                int randomPos = Random.Range(0,enemiesSpawnPos.Count);
                int randomPrefab = Random.Range(0,enemiesPrefabs.Count);

                enemiesOnScreen.Add(Instantiate(enemiesPrefabs[randomPrefab],enemiesSpawnPos[randomPos].position,enemiesSpawnPos[randomPos].rotation));
                EnemiesOnScreen++;
                spawnTime = timeToSpawn;
            }else
            {
                spawnTime-=Time.deltaTime;
            }        
        }
    }
}
