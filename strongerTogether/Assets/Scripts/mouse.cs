using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouse : MonoBehaviour
{
    public Vector3 worldPosition;
    public partyManager pM;
    public GameObject selectedAlly = null;
    public GameObject selectedEnemy = null;
    //public GameObject thing;

    // Start is called before the first frame update
    void Start()
    {
        pM = GameObject.Find("partyManager").GetComponent<partyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane;
        worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        Ray rayMouse = new Ray(worldPosition,Vector3.forward);
        RaycastHit hit;
//        Debug.DrawRay(worldPosition,Vector3.forward*100,Color.red);
        if(Physics.Raycast(rayMouse.origin,rayMouse.direction,out hit,100f))
        {
            if(GetComponent<GameManager>().selectedPartyMember != null)
            {
                if(Input.GetKeyDown(KeyCode.Mouse0) && GetComponent<GameManager>().mana >= GetComponent<GameManager>().chargedPrice)
                {
                    GetComponent<GameManager>().charge(GetComponent<GameManager>().chargedPrice);
                    GameObject instantiatedPartyMember = Instantiate(GetComponent<GameManager>().selectedPartyMember,hit.transform.position,hit.transform.rotation);
                    //Destroy(GetComponent<GameManager>().card);
                    GetComponent<GameManager>().selectedPartyMember = null;
                    GetComponent<GameManager>().card = null;
                    pM.instantiatedPartyMember.Add(instantiatedPartyMember);
                }
            }

            if(hit.transform.tag == "ally")
            {
//                Debug.Log("Found Ally");
                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    selectedAlly = hit.transform.gameObject;
                    selectedEnemy = null;
                }
            }

            if(hit.transform.tag == "enemy" && selectedAlly != null)
            {
//                Debug.Log("Found Enemy");

                if(Input.GetKeyDown(KeyCode.Mouse1))
                {
                    selectedEnemy = hit.transform.gameObject;
                }
            }
        }

        if(selectedAlly != null && selectedEnemy != null)
        {
            selectedAlly.GetComponent<ally>().enemyTarget = selectedEnemy;
        }        
    }
}
