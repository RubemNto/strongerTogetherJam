using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankEnemies : MonoBehaviour
{
    [Header("Attack Attributes")]
    public float damage;
    public float timeBetweenAttacks;
    private float attackTime;
    private enemies tankData;
    // Start is called before the first frame update
    void Start()
    {
        attackTime = timeBetweenAttacks;
        tankData = GetComponent<enemies>();
    }

    // Update is called once per frame
    void Update()
    {
        if(tankData.moveSpeed <= 0 && tankData.player != null)
        {
            if(attackTime<=0)
            {
                Attack();
                attackTime = timeBetweenAttacks;
            }
            else
            {
                attackTime-=Time.deltaTime;
            }   
        }     
    }

    public void Attack()
    {
        tankData.player.GetComponent<ally>().TakeDamage(damage);
    }
}
