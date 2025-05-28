using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int enemyCount;
    private bool gameOver = false;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
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
            Debug.Log("You Lose!");
        }
    }

    private void WinGame()
    {
        if (!gameOver)
        {
            gameOver = true;
            Debug.Log("You Win!");
        }
    }
}
