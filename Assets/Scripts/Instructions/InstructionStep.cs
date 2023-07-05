using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionStep : MonoBehaviour
{
    [SerializeField] private AudioSource m_AudioSource;
    [SerializeField] private AudioClip goalClip;
    [SerializeField] private AudioClip hasilGabungClip;
    [SerializeField] private GameObject animasiGabung;

    [SerializeField] private string objectiveGoal;
    [SerializeField] private bool stepDone = false;
    [SerializeField] private bool playFirst = true;
    [SerializeField] private bool combineAbjad = false;
    [SerializeField] private bool playAnimasi = false;

    public string ObjectiveGoal => objectiveGoal;
    public bool StepDone => stepDone;

    private void Start()
    {
        if(playFirst && GameState.gameInstance.LatihanMode)
        {
            StartCoroutine(PlayAudio(goalClip));
        }
    }

    private IEnumerator PlayAudio(AudioClip clip)
    {
        yield return new WaitForSecondsRealtime(1);
        m_AudioSource.PlayOneShot(clip);
    }

    public void SetBool()
    {
        stepDone = true;
        if(!playFirst)
        {
            StartCoroutine(PlayAudio(goalClip));
        }

        if(combineAbjad)
        {
            StartCoroutine(PlayAudio(hasilGabungClip));
        }

        if (playAnimasi)
        {
            animasiGabung.SetActive(true);
        }
    }
}
