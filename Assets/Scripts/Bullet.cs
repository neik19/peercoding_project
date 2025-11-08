using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        // transfrom.Translate(Vector3.up * Time.deltaTime * 8f);
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * 8f);
        if (transform.position.y > 6.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
