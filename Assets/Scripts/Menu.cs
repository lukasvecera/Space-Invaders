using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public Canvas confirmMenu;
    AudioManager audioManager;

    private void Awake() 
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        confirmMenu.enabled = false;
    }

    public void PlayGame() {
        audioManager.PlaySFX(audioManager.click);
        SceneManager.LoadScene(1);
        ScoreManager.score = 0;
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        audioManager.PlaySFX(audioManager.click);
        confirmMenu.enabled = true;
        mainMenu.SetActive(false);
    }

    public void clickYes() {
        audioManager.PlaySFX(audioManager.click);
        Application.Quit();
    }

    public void clickNo() {
        audioManager.PlaySFX(audioManager.click);
        confirmMenu.enabled = false;
        mainMenu.SetActive(true);
    }

}
