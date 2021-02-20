using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tankEnemies : MonoBehaviour
{
    [Header("Attack Attributes")]
    public float damage;
    public float timeBetweenAttacks;
    private float attackTime;
    [Header("Move Attributes")]
    public float speed;
    private enemies tankData;
    // Start is called before the first frame update
    void Start()
    {
        attackTime = timeBetweenAttacks;
        tankData = GetComponent<enemies>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(tankData.target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,tankData.target.transform.position - new Vector3(0,1,0),speed*Time.fixedDeltaTime);
        }         
    }

    public void Attack()
    {
        tankData.target.GetComponent<ally>().TakeDamage(damage);
    }
}
