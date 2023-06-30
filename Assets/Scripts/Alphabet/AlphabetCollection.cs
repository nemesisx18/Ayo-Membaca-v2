using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlphabetCollection : MonoBehaviour
{
    [SerializeField] private List<string> _alphabet = new List<string>();
    [SerializeField] private string _alphabetName;
    [SerializeField] private string _alphabetVocalName;
    [SerializeField] private string _alphabetKonsonanName;

    [SerializeField] private Text _alphabetText;
    [SerializeField] private Text hurufKananText;
    [SerializeField] private Text hurufKiriText;

    public delegate void HurufCollection(string huruf);
    public static event HurufCollection AlphabetCollectionChanged;

    private void OnEnable()
    {
        AlphabetItem.OnPlayerHit += AddAlphabet;
        AlphabetItem.OnPlayerHitVokal += AddVocal;
        AlphabetItem.OnPlayerHitKonsonan += AddKonsonan;
    }

    private void OnDisable()
    {
        AlphabetItem.OnPlayerHit -= AddAlphabet;
        AlphabetItem.OnPlayerHitVokal -= AddVocal;
        AlphabetItem.OnPlayerHitKonsonan -= AddKonsonan;
    }

    private void AddAlphabet(string alphabet)
    {
        _alphabet.Add(alphabet);
        _alphabetName = alphabet;
    }

    private void AddVocal(string alphabet)
    {
        _alphabetVocalName = alphabet;
        _alphabetText.text = alphabet;
        hurufKananText.text = alphabet;
        CombineAlpha();
    }

    private void AddKonsonan(string alphabet)
    {
        _alphabetKonsonanName = alphabet;
        hurufKiriText.text = alphabet;
        CombineAlpha();
    }

    private void CombineAlpha()
    {
        if (_alphabetVocalName != "" && _alphabetKonsonanName != "")
        {
            Debug.Log(_alphabetKonsonanName + _alphabetVocalName);
            AlphabetCollectionChanged?.Invoke(_alphabetKonsonanName + _alphabetVocalName);
            StartCoroutine(CooldownReset());
        }
    }

    private IEnumerator CooldownReset()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        hurufKananText.text = "";
        hurufKiriText.text = "";
        _alphabetText.text = "";
        _alphabetVocalName = "";
        _alphabetKonsonanName = "";
    }
}
