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
    private bool isAlive = true;

    [Header("Shield Settings")]
        public GameObject shieldActive; // Reference to shield mesh/effect
        private bool hasShield = false;
        private GameObject currentShield;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;

    public GameObject explosionPrefab;
    public GameObject bulletPrefab;
    private GameManager1 gameManager;
    

    void Start()
    {
        gameManager = GameObject.Find("GameManager1").GetComponent<GameManager1>();
        playerSpeed = 8f;
        lives = 1;
        // Set initial spawn position lower on the screen
        // Spawn at bottom half
        transform.position = new Vector3(0, 0f, 0);
        gameManager.ChangeLivesText(lives);
    }
    private void LoseALife()
    {
        if (!isAlive) return;
        
        // Check if shield absorbs the hit
        if (hasShield)
        {
            UseShield();
            return; // Shield blocked the damage!
        }
        
        lives--;
        gameManager.ChangeLivesText(lives);
        
        if (lives <= 0)
        {
            Die(); 
        }
        else
        {
            gameManager.PlayPlayerDamageSound();
        }
    }
    private void Die()
    {
        isAlive = false;
        
        // Show explosion
        if (explosionPrefab != null)
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        }
        
        // Notify GameManager
        if (gameManager != null)
        {
            gameManager.GameOver();
        }
        
        // Destroy after a short delay so explosion can be seen
        Destroy(gameObject);
    }

    public void AddALife()
    {
        if (lives < 3)
        {
            lives++;
            
            if (gameManager != null)
            {
                gameManager.ChangeLivesText(lives);
            }
        }
        else
        {
            if (gameManager != null)
            {
                gameManager.ManagePowerupText(3);
            }
        }
    }

    public void BonusPoints()
    {
        if (gameManager !=null)
        {
            gameManager.AddScore(10);
        }
    }

    public void ActivateShield()
    {
        if (hasShield) return; // Don't stack shields
        
        hasShield = true;
        
        // Create shield visual around player
        if (shieldActive != null)
        {
            currentShield = Instantiate(shieldActive, transform.position, Quaternion.identity);
            currentShield.transform.SetParent(transform); // Make it follow player
            currentShield.transform.localPosition = Vector3.zero; // Center on player
        }
    }

    private void UseShield()
    {
        if (!hasShield) return;
        
        hasShield = false;
        
        // Remove shield visual
        if (currentShield != null)
        {
            Destroy(currentShield);
            gameManager.PlaySound(5);
        }
    }


    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Powerup")
        {
            Destroy(whatDidIHit.gameObject);
            AddALife();
            gameManager.ManagePowerupText(1);
            gameManager.PlaySound(1);
        }
        else if(whatDidIHit.tag == "PlusCoin")
        {
            Destroy(whatDidIHit.gameObject);
            BonusPoints();
            gameManager.ManagePowerupText(2);
            gameManager.PlaySound(2);
        }    
        else if(whatDidIHit.tag == "Shield")
        {
            Destroy(whatDidIHit.gameObject);
            ActivateShield();
            gameManager.ManagePowerupText(3); // Directly set to Shield
            gameManager.PlaySound(3); // Play Shield sound
        }    
        
        else if(whatDidIHit.tag == "Enemy")
        {
            Destroy(whatDidIHit.gameObject);
            LoseALife();
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