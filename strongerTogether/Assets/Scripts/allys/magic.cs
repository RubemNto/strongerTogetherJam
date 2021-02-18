using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour
{
    private float speed;
    private float damage;
    private GameObject target;
    
    // Update is called once per frame
    void Update()
    {
        //pegar o ponto entre magia e inimigo
        //apontar a magia ao inimigo
            //rotacionar em direção ao inimigo
        //mover a magia até o inimigo 
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
