using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ally : MonoBehaviour
{
    public float health;
    public float aliveTime;
    public GameObject enemyTarget = null;
    public enemiesManager enemiesManager;
    public partyManager partyManager;
    // Start is called before the first frame update
    void Start()
    {
        partyManager = GameObject.Find("partyManager").GetComponent<partyManager>();
        if(gameObject.transform.tag == "ally")
        {
            Destroy(gameObject,aliveTime);
        }
        // enemiesManager = GameObject.Find("enemiesManager").GetComponent<enemiesManager>();
    }
    

    // Update is called once per frame
    // void Update()
    // {
    //     // if(enemyTarget == null && enemiesManager.enemiesOnScreen.Count != 0)
    //     // {            
    //     //     List<GameObject> allyTargets = new List<GameObject>();
    //     //     List<GameObject> availableTargets = new List<GameObject>();
    //     //     foreach (GameObject aly in partyManager.instantiatedPartyMember)
    //     //     {
    //     //         allyTargets.Add(aly.GetComponent<ally>().enemyTarget);
    //     //     }

    //     //     for (int i = 0; i < enemiesManager.enemiesOnScreen.Count; i++)
    //     //     {
    //     //         bool found = false;
    //     //         for (int b = 0; b < allyTargets.Count; b++)
    //     //         {
    //     //             if(enemiesManager.enemiesOnScreen[i] == allyTargets[b])
    //     //             {
    //     //                 found = true;
    //     //                 break;
    //     //             }else
    //     //             {
    //     //                 found = false;
    //     //             }   
    //     //         }
    //     //         if(found == false)
    //     //         {
    //     //             availableTargets.Add(enemiesManager.enemiesOnScreen[i]);
    //     //         }                
    //     //     }
            
    //     //     float[] distances = new float[availableTargets.Count];

    //     //     for (int i = 0; i < distances.Length; i++)
    //     //     {
    //     //         distances[i] = Vector2.Distance(transform.position,availableTargets[i].transform.position);
    //     //     }

    //     //     float[] tempDistances = distances;
    //     //     Array.Sort(distances);
    //     //     for (int i = 0; i < distances.Length; i++)
    //     //     {
    //     //         if(distances[0] == tempDistances[i])
    //     //         {
    //     //             enemyTarget = availableTargets[i];
    //     //             break;
    //     //         }
    //     //     }
    //     // }else if(enemiesManager.enemiesOnScreen.Count == 0)
    //     // {
    //     //     enemyTarget = null;
    //     // }
        
    // }
    public void TakeDamage(float damageIntake)
    {
        health-=damageIntake;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    } 
}
