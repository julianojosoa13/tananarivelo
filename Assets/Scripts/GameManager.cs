using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool paused = false;

    [SerializeField]
    private GameObject hud;

    [SerializeField]
    private GameObject pauseUI;

    [SerializeField]
    private GameObject blurEffect;

    [SerializeField]
    private AudioSource bgMusic;

    // Start is called before the first frame update
    void Start()
    {
        UnPauseGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGamePaused())
            {
                UnPauseGame();
            }
            else PauseGame();
        }
    }

    public bool IsGamePaused()
    {
        return paused;
    }

    public void PauseGame()
    {
        bgMusic.volume = 0.20f;
        blurEffect.SetActive(true);
        hud.SetActive(false);
        pauseUI.SetActive(true);
        Time.timeScale = 0;
        paused = true;
    }

    public void UnPauseGame()
    {
        bgMusic.volume = 0.50f;
        blurEffect.SetActive(false);
        hud.SetActive(true);
        pauseUI.SetActive(false);
        Time.timeScale = 1;
        paused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
