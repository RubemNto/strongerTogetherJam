using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class mouse : MonoBehaviour
{

    public Vector3 worldPosition;
    public partyManager pM;
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
        Debug.DrawRay(worldPosition,Vector3.forward*100,Color.red);
        if(Physics.Raycast(rayMouse.origin,rayMouse.direction,out hit,100f))
        {
            if(hit.transform.parent.tag == "spawnPosition" && GetComponent<GameManager>().selectedPartyMember != null)
            {
                if(Input.GetKeyDown(KeyCode.Mouse0))
                {
                    GameObject instantiatedPartyMember = Instantiate(GetComponent<GameManager>().selectedPartyMember,hit.transform.position + new Vector3(0,1,0),hit.transform.rotation);
                    Destroy(GetComponent<GameManager>().card);
                    GetComponent<GameManager>().selectedPartyMember = null;
                    GetComponent<GameManager>().card = null;
                    pM.instantiatedPartyMember.Add(instantiatedPartyMember);
                }
            }
        }
        //thing.transform.position = worldPosition;
    }
}
