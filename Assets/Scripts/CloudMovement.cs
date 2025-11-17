using System.Collections;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float verticalScreenSize = 10f;
    
    private GameManager1 gameManager;

    void Start()
    {
        // Find the GameManager to get the cloudMove value
        GameObject gmObject = GameObject.Find("GameManager1");
        if (gmObject != null)
        {
            gameManager = gmObject.GetComponent<GameManager1>();
        }
    }

    void Update()
    {
        transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        
        // If cloud moves off screen, reposition to the right
        if (transform.position.x < -verticalScreenSize - 3f)
        {
            RepositionCloud();
        }
    }

    void RepositionCloud()
    {
        // Move cloud to right side with random Y position
        float newY = Random.Range(-4f, 4f);
        transform.position = new Vector3(verticalScreenSize + 3f, newY, 4f);
    }
}