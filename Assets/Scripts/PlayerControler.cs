using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControler : MonoBehaviour
{

    [SerializeField] private float speed = 5.0f;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform bulletContainer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movment();
    }

    private void Movment()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            transform.Rotate(Vector3.up);
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            transform.Rotate(-Vector3.up);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Vector3.forward * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += Vector3.back * speed * Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(bullet, transform.position, transform.rotation, bulletContainer);
    }
}
