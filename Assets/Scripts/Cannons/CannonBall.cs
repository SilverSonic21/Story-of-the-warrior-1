using UnityEngine;

public class CannonBall : MonoBehaviour
{
       public float damage = 5;
    public float speed = 5f;
    public float life = 1f;
    public GameObject particles;
    public GameObject particles2;
    private bool hasHit = false;
    private Rigidbody2D rb;
    public float rotationSpeed = 500f;
    public AudioSource audioSource;
    public AudioClip breakSound;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }   
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, life);
    }
    
    private void Update()
    {
       // transform.position += Vector3.right * direction * speed * Time.deltaTime;
        
    }

    public void SetDirection(Vector2 dir)
    {
    
        rb.linearVelocity = dir * speed;    
    }

    void OnTriggerEnter(Collider collision)
    {
        if (hasHit) return;
        if (collision.gameObject.CompareTag("Player"))
        {
            

            PlayerControler playerControler = collision.gameObject.GetComponent<PlayerControler>();
            if (playerControler != null)
            {
                hasHit = true;
                playerControler.TakeDamage(damage);
                Destroy(gameObject);
            }

        
            //GameObject p1 = Instantiate(particles, transform.position, Quaternion.identity);
            //GameObject p2 = Instantiate(particles2, transform.position, Quaternion.identity);

            //p1.GetComponent<ParticleSystem>().Play();
            //p2.GetComponent<ParticleSystem>().Play();
        
            
        } 
        //Debug.Log("Hit");
        
    }
}
