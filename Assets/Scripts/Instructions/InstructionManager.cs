using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip m_Clip;

    [SerializeField] private List<InstructionStep> instructionSteps = new List<InstructionStep>();
    [SerializeField] private Text instructionText;
    [SerializeField] private Text currentAbjadText;
    [SerializeField] private Level currentLevel;

    [SerializeField] private int wordGoal = 0;
    [SerializeField] private int stepIndex = 0;
    [SerializeField] private int wordCount = 0;
    [SerializeField] private string instructionCommand;

    private string currentAlphabet;
    private GameState gameState;

    public int StepIndex => stepIndex;
    public Level CurrentLevel => currentLevel;
    public List<InstructionStep> InstructionSteps => instructionSteps;


    public delegate void SubmitInstruction();
    public static event SubmitInstruction OnWrongSubmit;
    public static event SubmitInstruction OnCorrectSubmit;

    public enum Level
    {
        LevelDasar1,
        LevelDasar2,
        Level1,
        Level2,
        Level3,
        Level4,
        Level5
    }

    private void OnEnable()
    {
        switch (currentLevel)
        {
            case Level.LevelDasar1:
                Debug.Log("Sekarang level dasar 1");
                AlphabetItem.OnPlayerHit += SetAlphabet;
                break;
            case Level.LevelDasar2:
                Debug.Log("Sekarang level dasar 2");
                AlphabetCollection.AlphabetCollectionChanged += SetAlphabet2;
                break;
            case Level.Level1:
                Debug.Log("Sekarang level 1");
                wordGoal = 2;
                AlphabetItem.OnPlayerHit += SetAlphabet3;
                break;
            case Level.Level2:
                Debug.Log("Sekarang level 2");
                wordGoal = 2;
                AlphabetItem.OnPlayerHit += SetAlphabet3;
                break;
            case Level.Level3:
                Debug.Log("Sekarang level 3");
                wordGoal = 2;
                AlphabetItem.OnPlayerHit += SetAlphabet3;
                break;
            case Level.Level4:
                Debug.Log("Sekarang level 4");
                wordGoal = 3;
                AlphabetItem.OnPlayerHit += SetAlphabet3;
                break;
            case Level.Level5:
                Debug.Log("Sekarang level 5");
                wordGoal = 3;
                AlphabetItem.OnPlayerHit += SetAlphabet3;
                break;
            default:
                Debug.Log("No level found");
                break;
        }
    }

    private void OnDisable()
    {
        switch (currentLevel)
        {
            case Level.LevelDasar1:
                AlphabetItem.OnPlayerHit -= SetAlphabet;
                break;
            case Level.LevelDasar2:
                AlphabetCollection.AlphabetCollectionChanged -= SetAlphabet2;
                break;
            case Level.Level1:
                AlphabetItem.OnPlayerHit -= SetAlphabet3;
                break;
            case Level.Level2:
                AlphabetItem.OnPlayerHit -= SetAlphabet3;
                break;
            case Level.Level3:
                AlphabetItem.OnPlayerHit -= SetAlphabet3;
                break;
            case Level.Level4:
                AlphabetItem.OnPlayerHit -= SetAlphabet3;
                break;
            case Level.Level5:
                AlphabetItem.OnPlayerHit -= SetAlphabet3;
                break;
            default:
                Debug.Log("No level found");
                break;
        }
    }

    private void Start()
    {
        gameState = GameState.gameInstance;
        InitInstruction();
    }

    private void SetAlphabet(string alphabet)
    {
        if (gameState.IsClear)
        {
            return;
        }

        currentAlphabet = alphabet;

        if (currentAlphabet == instructionSteps[stepIndex].ObjectiveGoal)
        {
            OnCorrectSubmit?.Invoke();
            instructionSteps[stepIndex].SetBool();
            if (currentLevel != Level.LevelDasar1)
            {
                StartCoroutine(WaitStep());
                return;
            }
            NextStep();
        }
        else
        {
            if (!gameState.LatihanMode)
            {
                Debug.Log("Wrong!!!!!");
                m_AudioSource.PlayOneShot(m_Clip);
                OnWrongSubmit?.Invoke();
            }
        }
    }

    private void SetAlphabet2(string alphabet)
    {
        if (gameState.IsClear)
        {
            return;
        }

        currentAlphabet = alphabet;

        if (currentAlphabet == instructionSteps[stepIndex].ObjectiveGoal)
        {
            instructionSteps[stepIndex].SetBool();
            if (currentLevel != Level.LevelDasar1)
            {
                StartCoroutine(WaitStep());
                return;
            }
            NextStep();
        }

        //for (int i = 0; i < instructionSteps.Count; i++)
        //{
        //    if (currentAlphabet == instructionSteps[i].ObjectiveGoal && !instructionSteps[i].StepDone)
        //    {
        //        instructionSteps[i].SetBool();
        //        stepIndex++;
        //        if (stepIndex >= instructionSteps.Count)
        //        {
        //            Debug.Log("Objective clear!");
        //            instructionText.text = "Objektif tercapai! SIlahkan menuju pintu keluar!!";
        //            gameState.SetInstructionStatus();
        //            break;
        //        }
        //        break;
        //    }
        //}
    }

    private void SetAlphabet3(string alphabet)
    {
        if (gameState.IsClear)
        {
            return;
        }

        currentAlphabet += alphabet;
        currentAbjadText.text = currentAlphabet;
        wordCount++;

        Debug.Log(currentAlphabet);

        if (wordCount == wordGoal)
        {
            if (currentAlphabet == instructionSteps[stepIndex].ObjectiveGoal)
            {
                StartCoroutine(ResetWord());
                OnCorrectSubmit?.Invoke();
                instructionSteps[stepIndex].SetBool();
                if (currentLevel != Level.LevelDasar1)
                {
                    StartCoroutine(WaitStep());
                    return;
                }
                NextStep();
            }
            else
            {
                StartCoroutine(ResetWord());
                if (!gameState.LatihanMode)
                {
                    Debug.Log("Wrong!!!!!");
                    m_AudioSource.PlayOneShot(m_Clip);
                    OnWrongSubmit?.Invoke();
                }
            }
        }
    }

    private void InitInstruction()
    {
        if (gameState.LatihanMode)
        {
            instructionSteps[stepIndex].gameObject.SetActive(true);
            instructionText.text = instructionCommand + "''" + instructionSteps[stepIndex].ObjectiveGoal + "''";
        }
        else
        {
            instructionSteps[stepIndex].gameObject.SetActive(true);
            instructionText.text = "''" + instructionSteps[stepIndex].ObjectiveGoal + "''";
        }
    }

    [ContextMenu("Next Step")]
    private void NextStep()
    {
        if (stepIndex < instructionSteps.Count)
        {
            instructionSteps[stepIndex].gameObject.SetActive(false);
            stepIndex++;

            if (stepIndex >= instructionSteps.Count)
            {
                Debug.Log("Objective clear!");
                instructionText.text = "Objektif tercapai! SIlahkan menuju pintu keluar!!";
                gameState.SetInstructionStatus();
                return;
            }
            if (gameState.LatihanMode)
            {
                instructionText.text = instructionCommand + "''" + instructionSteps[stepIndex].ObjectiveGoal + "''";
                instructionSteps[stepIndex].gameObject.SetActive(true);
            }
            else
            {
                instructionText.text = "''" + instructionSteps[stepIndex].ObjectiveGoal + "''";
                instructionSteps[stepIndex].gameObject.SetActive(true);
            }
        }
    }

    private IEnumerator WaitStep()
    {
        yield return new WaitForSecondsRealtime(3f);
        NextStep();
    }

    private IEnumerator ResetWord()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        wordCount = 0;
        currentAlphabet = "";
        currentAbjadText.text = "";
    }
}
