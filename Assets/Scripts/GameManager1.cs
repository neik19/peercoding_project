using System.Collections;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager1 : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyTotsPrefab;

    public GameObject enemyNeilPrefab;

    public GameObject shreyaEnemyPrefab;

    public GameObject cloudPrefab;

    public GameObject coinPrefab;

    public GameObject gameOverText;

    public GameObject restartText;

    public GameObject powerupPrefab;

    public GameObject audioPlayer;

    public AudioClip powerUpSound;

    public AudioClip powerDownSound;

    public AudioClip explosionBoom;

    public TextMeshProUGUI livesText;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI powerUpText;

    public int score;

    public int cloudMove;

    public float horizontalScreenSize;

    public float verticalScreenSize;

    private bool gameOver;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        horizontalScreenSize = 10f;
        verticalScreenSize = 6.5f;
        score = 0;
        cloudMove = 1;
        gameOver = false;
        AddScore(0);
        Instantiate(playerPrefab, transform.position, Quaternion.identity);
        CreateSky();
        InvokeRepeating("CreateEnemyTots", 2.5f, 3f);
        InvokeRepeating("CreateEnemyNeil", 5f,6f);
        InvokeRepeating("CreateShreyaEnemy", 2f, 5f);
        StartCoroutine(SpawnPlusCoin());
        StartCoroutine(SpawnPowerup());
        powerUpText.text = "No Power Ups yet!";

    }

    IEnumerator SpawnPlusCoin()
    {
        float spawnTime = Random.Range(4,8);
        yield return new WaitForSeconds (spawnTime);
        CreatePlusCoin();
        StartCoroutine(SpawnPlusCoin());
    }

    IEnumerator SpawnPowerup()
    {
        float spawnTime = Random.Range(3, 5);
        yield return new WaitForSeconds(spawnTime);
        CreatePowerUp();
        StartCoroutine(SpawnPowerup());

    }
    void CreatePowerUp()
    {
        Instantiate(powerupPrefab, new Vector3(Random.Range(-horizontalScreenSize * 0.8f, horizontalScreenSize * 0.8f), Random.Range(-verticalScreenSize * 0.8f, verticalScreenSize * 0.8f), 0), Quaternion.identity);
    }

    void CreatePlusCoin()
    {
        Instantiate(coinPrefab, new Vector3(Random.Range(-horizontalScreenSize*0.8f, horizontalScreenSize *0.8f), Random.Range(-verticalScreenSize*0.6f, verticalScreenSize*0.6f), 0), Quaternion.identity);
    }

    public void ManagePowerupText(int powerUpType)
    {
        switch(powerUpType)
        {
            case 1:
                powerUpText.text = "Extra Health!";
                break;
            case 2:
                powerUpText.text = "Bonus points!";
                break;
            default:
                powerUpText.text = "No PowerUps yet!";
                break;
        }
    }
        public void PlaySound(int whichSound)
    {
        switch (whichSound)
        {
            case 1:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerUpSound);
                break;
            case 2:
                audioPlayer.GetComponent<AudioSource>().PlayOneShot(powerDownSound);
                break;
        }
    }
    void CreateSky()
    {
        for(int i =0; i < 30; i++)
        {
            Instantiate(cloudPrefab, new Vector3(Random.Range(-horizontalScreenSize* 2f, horizontalScreenSize + 3f), Random.Range(-verticalScreenSize + 2f, verticalScreenSize), 4f), Quaternion.identity);
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        if(gameOver && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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

    public void AddScore(int earnedScore)
    {
        score += earnedScore;
        scoreText.text = "Score: " + score;
    }
    public void ChangeLivesText(int currentLives)
    {
        livesText.text = "Lives: " + currentLives;
    }
    public void GameOver()
    {
        gameOverText.SetActive(true);
        restartText.SetActive(true);
        gameOver = true;
        CancelInvoke();
        cloudMove = 0;
    }
}    
