using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;


public class openMainMenu : MonoBehaviour
{
    public float radiusLight;
    public float speed;
    public Light2D LightSource;
    public GameObject button;
    // Start is called before the first frame update
    void Start()
    {
        radiusLight = 0; 
        button.SetActive(false);       
    }

    // Update is called once per frame
    void Update()
    {
        LightSource.pointLightOuterRadius = radiusLight;
        if(radiusLight < 15f)
        {
            radiusLight+=Time.deltaTime*speed;
        }else if(radiusLight >=15)
        {
            button.SetActive(true);
        }              
    }

    public void changeSceen()
    {
        SceneManager.LoadScene(1);
    }
}
