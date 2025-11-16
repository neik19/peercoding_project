using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNeil : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    private TatiGameManager gameManager;
    private GameObject player;
    private float shootTimer = 0f;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<TatiGameManager>();
        player = GameObject.FindGameObjectWithTag("Player");
        // Start shooting immediately and then every 3 seconds
        shootTimer = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0.5f, 0, 0) * Time.deltaTime * 1f);
        
        if (transform.position.y < -6.5f || transform.position.y > 6.5f ||
        transform.position.x < -10f || transform.position.x > 10f)
        {
            Destroy(this.gameObject);
        }
        // Handle shooting timer
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0f)
        {
            ShootAtPlayer();
            shootTimer = 3f; // Reset timer for next shot
        }
    }

    void ShootAtPlayer()
    {
        if (bulletPrefab != null && player != null)
        {
            // Create bullet at enemy position
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            
            // Calculate direction towards player
            Vector3 direction = (player.transform.position - transform.position).normalized;
            
            // Apply velocity to bullet
            Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
            if (bulletRb != null)
            {
                bulletRb.linearVelocity = direction * 5f;
            }
            
            // Optional: Rotate bullet to face direction
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            bullet.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Player")
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } 
        else if(whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            gameManager.AddScore(10);
        }
    }
}