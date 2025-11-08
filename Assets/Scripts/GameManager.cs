using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemyOnePrefab;
    public GameObject cloudPrefab;
    public TextMeshProUGUI livesText;
    public int score;
    public float horizontalScreenSize;
    public float verticalScreenSize;
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        CreateSky();

        InvokeRepeating("CreateEnemyOne", 2f, 3f);
    }
    void CreateSky()
    {
        for(int i=0; i<30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize, horizontalScreenSize), Random.Range(-verticalScreenSize, verticalScreenSize), 0), Quaternion.identity);
        }
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOnePrefab, new Vector3(Random.Range(-8f, 8f), 6.5f, 0), Quaternion.identity);
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
