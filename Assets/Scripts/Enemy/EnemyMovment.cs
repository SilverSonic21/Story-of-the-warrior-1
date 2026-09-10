using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
public float moveSpeed = 3f;
    public float stoppingDistance = 2f;
    public float rotationSpeed = 10f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        // Rotate toward player
        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Move toward player if far enough
        if (distance > stoppingDistance)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
        else
        {
            // In attack range
            // You can trigger attack animation here
            // animator.SetTrigger("Attack");
        }
    }
}
