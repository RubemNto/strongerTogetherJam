using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class partyManager : MonoBehaviour
{
    public List<GameObject> instantiatedPartyMember = new List<GameObject>();

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < instantiatedPartyMember.Count; i++)
        {
            if(instantiatedPartyMember[i] == null)
            {
                instantiatedPartyMember.RemoveAt(i);
            }
        }        
    }
}
