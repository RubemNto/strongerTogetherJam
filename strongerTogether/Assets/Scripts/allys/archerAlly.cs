using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class archerAlly : MonoBehaviour
{
    private ally ally;
    private float timeOfShot;
    public float timeBetweenShots;
    public GameObject arrowPefab;
    public Transform arrowSpawnPosition;
    public float[] minMaxDamage = new float[2];
    public float[] minMaxSpeed = new float[2];
    // Start is called before the first frame update
    void Start()
    {
        ally = GetComponent<ally>();
        timeOfShot = timeBetweenShots;        
    }
    // Update is called once per frame
    void Update()
    {
        if(ally.enemyTarget != null)
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
        //Set Arrow damage
        tempArrow.GetComponent<arrow>().SetDamage(Random.Range(minMaxDamage[0],minMaxDamage[0]+1));
        //Set Arrow speed
        tempArrow.GetComponent<arrow>().SetSpeed(Random.Range(minMaxSpeed[0],minMaxSpeed[0]+1));
        //Set Arrow target
        tempArrow.GetComponent<arrow>().SetTarget(ally.enemyTarget);
    }
}
