using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAIBehavior : MonoBehaviour
{
    public Transform player; // Reference to the player's Transform
    public GameObject bulletPrefab; // Reference to the bullet prefab
    public float bulletSpeed = 1f; // The speed at which the bullet moves
    public float shootInterval = 2f; // The interval between each bullet shot
    private float timeSinceLastShot = 0f; // The time elapsed since the last bullet shot

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeSinceLastShot += Time.deltaTime;
        if (timeSinceLastShot >= shootInterval)
        {
            ShootBullet();
            timeSinceLastShot = 0f;
        }
    }
    public void ShootBullet()
    {
        // Create a new bullet instance
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);

        // Set the bullet's velocity towards the player
        Vector3 shootDirection = new Vector3(player.position.x - transform.position.x, 0f, player.position.z - transform.position.z).normalized;
        bullet.GetComponent<Rigidbody>().velocity = shootDirection * bulletSpeed;
    }
}
