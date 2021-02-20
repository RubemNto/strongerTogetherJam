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
    public bool canAttack = true;
    public float fireDamageIntake;
    public bool burn;
    public float stunTime;
    private float stunTimeCounter;
    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        partyManager = GameObject.Find("partyManager").GetComponent<partyManager>();
        if(gameObject.transform.tag == "ally")
        {
            Destroy(gameObject,aliveTime);
        }
        stunTimeCounter = stunTime;
        // enemiesManager = GameObject.Find("enemiesManager").GetComponent<enemiesManager>();
    }
    void Update() 
    {
        if(canAttack == false)
        {
            if(stunTimeCounter >= 0)
            {
                stunTimeCounter-=Time.deltaTime;
            }
            else
            {
                stunTimeCounter = stunTime;
                canAttack = true;
            }
        }

        if(burn == true)
        {
            if(stunTimeCounter >= 0)
            {
                FireHit(fireDamageIntake);
                stunTimeCounter-=Time.deltaTime;
            }
            else
            {
                stunTimeCounter = stunTime;
                burn = false;
            }            
        }
        
    }
    public void TakeDamage(float damageIntake)
    {
        health-=damageIntake;
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }

    public void IceHit()
    {
        canAttack = false;
    }

    public void FireHit(float Damage)
    {        
        health -= Damage;
    }  
}
