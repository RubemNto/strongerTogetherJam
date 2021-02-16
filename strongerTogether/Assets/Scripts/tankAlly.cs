using UnityEngine;

public class tankAlly : MonoBehaviour
{
    private ally ally;
    [Header("Movement Attributes")]
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        ally = GetComponent<ally>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ally.enemyTarget != null)
        {
            transform.position = Vector2.MoveTowards(transform.position,ally.enemyTarget.transform.position,moveSpeed*Time.deltaTime);
        }
    }
}
