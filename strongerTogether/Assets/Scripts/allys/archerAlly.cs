using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archerAlly : MonoBehaviour
{
    private ally ally;
    private float timeOfShot;
    public float timeBetweenShots;
    public GameObject arrowPefab;
    public AudioSource attackSound;

    public Transform arrowSpawnPosition;
    public int Damage;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        ally = GetComponent<ally>();
        timeOfShot = timeBetweenShots;  
        attackSound = GameObject.Find("ArrowSound").GetComponent<AudioSource>();      
    }
    // Update is called once per frame
    void Update()
    {
        if(ally.enemyTarget != null && ally.canAttack == true)
        {
            //shoot arrow
            if(timeOfShot <= 0)
            {
                shootArrow();
                timeOfShot=timeBetweenShots;
            }else
            {
                timeOfShot-=Time.deltaTime;
            }
        }
        else
        {
            timeOfShot = 0;
        }        
    }
    public void shootArrow()
    {
        GameObject tempArrow = Instantiate(arrowPefab,arrowSpawnPosition.position,arrowSpawnPosition.rotation);
        //Set Arrow origin
        tempArrow.GetComponent<arrow>().setOrigin('A');
        //Set Arrow damage
        tempArrow.GetComponent<arrow>().SetDamage(Damage);
        //Set Arrow speed
        tempArrow.GetComponent<arrow>().SetSpeed(speed);
        tempArrow.GetComponent<arrow>().setOrigin('A');

        //Set Arrow target
        tempArrow.GetComponent<arrow>().SetTarget(ally.enemyTarget);
        attackSound.Play();
    }
}
