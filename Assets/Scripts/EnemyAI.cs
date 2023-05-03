using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5f;
    public float followDistance = 10f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 2f;

    private float nextFireTime = 0f;

    void Update()
    {
        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the player is within the follow distance
        if (distanceToPlayer < followDistance)
        {
            // Rotate towards the player
            transform.LookAt(player.position);

            // Move towards the player
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        // Fire bullets at the player
        if (distanceToPlayer < followDistance && Time.time > nextFireTime)
        {
            nextFireTime = Time.time + 1 / fireRate;
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            //bullet.GetComponent<Rigidbody>().velocity = (player.position - transform.position).normalized * bulletSpeed;
            Vector3 shootDirection = new Vector3(player.position.x - transform.position.x, 0f, player.position.z - transform.position.z).normalized;
            bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
        }
    }
}