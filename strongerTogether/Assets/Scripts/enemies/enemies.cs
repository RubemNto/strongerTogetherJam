using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class enemies : MonoBehaviour
{
    public GameObject target;
    public float health;
    private enemiesManager enemiesManager;
    public partyManager partyManager;
    // Start is called before the first frame update
    void Start()
    {
        partyManager = GameObject.Find("partyManager").GetComponent<partyManager>();
        enemiesManager = GameObject.Find("enemiesManager").GetComponent<enemiesManager>();
    }

    // Update is called once per frame
    void Update()
    {        
        if(partyManager.instantiatedPartyMember.Count != 0)
        {            
            List<GameObject> enemyTargets = new List<GameObject>();
            List<GameObject> availableTargets = new List<GameObject>();
            foreach (GameObject enemy in enemiesManager.enemiesOnScreen)
            {
                enemyTargets.Add(enemy.GetComponent<enemies>().target);
            }

            for (int i = 0; i < partyManager.instantiatedPartyMember.Count; i++)
            {
                bool found = false;
                for (int b = 0; b < enemyTargets.Count; b++)
                {
                    if(partyManager.instantiatedPartyMember[i] == enemyTargets[b])
                    {
                        found = true;
                        break;
                    }else
                    {
                        found = false;
                    }   
                }
                if(found == false)
                {
                    availableTargets.Add(partyManager.instantiatedPartyMember[i]);
                }                
            }
            
            float[] distances = new float[availableTargets.Count];

            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = Vector2.Distance(transform.position,availableTargets[i].transform.position);
            }

            float[] tempDistances = distances;
            Array.Sort(distances);
            for (int i = 0; i < distances.Length; i++)
            {
                if(distances[0] == tempDistances[i])
                {
                    target = availableTargets[i];
                    break;
                }
            }
        }
        else if(partyManager.instantiatedPartyMember.Count == 0)
        {
            target = GameObject.Find("PlayerMesh");
        } 
    }

    

    public void TakeDamage(int damageIntake)
    {
        health -= damageIntake;
        if(health <= 0)
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().mana += 10;
            Destroy(gameObject);
        }
    }
}
