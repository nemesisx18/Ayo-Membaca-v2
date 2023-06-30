using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
                        
public class ItemCollection : MonoBehaviour
{
    private int alphabet = 0;

    [SerializeField] private Text alphabetText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Alphabet"))
        {
            Destroy(collision.gameObject);
            alphabet++;
            alphabetText.text = "Alphabet: " + alphabet;
        }
    }
}
