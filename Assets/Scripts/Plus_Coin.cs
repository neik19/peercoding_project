using UnityEngine;

public class Plus_Coin : MonoBehaviour
{
    
    private Vector3 startPosition;


    void Update()
    {
        transform.Translate(new Vector3(0, 0, 0) * Time.deltaTime * 1f);
    }
}
