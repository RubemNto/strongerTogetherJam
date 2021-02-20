using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrowEnemies : MonoBehaviour
{
    [Header("Attack Attributes")]
    public int damage;
    public float arrowSpeed;
    public float attackDistance;
    private float timeOfShot;
    public float timeBetweenShots;
    public GameObject arrowPefab;
    public AudioSource attackSound;
    public Transform arrowSpawnPosition;

    [Header("Move Attributes")]
    public float speed;
    private enemies archerData;

    // Start is called before the first frame update
    void Start()
    {
        archerData = GetComponent<enemies>();
        timeOfShot = timeBetweenShots;  
        attackSound = GameObject.Find("ArrowSound").GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(archerData.target != null)
        {
            Debug.Log(Vector2.Distance(transform.position,archerData.target.transform.position).ToString());
            if(Vector2.Distance(transform.position,archerData.target.transform.position) <= attackDistance)
            {                
                if(timeOfShot<=0)
                {
                    //Attack
                    Attack();
                    timeOfShot = timeBetweenShots;
                }else
                {
                    timeOfShot-=Time.deltaTime;
                }
            }
            else if(Vector2.Distance(transform.position,archerData.target.transform.position) > attackDistance)
            {
                //move forward
                transform.Translate(-transform.right*speed*Time.deltaTime);
            }             
        }
    }

    void Attack()
    {
        GameObject tempArrow = Instantiate(arrowPefab,arrowSpawnPosition.position,arrowSpawnPosition.rotation);
        //Set Arrow origin
        tempArrow.GetComponent<arrow>().setOrigin('E');
        //Set Arrow damage
        tempArrow.GetComponent<arrow>().SetDamage(damage);
        //Set Arrow speed
        tempArrow.GetComponent<arrow>().SetSpeed(arrowSpeed);
        //Set Arrow target
        tempArrow.GetComponent<arrow>().SetTarget(archerData.target);
        attackSound.Play();
    }
}
