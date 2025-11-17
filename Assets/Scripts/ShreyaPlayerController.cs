using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShreyaPlayerController : MonoBehaviour
{
    //movement
    //shooting
    //scope access modifier private or public
    public int lives;
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;

    public GameObject explosionPrefab;
    public GameObject bulletPrefab;
    private GameManager1 gameManager;

    void Start()
    {
        gameManager = GameObject.Find("GameManager1").GetComponent<GameManager1>();
        playerSpeed = 8f;
        lives = 3;
        // Set initial spawn position lower on the screen
        // Spawn at bottom half
        transform.position = new Vector3(0, -3f, 0);
        gameManager.ChangeLivesText(lives);
    }
    public void LoseALife ()
    {

        lives--;
        
        gameManager.ChangeLivesText(lives);
        if(lives == 0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
            gameManager.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Powerup")
        {
            Destroy(whatDidIHit.gameObject);
            int whichPowerup = Random.Range(1, 3);
            gameManager.PlaySound(1);
            switch (whichPowerup)
            {
                case 1:
                    //Picked up health
                    gameManager.ManagePowerupText(1);
                    gameManager.PlaySound(1);
                    break;
            }
        }
        else if(whatDidIHit.tag == "PlusCoin")
        {
            Destroy(whatDidIHit.gameObject);
            int whichPowerup = Random.Range(1, 3);
            gameManager.PlaySound(2);
            switch (whichPowerup)
            {
                case 2:
                    //Picked up coin
                    gameManager.ManagePowerupText(2);
                    break;
            }
        }    
        else if(whatDidIHit.tag == "Enemy")
        {
            Destroy(whatDidIHit.gameObject); // Destroy the enemy
            LoseALife(); // Player loses a life
            gameManager.PlaySound(3);
        }
        
    }
    void Update()
    {
        //This function is called every frame; 60 frames/second
        Movement();
        Shooting();
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
        
        if(transform.position.y > verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -verticalScreenLimit, 0f);
        }
        else if(transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, verticalScreenLimit, 0f);
        }
    }
}