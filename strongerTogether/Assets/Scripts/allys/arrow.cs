using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private GameObject target;
    private float speed;
    private float damage;
    
    private void Update()
    {
        transform.right = (target.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            target.GetComponent<enemies>().TakeDamage(damage);
            Destroy(gameObject);
        }        
    }

    public void SetSpeed(float Speed)
    {
        speed = Speed;
    }
    public void SetDamage(float Damage)
    {
        damage = Damage;
    }
    public void SetTarget(GameObject Target)
    {
        target = Target;
    }

    
}
