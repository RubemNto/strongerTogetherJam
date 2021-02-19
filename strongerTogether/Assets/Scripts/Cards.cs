using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cards : MonoBehaviour
{

    public GameObject partyMember;
    public GameManager gM;
    public int price;
    // Start is called before the first frame update
    void Start()
    {
        gM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SelectedCard()
    {
        gM.selectedPartyMember = partyMember;
        gM.card = this.gameObject;
        gM.chargedPrice = price;
    }

    public void checkMana()
    {
        if(gM.mana >= price)
        {
            gM.charge(price);
        }
    } 
    
}
