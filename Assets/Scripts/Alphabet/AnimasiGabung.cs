using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimasiGabung : MonoBehaviour
{
    [SerializeField] private Image hurufKiriLuar;
    [SerializeField] private Image hurufKiriDalam;
    [SerializeField] private Image hurufKananLuar;
    [SerializeField] private Image hurufKananDalam;

    [SerializeField] private Sprite hurufKiriLuarImage;
    [SerializeField] private Sprite hurufKiriDalamImage;
    [SerializeField] private Sprite hurufKananLuarImage;
    [SerializeField] private Sprite hurufKananDalamImage;

    [SerializeField] private Animator animator;

    [SerializeField] private bool isDoubleWord = false;
    [SerializeField] private bool isDoubleWordKanan = false;

    private void OnEnable()
    {
        hurufKiriLuar.sprite = hurufKiriLuarImage;
        hurufKiriDalam.sprite = hurufKiriDalamImage;
        hurufKananLuar.sprite = hurufKananLuarImage;
        hurufKananDalam.sprite = hurufKananDalamImage;
    }

    private IEnumerator Start()
    {
        if(isDoubleWord)
        {
            hurufKiriLuar.gameObject.SetActive(true);
        }
        if(isDoubleWordKanan)
        {
            hurufKananLuar.gameObject.SetActive(true);
        }
        
        animator.Play("GabungHuruf");

        yield return new WaitForSecondsRealtime(3f);

        gameObject.SetActive(false);
    }
}
