using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class ShreyaGameManager : MonoBehaviour
{
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
        gameOver = false;
        CreateSky();
        InvokeRepeating("CreateEnemyTots", 2.5f, 3f);
        InvokeRepeating("CreateEnemyNeil", 5f,6f);
        InvokeRepeating("CreateShreyaEnemy", 2f, 5f);
    }

    IEnumerator SpawnPlusCoin()
    {
        float spawnTime = Random.Range(3,5);
        yield return new waitForSeconds (spawnTime);
        CreatePlusCoin();
        StartCounting(SpawnPlusCoin());
    }

    void CreateSky()
    {
        for(int i =0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
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
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize*0.8, horizontalScreenSize *0.8), Random.Range(-verticalScreenSize*0.8, verticalScreenSize*0.8) 0), Quaternion.identity);
    }

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
        //lives --
        //lives -= 1
        //lives = lives -1

        //score ++
        //score += 1
        //score = score +1
    }
    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}    
