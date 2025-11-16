using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;

public class ShreyaGameManager : MonoBehaviour
{
    public GameObject Player;
    
    public GameObject enemyTotsPrefab;

    public GameObject enemyNeilPrefab;

    public GameObject shreyaEnemyPrefab;

    public GameObject cloudPrefab;

    public TextMeshProUGUI livesText;

    public GameObject gameOverText;

    public GameObject coinPrefab;

    public GameObject audioPlayer;

    public AudioClip explosionBoom;

    public int score;

    public int cloudMove;

    public float horizontalScreenSize;

    public float verticalScreenSize;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        cloudMove = 1;
        CreateSky();
        InvokeRepeating("CreateEnemyTots", 2.5f, 3f);
        InvokeRepeating("CreateEnemyNeil", 5f,6f);
        InvokeRepeating("CreateShreyaEnemy", 2f, 5f);
        StartCoroutine(SpawnPlusCoin());
    }

    IEnumerator SpawnPlusCoin()
    {
        float spawnTime = Random.Range(4,8);
        yield return new WaitForSeconds (spawnTime);
        CreatePlusCoin();
        StartCoroutine(SpawnPlusCoin());
    }

    void CreateSky()
    {
        for(int i =0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize* 2f, horizontalScreenSize + 3f), Random.Range(-verticalScreenSize + 2f, verticalScreenSize), 4f), Quaternion.identity);
        }
        
    }
    void CreateEnemyTots()
    { 
        Instantiate(enemyTotsPrefab, new Vector3(Random.Range(-8f, 8f), 6.5f, 0), Quaternion.identity);
    }

    void CreateEnemyNeil()
    { 
        Instantiate(enemyNeilPrefab, new Vector3(Random.Range(-8f, 8f), 4.5f, 0), Quaternion.identity);
    }

    void CreateShreyaEnemy()
    {
        Instantiate(shreyaEnemyPrefab, new Vector3(Random.Range(-8f, 8f), 4.5f, 0), Quaternion.identity);
    }

    void CreatePlusCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize*0.8f, horizontalScreenSize *0.8f), Random.Range(-verticalScreenSize*0.6f, verticalScreenSize*0.6f), 0), Quaternion.identity);
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
    }
    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}    
