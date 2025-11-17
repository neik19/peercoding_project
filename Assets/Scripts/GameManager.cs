using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemyTotsPrefab;
    public GameObject enemyNeilPrefab;
    public GameObject shreyaEnemyPrefab;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public int score;
    public float horizontalScreenSize;
    public float verticalScreenSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        InvokeRepeating("CreateEnemyTots", 2.5f, 3f);
        Invoke("CreateEnemyNeil", 7f);
        InvokeRepeating("CreateShreyaEnemy", 2f, 5f);
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
     public void AddScore(int earnedScore)
    {
        score = score + earnedScore;
        scoreText.text = "Score: " + score;
    }
}    
