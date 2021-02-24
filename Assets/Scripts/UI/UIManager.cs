using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject timesUpText;
    public GameObject congratsText;
    public GameObject pauseMenu;
    public bool _isGamePaused;
    private float timeRemaining = 54f;
    private bool timerIsRunning = false;
    public bool _popUp;

    public Image scoreBar;
    public Text timeText;

    [SerializeField] private AudioManager _audioManager;

    private void Start()
    {
        _popUp = false;
        _isGamePaused = false;
        pauseMenu.SetActive(false);
        timesUpText.SetActive(false);
        congratsText.SetActive(false);
        timerIsRunning = true;
        _audioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void Update()
    {
        RunningTime();
        DisplayTime(timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void RunningTime()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }

            else
            {
                _isGamePaused = true;
                timeRemaining = 0;
                timerIsRunning = false;
                _popUp = true;
                timesUpText.SetActive(true);
                _audioManager.PlayGameEndAudio();
                Time.timeScale = 0f;
            }

        }
    }

    public void PauseMenu()
    {
        if (_popUp)
        {
            return;
        }

        if (_isGamePaused == true)
        {
            _isGamePaused = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1;
            return;
        }

        _isGamePaused = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

}
