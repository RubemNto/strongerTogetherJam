using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    private GameObject target;
    private float speed;
    private int damage;
    private char origin;
    
    private void Update()
    {
        transform.right = (target.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position+new Vector3(0,0.5f,0),speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(origin == 'A')
        {
            if(other.gameObject.tag == "enemy")
            {
                target.GetComponent<enemies>().TakeDamage(damage);
                Destroy(gameObject);
            }
        }
        else if(origin == 'E')
        {
            if(other.gameObject.tag == "ally")
            {
                target.GetComponent<ally>().TakeDamage(damage);
                Destroy(gameObject);
            }

            if(other.gameObject.tag == "Player")
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().playerHealth -= damage;
                Destroy(gameObject);
            }        
        }
    }

    public void SetSpeed(float Speed)
    {
        speed = Speed;
    }
    public void SetDamage(int Damage)
    {
        damage = Damage;
    }
    public void SetTarget(GameObject Target)
    {
        target = Target;
    }
    public void setOrigin(char Origin)
    {
        origin = Origin;
    }

    
}
