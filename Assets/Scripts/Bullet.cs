using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 50.0f;

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
        transform.position += Vector3.forward * speed * Time.deltaTime;
    }
}
