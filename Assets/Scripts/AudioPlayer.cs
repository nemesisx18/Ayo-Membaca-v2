using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float audioPlayTime = 3f;

    private IEnumerator Start()
    {
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(audioPlayTime);
        audioSource.Stop();
        Time.timeScale = 1;
    }
}
