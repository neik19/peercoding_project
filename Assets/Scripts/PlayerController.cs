using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public int lives;
    private float playerSpeed;
    private float horizontalInput;
    private float verticalInput;

    private float horizontalScreenLimit = 9.5f;
    private float verticalScreenLimit = 6.5f;
    public GameObject explosionPrefab;
    public GameObject bulletPrefab;
    private GameManager gameManager;


    void Start()
    {
        playerSpeed = 6f;
        lives = 3;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        gameManager.ChangeLivesText(lives);
    }
    public void LoseALife()
    {
        lives--;
        gameManager.ChangeLivesText(lives);
        if(lives==0)
        {
<<<<<<< Updated upstream:Assets/Scripts/Player.cs
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
=======
            Debug.Log("Pew Pew"+ horizontalScreenLimit);
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
>>>>>>> Stashed changes:Assets/Scripts/PlayerController.cs
        }
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        //shooting
        Movement();
        Shooting();
    }
    void Movement()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //move the player
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * Time.deltaTime * playerSpeed);
        //limit the player movement to the screen
        if (transform.position.x > horizontalScreenLimit || transform.position.x < -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y < -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, -transform.position.y, 0);
        }
    }
    //shooting
    void Shooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Pew Pew" + horizontalScreenLimit);
            //spawn bullet
            Instantiate(bulletPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }
}
