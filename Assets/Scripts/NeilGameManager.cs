using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using TMPro;

<<<<<<< Updated upstream:Assets/Scripts/NeilGameManager.cs
public class GameManager : MonoBehaviour
=======
public class TatiGameManager : MonoBehaviour
>>>>>>> Stashed changes:Assets/Scripts/TatiGameManager.cs
{
    public GameObject enemyOnePrefab;
    public GameObject enemyNeilPrefab;
    public TextMeshProUGUI livesText;
    public int score;
    public float horizontalScreenSize;
    public float verticalScreenSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        InvokeRepeating("CreateEnemyOne", 2.5f, 3f);
        Invoke("CreateEnemyNeil", 7f);
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
<<<<<<< Updated upstream:Assets/Scripts/NeilGameManager.cs
=======

    void CreateShreyaEnemy()
    {
        Instantiate(shreyaEnemyPrefab, new Vector3(Random.Range(-8f, 8f), 4.5f, 0), Quaternion.identity);
    }
    public void AddScore(int earnedScore)
    {
        score += earnedScore;
    }
    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
>>>>>>> Stashed changes:Assets/Scripts/TatiGameManager.cs
}    
