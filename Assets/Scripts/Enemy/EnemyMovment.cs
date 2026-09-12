using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
public float moveSpeed = 3f;
    public float stoppingDistance = 2f;
    public float rotationSpeed = 10f;
    private Rigidbody rb;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        Vector3 direction = (player.position - transform.position);
        direction.y = 0; 
        direction.Normalize();

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        if (distance > stoppingDistance)
        {
            Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
            transform.position += forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            // In attack range
            // You can trigger attack animation here
            // animator.SetTrigger("Attack");
        }
        
    }
   

}
