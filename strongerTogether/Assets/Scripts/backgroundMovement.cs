using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundMovement : MonoBehaviour
{
    public float moveSpeed = 0;
    public Vector3 endPosition = Vector3.zero;
    public Vector3 startPosition = Vector3.zero;
    public bool move = false;
    // private GameManager GM;
    // public Transform Left;
    // public Transform Right;
    void Start() 
    {
        // GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(move)
        {
            if(transform.position.x > endPosition.x)
            {
                transform.Translate(-moveSpeed*Time.deltaTime,0,0);
            }else if(transform.position.x <= endPosition.x)
            {
                transform.position = startPosition;
                if(transform.tag == "background")
                {
                    GetComponentInChildren<SpriteRenderer>().flipX = !GetComponentInChildren<SpriteRenderer>().flipX;
                }                
                // transform.position = GM.middle.GetComponent<backgroundMovement>().transform.position + new Vector3(GM.middle.GetComponent<backgroundMovement>().transform.position.x,0,0);
                // Left.SetParent(null);
                // transform.SetParent(Left);
                // GM.middle.GetComponent<backgroundMovement>().Right.SetParent(null);
                // GM.middle.GetComponent<backgroundMovement>().transform.SetParent(GM.middle.GetComponent<backgroundMovement>().Right);
                // Left.position = GM.middle.GetComponent<backgroundMovement>().Right.position;
                // transform.SetParent(null);
                // Left.SetParent(transform);
                // GM.middle.GetComponent<backgroundMovement>().transform.SetParent(null);
                // GM.middle.GetComponent<backgroundMovement>().Right.SetParent(GM.middle.GetComponent<backgroundMovement>().transform);
                
            }
        }
    }
}
