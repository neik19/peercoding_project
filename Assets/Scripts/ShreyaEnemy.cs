using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShreyaEnemy : MonoBehaviour
{
    public GameObject explosionPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * 3f);
        if (transform.position.x < -9.5f)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D whatDidIHit)
    {
        Debug.Log("Enemy hit" + whatDidIHit.gameObject.name);
        if(whatDidIHit.tag == "Player")
        {
            whatDidIHit.GetComponent<ShreyaPlayerController>().LoseALife();
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(whatDidIHit.tag == "Weapons")
        {
            Destroy(whatDidIHit.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
