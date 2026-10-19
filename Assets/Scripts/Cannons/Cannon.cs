using UnityEngine;

public class Cannon : MonoBehaviour
{
    public Transform player;            
    public GameObject cannonBallPrefab; 
    public Transform firePoint;            
     public float fireRate = 1.5f;      
    public float rotationSpeed = 5f;    

    private float nextFireTime;

    void Update()
    {
        if (player == null) return;

        
        Vector3 direction = player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        
        if (Time.time >= nextFireTime)
        {
            Fire(direction.normalized);
            nextFireTime = Time.time + fireRate;
        }
    }

    void Fire(Vector3 dir)
    {
        GameObject ball = Instantiate(cannonBallPrefab, firePoint.position, Quaternion.identity);

        CannonBall cannonBall = ball.GetComponent<CannonBall>();
        if (cannonBall != null)
        {
            cannonBall.SetDirection(dir);
        }
    }
}
