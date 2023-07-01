using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUIScene : MonoBehaviour
{
    [SerializeField] private Button latihanButton;
    [SerializeField] private Button pertandinganButton;

    [SerializeField] private string latihanSceneName;
    [SerializeField] private string pertandinganSceneName;

    private void Start()
    {
        latihanButton.onClick.AddListener(LatihanSection);
        pertandinganButton.onClick.AddListener(PertandinganSection);
    }

    private void LatihanSection()
    {
        SaveData.SaveInstance.isLatihanMode = true;
        SceneManager.LoadScene(latihanSceneName);
    }

    private void PertandinganSection()
    {
        SaveData.SaveInstance.isLatihanMode = false;
        SceneManager.LoadScene(pertandinganSceneName);
    }
}
