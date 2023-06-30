 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] private Sprite[] healths;
    [SerializeField] private Image healthBarImage;
    [SerializeField] private Timer timer;

    [SerializeField] private int health = 3;
    
    private Rigidbody2D rb;
    private Animator anim;

    private void OnEnable()
    {
        InstructionManager.OnWrongSubmit += TakeDamage;
    }

    private void OnDisable()
    {
        InstructionManager.OnWrongSubmit -= TakeDamage;
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        healthBarImage.sprite = healths[health];
    }

    private void TakeDamage()
    {
        health--;
        healthBarImage.sprite = healths[health];

        if(health == 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        timer.StopTimer();
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
