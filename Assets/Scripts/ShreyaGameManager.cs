using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShreyaGameManager : MonoBehaviour
{

    public GameObject shreyaEnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateShreyaEnemy", 1, 2);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void CreateEnemyOne()
    {
        Instantiate(shreyaEnemyPrefab, new Vector3(Random.Range(-9f, 9f), 6.5f, 0), Quaternion.identity);
    }
}
  
