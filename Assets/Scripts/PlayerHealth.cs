using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    public GameObject DeathUI;
    public TMP_Text scoreText;

    public Slider healthBar;

    AudioManager audioManager;

    public bool isInvincible = false;
    public GameObject shieldVisual;
    public float shieldDuration = 5f;



    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return; // blokuje damage

        currentHealth -= damage;
        healthBar.value = currentHealth;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void ActivateShield()
    {
        if (isInvincible) return;

        isInvincible = true;
        if (shieldVisual != null) shieldVisual.SetActive(true);

        StartCoroutine(ShieldCountdown());
    }

    private IEnumerator ShieldCountdown()
    {
        yield return new WaitForSeconds(shieldDuration);
        isInvincible = false;
        if (shieldVisual != null) shieldVisual.SetActive(false);
    }

    void Die()
    {
        Debug.Log("Player died!");
        audioManager.PlaySFX(audioManager.gameover);
        audioManager.musicSource.Stop();
        gameObject.SetActive(false);
        Time.timeScale = 0;
        DeathUI.SetActive(true);
        scoreText.text = "Your score: " + ScoreManager.score;
    }

    public void OnClickAgain() {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(1);
        audioManager.musicSource.Play();
        ScoreManager.score = 0;
        currentHealth = 100;
        DeathUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void OnClickExit() {
        audioManager.PlaySFX(audioManager.click);
        audioManager.musicSource.Play();
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}
