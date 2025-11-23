using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    private float speed;
    public float moveSpeed;
    public float verticalScreenSize;
    private GameManager1 gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager1").GetComponent<GameManager1>();
        transform.localScale = transform.localScale * Random.Range(0.1f, 0.6f);
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Random.Range(0.1f, 0.7f));
        speed = Random.Range(3f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        speed = gameManager.cloudMove * speed;
        transform.Translate(new Vector3(0,-1,0) * speed * Time.deltaTime);

        if (transform.position.y < -gameManager.verticalScreenSize)
        {
            transform.position = new Vector3(Random.Range(-gameManager.horizontalScreenSize, gameManager.horizontalScreenSize), gameManager.verticalScreenSize * 3f, 0);
        }
        
    }
}