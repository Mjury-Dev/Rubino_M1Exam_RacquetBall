using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour
{
    public float resetDelay = 1f;
    public GameObject spikes;
    public GameObject racquet;
    public GameObject ball;
    public GameObject deathParticles;
    public GameObject frontWall;
    public GameObject backWall;
    private int bounceCount;

   
    public TextMesh scoreTextMesh;

    public static GameManager instance = null;

    
    void Start()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        frontWall = GameObject.Find("FrontWall");
        backWall = GameObject.Find("BackWall");
        racquet = GameObject.Find("Racquet");
        ball = GameObject.Find("Ball");
        spikes = GameObject.Find("Spikes");

        deathParticles = GameObject.Find("DeathParticles");

        bounceCount = 0;

        Setup();
        UpdateScoreText();
    }

    public void Setup()
    {
        spikes.SetActive(false);
    }

    private void Update()
    {
        if (bounceCount > 5)
        {
            spikes.SetActive(true);
        }
    }

    public void AddCount()
    {
        bounceCount++;
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreTextMesh != null)
        {
            scoreTextMesh.text = "Score: " + bounceCount;
        }
        else
        {
            Debug.LogError("Score TextMesh not assigned in GameManager!");
        }
    }

    public void Reset()
    {
        // Fix applied here — using SceneManager instead of obsolete Application.loadedLevel
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void DeadBall()
    {
        Destroy(racquet);
        Instantiate(Resources.Load("DeathParticles"), ball.transform.position, Quaternion.identity);
        Invoke("Reset", resetDelay);
    }
}
