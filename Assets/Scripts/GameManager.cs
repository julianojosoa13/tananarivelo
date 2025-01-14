using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor;
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

    [SerializeField] private GameObject player;

    [SerializeField] private GameObject followCamera;

    [SerializeField] private GameObject villageMap;

    [SerializeField] private GameObject churchInterior;

    [SerializeField] private GameObject questUpdates;

    [SerializeField] private TMP_Text questText;

    [SerializeField] private BounceEffect questList;

    [SerializeField] private GameObject mainPausePage;

    [SerializeField] private GameObject confirmPausePage;
    private Transform playerBuildingExitPos;

    private GameObject currentBuilding;

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
                if (confirmPausePage.activeSelf)
                {
                    HideConfirmPage();
                }
                else UnPauseGame();
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

    public void DisablePlayer()
    {
        player.SetActive(false);
        followCamera.SetActive(false);
    }

    public void EnablePlayer()
    {
        player.SetActive(true);
        followCamera.SetActive(true);
    }


    public void EnterBuilding(GameObject building, Transform exitPosition)
    {
        building.SetActive(true);
        villageMap.SetActive(false);
        playerBuildingExitPos = exitPosition;
        currentBuilding = building;
        DisablePlayer();
    }

    public void ExitBuilding()
    {
        currentBuilding.SetActive(false);
        villageMap.SetActive(true);
        EnablePlayer();
        player.transform.position = playerBuildingExitPos.position;
        player.transform.rotation = playerBuildingExitPos.rotation;
    }

    public void FinishQuest()
    {
        questUpdates.SetActive(true);
        questText.text = "- Now feel free to roam the Demo Village";
        questList.Bounce();
    }

    public void HideConfirmPage()
    {
        confirmPausePage.SetActive(false);
        mainPausePage.SetActive(true);
    }

    public void ShowConfirmPage()
    {
        confirmPausePage.SetActive(true);
        mainPausePage.SetActive(false);
    }
}
