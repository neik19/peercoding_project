using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int lives;
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 4f; // Changed to 4f for bottom half
    public GameObject explosionPrefab;
    public GameObject bulletPrefab;
    private GameManager gameManager;


    void Start()
    {
        playerSpeed = 8f;
        lives = 3;
        // Set initial spawn position lower on the screen
        transform.position = new Vector3(0, -3f, 0); // Spawn at bottom half
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.ChangeLivesText(lives);
    }
    public void LoseALife()
    {
        lives--;
        gameManager.ChangeLivesText(lives);

        if(lives==0)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
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