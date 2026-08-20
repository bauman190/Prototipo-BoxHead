using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 0.1f;
    [SerializeField] private Transform target;

    private WaveManager waveManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLISIONÉ CON: " + collision.gameObject.name);
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            Debug.Log("¡ES UNA BULLET!");
            Die();
        }
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void SetTarget(Transform target)
    {
        this.target = target;
    }

    public void SetWaveManager(WaveManager waveaManager)
    { 
        this.waveManager = waveaManager;
    }

    void Die()
    {
        waveManager.DecreaseEnemysInScreen();
        Destroy(gameObject);
    }

}
