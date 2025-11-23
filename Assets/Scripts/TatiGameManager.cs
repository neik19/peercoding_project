using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class TatiGameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyOnePrefab;
    public GameObject enemyNeilPrefab;
    public GameObject shreyaEnemyPrefab;
    public GameObject shieldPowerupPrefab;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI shieldPowerupText;
    public TextMeshProUGUI powerUpText;
    public int score;
    public float horizontalScreenSize;
    public float verticalScreenSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        AddScore(0);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemyOne", 2.5f, 3f);
        Invoke("CreateEnemyNeil", 7f);
        InvokeRepeating("CreateShreyaEnemy", 2f, 5f);
        StartCoroutine(SpawnShieldPowerup());
        shieldPowerupText.text = "No Shield Active";
    }
    IEnumerator SpawnShieldPowerup()
    {
        float spawnTime = Random.Range(4,8);
        yield return new WaitForSeconds (spawnTime);
        CreateShieldPowerup();
        StartCoroutine(SpawnShieldPowerup());
    }
    void CreateShieldPowerup()
    {
        Debug.Log("Shield Powerup created");
       Instantiate(shieldPowerupPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize * 0.8f, verticalScreenSize * 0.8f), 0), Quaternion.identity);
    }
    public void ManagePowerupText(int powerUpType)
    {
         switch(powerUpType)
        {
            case 1:
                shieldPowerupText.text = "Shield Activated!";
                break;
            default:
                powerUpText.text = "No Shield Active";
                break;
        }
    }

    void CreateEnemyOne()
    { 
        Debug.Log("Enemy One created");

        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8f, 8f), 6.5f, 0), Quaternion.identity);
    }

        void CreateEnemyNeil()
    { 
        Debug.Log("Enemy Neil created");

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

    public void ChangeLivesText (int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
}    
