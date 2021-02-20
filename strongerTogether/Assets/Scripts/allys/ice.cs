using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ice : MonoBehaviour
{
    private float speed;
    private int damage;
    private GameObject target;

    // Update is called once per frame
    void Update()
    {
        transform.right = (target.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ally" && other.gameObject.tag == "Player")
        {
            target.GetComponent<ally>().IceHit();
            Destroy(gameObject);
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
}
