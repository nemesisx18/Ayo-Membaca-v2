using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour
{
    [SerializeField] private SpriteRenderer exitPoint;
    [SerializeField] private Sprite unlockImage;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private BoxCollider2D finalFlag;

    [SerializeField] private int bobotNilaiSoal;
    [SerializeField] private string nextLevel;
    
    public static GameState gameInstance;

    public bool IsClear = false;
    public bool GameClear = false;
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
