using UnityEngine;

public class CamaraControl : MonoBehaviour
{
    [SerializeField] private PlayerControler player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z );

    }
}
