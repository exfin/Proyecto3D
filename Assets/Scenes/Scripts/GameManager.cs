using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemyCount;
    private bool gameOver = false;
    public GameObject gameOverUI;
    public GameObject winUI;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if(gameOverUI.activeInHierarchy || winUI.activeInHierarchy)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else{
            Cursor.visible = false;
             Cursor.lockState = CursorLockMode.Locked;
        }
    }

    public void RegisterEnemy()
    {
        enemyCount++;
    }

    public void UnregisterEnemy()
    {
        enemyCount--;

        if (enemyCount <= 0)
        {
            WinGame();
        }
    }

    public void PlayerDied()
    {
        if (!gameOver)
        {
            gameOver = true;
            gameOverUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    private void WinGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            winUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    public void restart()
    {
        Time.timeScale = 1f;
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
