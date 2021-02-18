using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mage : MonoBehaviour
{
    [Header("Attack Attributes")]
    private ally ally;
    public float timeBetweenAttack;
    public float attackSpeed;
    public float attackDamage;
    private float attackTime;
    public GameObject magePower;
    public Transform mageSpawnPos;
    
    // Start is called before the first frame update
    void Start()
    {
        attackTime = timeBetweenAttack;
        ally = GetComponent<ally>();                
    }

    // Update is called once per frame
    void Update()
    {
        if(ally.enemyTarget != null)
        {        
            if(attackTime <= 0)
            {
                Attack();
                attackTime = timeBetweenAttack;
            }
            else
            {
                attackTime-=Time.deltaTime;
            }
        }
        else
        {
            attackTime = 0;
        }
    }

    void Attack()
    {
        GameObject tempMage = Instantiate(magePower,mageSpawnPos.position,mageSpawnPos.rotation);
        tempMage.GetComponent<magic>().SetSpeed(attackSpeed);
        tempMage.GetComponent<magic>().SetDamage(attackDamage);
        tempMage.GetComponent<magic>().SetTarget(ally.enemyTarget);
    }
}
