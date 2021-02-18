using UnityEngine;

public class tankAlly : MonoBehaviour
{
    private ally ally;
    [Header("Movement Attributes")]
    public float moveSpeed;
    [Header("Attack Attributes")]
    public float damage;
    public float attackDistance = 5f;
    public float timeBetweenAttack;
    private float timeToAttack;
    // Start is called before the first frame update
    void Start()
    {
        ally = GetComponent<ally>();
        timeToAttack = timeBetweenAttack;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position,ally.enemyTarget.transform.position);

        if(distanceToTarget > attackDistance)
        {
            if(ally.enemyTarget != null)
            {
                transform.position = Vector2.MoveTowards(transform.position,ally.enemyTarget.transform.position,moveSpeed*Time.deltaTime);
            }
        }
        else
        {
            //attack
            Attack();
        }
    }

    void Attack()
    {
        if(timeToAttack <= 0)
        {
            ally.enemyTarget.GetComponent<enemies>().TakeDamage(damage);
            timeToAttack = timeBetweenAttack;
        }
        else 
        {
            timeToAttack-=Time.deltaTime;
        }
    }
}
