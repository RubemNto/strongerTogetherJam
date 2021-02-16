using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class partyMember : MonoBehaviour
{
    public enemiesManager eM;
    public GameObject targetEnemy = null;
    public partyManager pM;
    public float moveSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        pM = GameObject.Find("partyManager").GetComponent<partyManager>();
        eM = GameObject.Find("enemiesManager").GetComponent<enemiesManager>();        
        float[] distances = new float[eM.enemiesOnScreen.Count];
        for (int i = 0; i < eM.enemiesOnScreen.Count; i++)
        {
            distances[i] = Vector2.Distance(transform.position,eM.enemiesOnScreen[i].transform.position);                        
        }
        float[] tempDistances = new float[distances.Length];
        tempDistances = distances;
        Array.Sort(distances);
        for (int i = 0; i < eM.enemiesOnScreen.Count; i++)
        {
            if(distances[0] == tempDistances[i])
            {
                targetEnemy = eM.enemiesOnScreen[i];
                break;
            }
        }
    }
    void Update()
    {
        if(targetEnemy != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,targetEnemy.transform.position,moveSpeed*Time.deltaTime);
        }else if(targetEnemy == null && eM.enemiesOnScreen.Count != 0)
        {
            do
            {
                float[] distances = new float[eM.enemiesOnScreen.Count];
                for (int i = 0; i < eM.enemiesOnScreen.Count; i++)
                {
                    distances[i] = Vector2.Distance(transform.position,eM.enemiesOnScreen[i].transform.position);                        
                }
                float[] tempDistances = new float[distances.Length];
                tempDistances = distances;
                Array.Sort(distances);
                for (int i = 0; i < eM.enemiesOnScreen.Count; i++)
                {
                    if(distances[0] == tempDistances[i])
                    {
                        targetEnemy = eM.enemiesOnScreen[i];
                        break;
                    }
                }

                for (int i = 0; i < pM.instantiatedPartyMember.Count; i++)
                {
                    if(targetEnemy == pM.instantiatedPartyMember[i].GetComponent<partyMember>().targetEnemy)
                    {
                        targetEnemy = null;
                        break;
                    }
                }
            }while(targetEnemy == null);
        }
    }    
}
