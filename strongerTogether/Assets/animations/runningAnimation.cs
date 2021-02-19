using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runningAnimation : MonoBehaviour
{
    private float controller = 0;
    public float jumpSpeed;
    public bool goUp = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller >=1)
        {
            goUp = false;
        }
        else if(controller <= 0)
        {
            goUp = true;
        }

        if(goUp)
        {
            controller+=jumpSpeed*Time.deltaTime;
        }else
        {
            controller-=jumpSpeed*Time.deltaTime;
        }        
    }
}
