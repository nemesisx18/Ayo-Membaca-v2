using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSceneUI : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text finalScorePanelText;

    private GameState gameState;

    private void Start()
    {
        gameState = GameState.gameInstance;
    }

    private void Update()
    {
        scoreText.text = "Skor: " + gameState.Score;
        finalScorePanelText.text = "Skor Anda: " + gameState.Score;
    }
}
