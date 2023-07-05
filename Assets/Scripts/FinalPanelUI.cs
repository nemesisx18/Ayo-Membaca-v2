using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalPanelUI : MonoBehaviour
{
    [SerializeField] private List<Text> timeTexts = new List<Text>();
    [SerializeField] private List<Text> scoreTexts = new List<Text>();
    
    private SaveData saveData;

    private void Start()
    {
        saveData = SaveData.SaveInstance;

        for (int i = 0; i < saveData.Times.Count; i++)
        {
            timeTexts[i].text = saveData.Times[i].ToString();
        }

        for (int i = 0; i < saveData.Scores.Count; i++)
        {
            scoreTexts[i].text = saveData.Scores[i].ToString();
        }
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
