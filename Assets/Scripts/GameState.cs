using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private SpriteRenderer exitPoint;
    [SerializeField] private Sprite unlockImage;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private BoxCollider2D finalFlag;
    [SerializeField] private InstructionManager instructionManager;

    [SerializeField] private int bobotNilaiSoal;
    [SerializeField] private string nextLevel;

    public static GameState gameInstance;

    public bool IsClear = false;
    public bool GameClear = false;
    public int CurrentLevel;
    public int Score = 0;

    private void OnEnable()
    {
        InstructionManager.OnCorrectSubmit += AddScore;
        PlayerMovement.OnFinish += SetupFinal;
    }

    private void OnDisable()
    {
        InstructionManager.OnCorrectSubmit -= AddScore;
        PlayerMovement.OnFinish -= SetupFinal;
    }

    private void Awake()
    {
        if (gameInstance == null)
        {
            gameInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        switch (instructionManager.CurrentLevel)
        {
            case InstructionManager.Level.LevelDasar1:
                CurrentLevel = 0;
                break;
            case InstructionManager.Level.Level1:
                CurrentLevel = 1;
                break;
            case InstructionManager.Level.Level2:
                CurrentLevel = 2;
                break;
            case InstructionManager.Level.Level3:
                CurrentLevel = 3;
                break;
            case InstructionManager.Level.Level4:
                CurrentLevel = 4;
                break;
            case InstructionManager.Level.Level5:
                CurrentLevel = 5;
                break;
            default:
                break;
        }
    }

    [ContextMenu("Init finish level")]
    public void SetInstructionStatus()
    {
        IsClear = true;
        finalFlag.isTrigger = true;
        exitPoint.sprite = unlockImage;
    }

    public void AddScore()
    {
        Score += bobotNilaiSoal;
    }

    public void SetupFinal()
    {
        GameClear = true;
        finalPanel.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(nextLevel);
    }
}
