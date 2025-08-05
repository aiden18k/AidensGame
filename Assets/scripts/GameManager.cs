//imports
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //THIS IS THE TOP OF THE CLASS
    public bool isGameRunning;
    //Add variables for points
    public int points;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public static GameManager Instance;

    //  General game states
    // add variable for is game over
    public bool isGameOver;
    //1. Add the first variable below this line
    public int playerHealth = 100;


    //1. Add the second variable below this line
    public GameObject startMenuUI;
    public int maxHealth = 100;

    //  UI Elements (drag in Inspector)
    public GameObject pauseMenuUI;
    public GameObject gameOverUI;
    //3. Add the third variable below this line

    public GameObject healthBar;

    //  Optional Audio
    public AudioSource bgMusic;
    public bool isGamePaused;
    void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        Time.timeScale = 0f; // Game paused at start
        //ShowStartMenu();
        //UpdateHealthUI(); // Initial health setup
    }

    void Update()
    {
        //  Toggle pause with Escape
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (isGamePaused)
                ResumeGame();
            else
                PauseGame();
        }

        //  TEMP: Restart game with R (only if game is over)
        if (isGameOver && Input.GetKeyDown(KeyCode.R))
        {
            RestartGame();
        }
    }

    //Complete: Start Menu Logic 
    //1. Create the start game function , then add the code

    //Complete: Pause/Resume Logic
    public void PauseGame()
    {
        //pauseMenuUI.SetActive(true);

        if (isGamePaused)
        {
            Time.timeScale = 1;
            isGamePaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isGamePaused = true;
        }

    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    //Health System
    public void TakeDamage(int amount)
    {
        playerHealth -= amount;
        if (playerHealth <= 0)
        {
            playerHealth = 0;
            GameOver();
        }
        //UpdateHealthUI();
    }

    //2. Add the end game function on the line below
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0f;
        gameOverUI.SetActive(true);
        Debug.Log("Game Over!");

    }
    // ✅ Restart
    public void RestartGame()
    {
        Time.timeScale = 1f;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void StartGame()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        if (bgMusic != null) bgMusic.Play();


    }

}
