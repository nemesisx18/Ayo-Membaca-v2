using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float localTime = 0;

    public bool timerIsRunning = false;

    public Text timeText;
    public Text timePanelText;

    private void OnEnable()
    {
        PlayerMovement.OnFinish += StopTimer;
    }
    private void OnDisable()
    {
        PlayerMovement.OnFinish -= StopTimer;
    }

    void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
    }

    void Update()
    {
        if (timerIsRunning)
        {
            RunTimer();
        }
    }

    public void RunTimer()
    {
        localTime += Time.deltaTime;
        DisplayTime(localTime);
    }

    [ContextMenu("Save & stop time data")]
    public void StopTimer()
    {
        timerIsRunning = false;
        if (!GameState.gameInstance.LatihanMode)
        {
            SaveData.SaveInstance.UpdateLevelTime(localTime, GameState.gameInstance.CurrentLevel);
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        timePanelText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }


}
