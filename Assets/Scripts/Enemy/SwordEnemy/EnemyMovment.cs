using UnityEngine;

public class EnemyMovment : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float stoppingDistance = 2f;
    public float rotationSpeed = 10f;
    private Rigidbody rb;

    private Transform player;

    public float detectionRange = 12f;     
    public float loseSightRange = 18f;     
    private bool playerSpotted = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        
        if (!playerSpotted && distance <= detectionRange)
        {
            playerSpotted = true;
            //Debug.Log("Enemy spotted the player!");
        }

        
        if (playerSpotted && distance > loseSightRange)
        {
            playerSpotted = false;
            //Debug.Log("Enemy lost sight of the player.");
        }

        
        if (playerSpotted)
        {
            Vector3 direction = (player.position - transform.position);
            direction.y = 0;
            direction.Normalize();

            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);
        }
    }

    void FixedUpdate()
    {
        if (player == null || !playerSpotted) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stoppingDistance)
        {
            Vector3 forward = new Vector3(transform.forward.x, 0, transform.forward.z).normalized;
            Vector3 targetPosition = transform.position + forward * moveSpeed * Time.fixedDeltaTime;

            rb.MovePosition(targetPosition);
        }
        else
        {
            rb.MovePosition(transform.position);
        }
    }
}
