using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isGameOver {  get; private set; }

    [SerializeField] private GameObject gameOverPanel;

    private int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isGameOver = false;
        if(gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public void GameOver()
    {
        if (isGameOver)
            return;

        isGameOver = true;

        if(gameOverPanel!=null)
            gameOverPanel.SetActive(true);

        Time.timeScale = 0f;
    }

}
