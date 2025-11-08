using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject explosionPrefab;
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
            whatDidIHit.GetComponent<PlayerContoller>().LoseALife();
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
}
