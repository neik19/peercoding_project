using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;
<<<<<<< Updated upstream
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
=======
>>>>>>> Stashed changes
    void Update()
    {
        transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * 8f);
        if (transform.position.y < -6.5f)
        {
            Destroy(gameObject);
        }
    }
     private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        Debug.Log("Enemy Hit " + whatDidIHit.gameObject.name);
        if (whatDidIHit.tag == "Player")
        {
            // notify player if it implements LoseALife; SendMessage won't require the method to exist at compile time
            whatDidIHit.gameObject.SendMessage("LoseALife", SendMessageOptions.DontRequireReceiver);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if (whatDidIHit.tag=="Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
<<<<<<< Updated upstream
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        if(whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<PlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } else if(whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
=======
>>>>>>> Stashed changes
}