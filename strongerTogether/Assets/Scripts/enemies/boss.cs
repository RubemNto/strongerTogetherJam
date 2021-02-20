using UnityEngine;

public class boss : MonoBehaviour
{
    public float HitDamage;
    public float jumpSpeed;
    public float Health;
    public GameObject[] projectiles;
    private float attackTime;
    public float TimeBetweenAttack;
    private partyManager partyManager;
    private bool goUp = false;
    void Start() 
    {
        attackTime = TimeBetweenAttack;
        
    }
    // Update is called once per frame
    void Update()
    {
        attackTime-=Time.deltaTime;
        if(attackTime <= 0)
        {
            int randomAttack = Random.Range(0,5);
            switch (randomAttack)
            {
                case 0:
                if(goUp)
                {
                    transform.position = Vector2.MoveTowards(transform.position,new Vector3(4.2f,5f,0),jumpSpeed*Time.deltaTime);
                    if(transform.position == new Vector3(4.2f,5f,0))
                    {
                        goUp = false;
                    }
                }
                else
                {
                    transform.position = Vector2.MoveTowards(transform.position,new Vector3(4.2f,1f,0),jumpSpeed*Time.deltaTime);
                }
                MelleeAttack();
                    break;
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
            attackTime = TimeBetweenAttack;
        }
    }

    void MelleeAttack()
    {
        foreach (GameObject partyMembers in partyManager.instantiatedPartyMember)
        {
            partyManager.GetComponent<ally>().TakeDamage(HitDamage);
        }
    }
}
