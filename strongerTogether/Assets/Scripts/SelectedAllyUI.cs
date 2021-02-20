using UnityEngine.UI;
using UnityEngine;

public class SelectedAllyUI : MonoBehaviour
{
    public mouse mouse;
    public Image image;
    // Start is called before the first frame update
    void Start()
    {
        mouse = GameObject.Find("GameManager").GetComponent<mouse>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mouse.selectedAlly != null)
        {
            image.sprite = mouse.selectedAlly.GetComponentInChildren<SpriteRenderer>().sprite;
            image.color = new Color(255,255,255,255);
        }
        else
        {
            image.sprite = null;
            image.color = new Color(0,0,0,0);
        }
    }
}
