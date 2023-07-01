using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlighter : MonoBehaviour
{
    [SerializeField] private InstructionManager instructionManager;

    [SerializeField] private SpriteRenderer[] aSprite;
    [SerializeField] private SpriteRenderer[] iSprite;
    [SerializeField] private SpriteRenderer[] uSprite;
    [SerializeField] private SpriteRenderer[] eSprite;
    [SerializeField] private SpriteRenderer[] oSprite;

    private void FixedUpdate()
    {
        switch (instructionManager.StepIndex)
        {
            case 0:
                StartCoroutine(BlinkColor(aSprite));
                break;
            case 1:
                StartCoroutine(BlinkColor(iSprite));
                break;
            case 2:
                StartCoroutine(BlinkColor(uSprite));
                break;
            case 3:
                StartCoroutine(BlinkColor(eSprite));
                break;
            case 4:
                StartCoroutine(BlinkColor(oSprite));
                break;
        }
    }

    private IEnumerator BlinkColor(SpriteRenderer[] sprite)
    {
        yield return new WaitForSecondsRealtime(1);
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite[i].color = Color.red;
        }
        yield return new WaitForSecondsRealtime(3);
        for (int i = 0; i < sprite.Length; i++)
        {
            sprite[i].color = Color.white;
        }
    }
}
