using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseUI : MonoBehaviour
{
    [SerializeField] private Button menuButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button retryButton;
    [SerializeField] private Button resumeButton;
    [SerializeField] private GameObject pausePanel;

    [SerializeField] private string sceneName;

    private void Start()
    {
        retryButton.onClick.AddListener(Retry);
        menuButton.onClick.AddListener(BackToMenu);
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(UnpauseGame);
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Retry()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
}
