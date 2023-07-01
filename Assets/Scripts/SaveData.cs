using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveData : MonoBehaviour
{
    [SerializeField] private List<int> scores = new List<int>();
    [SerializeField] private List<string> times = new List<string>();
    
    public static SaveData SaveInstance;

    private const string _prefsKey = "ScoreAyoMembaca";

    private void Awake()
    {
        if (SaveInstance == null)
        {
            SaveInstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        Load();
    }

    private void Start()
    {
        if (scores.Count == 0)
        {
            for (int i = 0; i < 6; i++)
            {
                times.Add("00:00");
                scores.Add(0);
            }
            Save();
        }
    }

    public void UpdateLevelScore(int levelScore, int index)
    {
        
        scores[index] = levelScore;
        Save();
    }

    public void UpdateLevelTime(float time, int index) 
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string localTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        times[index] = localTime;
        Save();
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey(_prefsKey))
        {
            string json = PlayerPrefs.GetString(_prefsKey);
            JsonUtility.FromJsonOverwrite(json, this);
        }
        else
        {
            Save();
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(this);
        PlayerPrefs.SetString(_prefsKey, json);
    }

    public void ResetLastScore()
    {
        if (scores.Count == 0)
        {
            return;
        }

        scores.Clear();
        Save();
    }
}
