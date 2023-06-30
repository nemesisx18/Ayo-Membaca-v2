using System.Collections.Generic;
using UnityEngine;

public class AlphabetItem : MonoBehaviour
{
    [SerializeField] private string _alphabet;
    [SerializeField] private bool _isBlankBox = false;
    [SerializeField] private bool _hurufVocal = false;
    [SerializeField] private bool _dontDestroy = false;
    [SerializeField] private bool _isAlreadyHit = false;
    [SerializeField] private bool _hurufKonsonan = false;

    private List<GameObject> _childAlphabet = new List<GameObject>();
    private GameState gameState;

    public string Alphabet => _alphabet;
    public bool HurufVocal => _hurufVocal;
    public bool HurufKonsonan => _hurufKonsonan;

    public delegate void AlphabetHit(string alphabet);
    public static event AlphabetHit OnPlayerHit;
    public static event AlphabetHit OnPlayerHitVokal;
    public static event AlphabetHit OnPlayerHitKonsonan;

    private void Start()
    {
        gameState = GameState.gameInstance;

        if (!_isBlankBox)
        {
            for (int i = 0; i < gameObject.transform.childCount; i++)
            {
                _childAlphabet.Add(gameObject.transform.GetChild(i).gameObject);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player_Head" && !gameState.IsClear)
        {
            if (!_isBlankBox && !_isAlreadyHit)
            {
                if (_hurufKonsonan)
                {
                    OnPlayerHitKonsonan?.Invoke(_alphabet);
                    return;
                }
                if (_hurufVocal)
                {
                    OnPlayerHitVokal?.Invoke(_alphabet);
                    return;

                }

                OnPlayerHit?.Invoke(_alphabet);
                if(!_dontDestroy)
                {
                    for (int i = 0; i < _childAlphabet.Count; i++)
                    {
                        _childAlphabet[i].SetActive(false);
                    }

                    _isAlreadyHit = true;
                }
            }
        }
    }
}
