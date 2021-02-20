using UnityEngine;

public class magic : MonoBehaviour
{
    private float speed;
    private int damage;
    private GameObject target;
    private char origin;
    
    // Update is called once per frame
    void Update()
    {
        //pegar o ponto entre magia e inimigo
        //apontar a magia ao inimigo
            //rotacionar em direção ao inimigo
        //mover a magia até o inimigo
        if(target == null)
        {
            Destroy(gameObject);
        } 
        transform.right = (target.transform.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position,target.transform.position,speed*Time.deltaTime);
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
