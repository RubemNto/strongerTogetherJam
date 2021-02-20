using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mageEnemy : MonoBehaviour
{
    private enemies enemies;
    public float attackDistance;
    public float speed;
    public float timeBetweenAttack;
    public float attackSpeed;
    public int attackDamage;
    private float attackTime;
    public GameObject magePower;
    public Transform mageSpawnPos;
    public AudioSource attackSound;
    // Start is called before the first frame update
    void Start()
    {
        attackSound = GameObject.Find("MagicSound").GetComponent<AudioSource>();
        attackTime = timeBetweenAttack;
        enemies = GetComponent<enemies>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemies.target != null)
        {
//            Debug.Log(Vector2.Distance(transform.position,enemies.target.transform.position).ToString());
            if(Vector2.Distance(transform.position,enemies.target.transform.position) <= attackDistance)
            {                
                if(attackTime<=0)
                {
                    //Attack
                    Attack();
                    attackTime = timeBetweenAttack;
                }else
                {
                    attackTime-=Time.deltaTime;
                }
            }
            else if(Vector2.Distance(transform.position,enemies.target.transform.position) > attackDistance)
            {
                //move forward
                transform.Translate(-transform.right*speed*Time.deltaTime);
            }             
        }
    }

    void Attack()
    {
        GameObject tempMage = Instantiate(magePower,mageSpawnPos.position,mageSpawnPos.rotation);
        // if(gameObject.transform.name != "enemyMage 1(Clone)")
        // {
            tempMage.GetComponent<magic>().SetSpeed(attackSpeed);
            tempMage.GetComponent<magic>().SetDamage(attackDamage);
            tempMage.GetComponent<magic>().SetTarget(enemies.target);
            tempMage.GetComponent<magic>().setOrigin('E');
        
        // }else if(gameObject.transform.name == "enemyMage 1(Clone)")
        // {
        //     tempMage.GetComponent<ice>().SetSpeed(attackSpeed);
        //     tempMage.GetComponent<ice>().SetDamage(attackDamage);
        //     tempMage.GetComponent<ice>().SetTarget(enemies.target);
        // }
        attackSound.Play();
    }
}
