using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShreyaGameManager : MonoBehaviour
{

    public GameObject shreyaEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateShreyaEnemy", 2f, 5f);
    }


    void CreateShreyaEnemy()
    {
        Instantiate(shreyaEnemyPrefab, new Vector3(Random.Range(-8f, 8f), 4.5f, 0), Quaternion.identity);
    }
}
  
