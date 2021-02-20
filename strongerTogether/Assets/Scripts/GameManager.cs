using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject selectedPartyMember;
    public GameObject card;
    public float GameTime;
    public int playerHealth;
    public int mana;
    // public GameObject middle;
    public int chargedPrice;
    public TextMeshProUGUI health;
    public TextMeshProUGUI magic;
    // public GameObject[] ground;
    // public int middleIndex = 0;

    void Update() 
    {
        health.text = "Health: " + playerHealth.ToString();
        magic.text =  "Magic: " + mana.ToString(); 
        if(GameTime>0)
        {
            GameTime-=Time.deltaTime;       
        }else if(GameTime<=0)
        {
            GameTime = 0;
        }
    } 

    // void Update() {
    //     foreach (GameObject Ground in ground)
    //     {
    //         if(Ground.transform.name == "ground ("+middleIndex.ToString()+")")
    //         {
    //             middle = Ground;
    //             break;
    //         }        
    //     }
    // }
    public void charge(int value)
    {        
        mana -= value;
    }

    // public void ChangeMiddleIndex()
    // {
    //     if(middleIndex == 2)
    //     {
    //         middleIndex = 1;
    //     }else if(middleIndex == 1)
    //     {
    //         middleIndex = 3;
    //     }else if(middleIndex == 3)
    //     {
    //         middleIndex = 2;
    //     }

    //     foreach (GameObject Ground in ground)
    //     {
    //         if(Ground.transform.name == "ground ("+middleIndex.ToString()+")")
    //         {
    //             middle = Ground;
    //             break;
    //         }        
    //     }
    // }
}
