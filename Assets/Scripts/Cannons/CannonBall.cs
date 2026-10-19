using UnityEngine;

public class CannonBall : MonoBehaviour
{
public float damage = 10;
    public float speed = 20f;
    public float life = 3f;

    //private bool hasHit = false;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        Destroy(gameObject, life);
    }

    public void SetDirection(Vector3 dir)
    {
        rb.linearVelocity = dir * speed;
    }
    private void OnTriggerEnter(Collider other)
    {
        PlayerControler player = other.GetComponent<PlayerControler>();

        if (player != null)
        {
            player.TakeDamage(damage);
            //Debug.Log("Enemy damaged the player!");
            Destroy(gameObject);
        }
    }


}

