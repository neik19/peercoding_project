using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class TotsPlayer : MonoBehaviour
{
    //movement
    //shooting
    //scope access modifier private or public
    private TatiGameManager gameManager;
    public int lives;
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 4f; // idk this is confuzzling me

    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public GameObject shieldPowerupPrefab;

    void Start()
    {
        playerSpeed = 8f;
        lives = 3;
        // Set initial spawn position lower on the screen
        transform.position = new Vector3(0, -3f, 0); // Spawn at bottom half
    }

    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();
        
    }
    public void LoseALife()
    {
        lives--;
        if (lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
    IEnumerator ShieldPowerupDuration()
    {
        yield return new WaitForSeconds(5);
        shieldPowerupPrefab.SetActive(false);
        gameManager.ManagePowerupText(0);
    }
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag=="Powerup")
        {
            Destroy(whatDidIHit.gameObject);
            int whichPowerup = Random.Range(1,4);
            switch(whichPowerup)
            {
                //shield active
                case 3:
                shieldPowerupPrefab.SetActive(true);
                gameManager.ManagePowerupText(3);
                break;
             }
        }
    }

    void Shooting()
    {
        //if the player presses the SPACE key, create a projectile
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    void Movement()
    {
       horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0f) * Time.deltaTime * playerSpeed);
        
        //Player leaves the screen horizontally - Pac-Man to opposite side
        if(transform.position.x > horizontalScreenLimit)
        {
            transform.position = new Vector3(-horizontalScreenLimit, transform.position.y, 0f);
        }
        else if(transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(horizontalScreenLimit, transform.position.y, 0f);
        }
        
        if(transform.position.y > 0f) // If player goes above center line
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0f);
        }
        else if(transform.position.y < -verticalScreenLimit) // If player goes below bottom limit
        {
            transform.position = new Vector3(transform.position.x, 0f, 0f);
        }
    }
}